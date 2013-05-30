using ConsoleParametersProcessor.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.ParameterParsers
{
    internal class KeyedParametersParser : ParametersParserBase
    {
        public override List<CParameter> Parse(string[] args)
        {
            //if (args.Length % 2 != 0)
            //    throw new ConsoleParametersException("Parameters count differs to keys count");
            
            List<CParameter> result = new List<CParameter>();
            var addedAliases = ConsoleParametersSettings.GetAllAliases();

            for (int i = 0; i < args.Length; i += 2)
            {
                string key = GetKeyByRaw(args[i]);
                string alias = null;

                if (result.Any(x => x.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)))
                    throw new ConsoleParametersException("Multiple keys founded: " + key);

                foreach (var k in addedAliases)
                {
                    if (key.Equals(k, StringComparison.InvariantCultureIgnoreCase))
                    {
                        alias = ConsoleParametersSettings.GetAliasByKey(k);
                        break;
                    }
                }

                if (key != null)
                    result.Add(new CParameter(key, alias, args[i+1]));
            }

            return result;
        }

        private string GetKeyByRaw(string keyRaw)
        {
            string result = null;
            var mask = ConsoleParametersSettings.KeyMask;
            var valueIndex = mask.IndexOf("{0}");

            if (mask.Substring(0, valueIndex).Equals(keyRaw.Substring(0, valueIndex)))
                result = keyRaw.Substring(valueIndex, keyRaw.Length - valueIndex).ToUpper();

            if (result == null)
                throw new ConsoleParametersException("Unrecognized key: " + keyRaw);

            return result;
        }
    }
}

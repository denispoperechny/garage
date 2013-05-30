using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.ParameterParsers
{
    internal class KeylessParametersParser : ParametersParserBase
    {
        public override List<CParameter> Parse(string[] args)
        {
            return args.Select(x => new CParameter(null, null, x)).ToList();
        }
    }
}

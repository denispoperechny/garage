using ConsoleParametersProcessor.Exceptions;
using ConsoleParametersProcessor.ParameterParsers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor
{
    public static class ConsoleParameters
    {
        private static Guid? _settingsChangeId = null;
        private static List<CParameter> _parameters = null;

        public static ReadOnlyCollection<CParameter> Parameters
        {
            get
            {
                if (_settingsChangeId == null || _settingsChangeId != ConsoleParametersSettings.ChangeId)
                    UpdateParameters();

                return _parameters.AsReadOnly();
            }
        }

        public static bool TryGetValueByKey(string key, out string value)
        {
            if (!ConsoleParametersSettings.UseParametersKeys)
                throw new InvalidOperationException("Can not get value by key when ConsoleParametersSettings.UseParametersKeys == False");
            
            if (_settingsChangeId == null || _settingsChangeId != ConsoleParametersSettings.ChangeId)
                UpdateParameters();

            var searchedParameter = _parameters.FirstOrDefault(x => key.Equals(x.Key, StringComparison.InvariantCultureIgnoreCase));
            if (searchedParameter != null)
            {
                value = searchedParameter.Value;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        public static bool TryGetValueByAlias(string alias, out string value)
        {
            if (!ConsoleParametersSettings.UseParametersKeys)
                throw new InvalidOperationException("Can not get value by alias when ConsoleParametersSettings.UseParametersKeys == False");
            
            if (_settingsChangeId == null || _settingsChangeId != ConsoleParametersSettings.ChangeId)
                UpdateParameters();

            var searchedParameter = _parameters.Single(x => alias.Equals(x.Alias, StringComparison.InvariantCultureIgnoreCase));
            if (searchedParameter != null)
            {
                value = searchedParameter.Value;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        public static string GetValueByKey(string key)
        {
            string result = null;
            if (!TryGetValueByKey(key, out result))
                throw new ConsoleParametersException("Parameter with specified key was not founded: " + key);

            return result;
        }

        public static string GetValueByAlias(string alias)
        {
            string result = null;
            if (!TryGetValueByAlias(alias, out result))
                throw new ConsoleParametersException("Parameter with specified alias was not founded: " + alias);

            return result;
        }

        private static void UpdateParameters()
        {
            _settingsChangeId = ConsoleParametersSettings.ChangeId;

            ParametersParserBase parser = ConsoleParametersSettings.UseParametersKeys 
                ? new KeyedParametersParser() as ParametersParserBase 
                : new KeylessParametersParser() as ParametersParserBase;

            _parameters = parser.Parse(System.Environment.GetCommandLineArgs().Skip(1).ToArray());
        }

    }
}

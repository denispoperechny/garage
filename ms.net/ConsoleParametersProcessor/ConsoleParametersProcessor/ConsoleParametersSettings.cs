using ConsoleParametersProcessor.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor
{
    public static class ConsoleParametersSettings
    {
        private static Guid _changeId = Guid.NewGuid();
        private static string _keyMask = "-{0}";
        private static bool _useParametersKeys = true;
        private static readonly Dictionary<string, string> _keyToAliasDictionary = new Dictionary<string,string>();

        /// <summary>
        /// Settings change ID
        /// </summary>
        internal static Guid ChangeId
        {
            get { return _changeId; }
        }

        public static bool UseParametersKeys
        {
            get { return _useParametersKeys; }

            set
            {
                _changeId = Guid.NewGuid();
                _useParametersKeys = value;
            }
        }

        /// <summary>
        /// Defines parameter key's mask. (-p  /p  p)
        /// </summary>
        public static string KeyMask
        {
            get { return _keyMask; }
            set
            {
                _changeId = Guid.NewGuid();
                _keyMask = value;
            }
        }

        public static void AddKeyAlias(string key, string alias)
        {
            _changeId = Guid.NewGuid();

            if (_keyToAliasDictionary.Any(x => x.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)))
                throw new ConsoleParametersException("Alias is already added for key: " + key.ToUpper());

            if (_keyToAliasDictionary.Any(x => x.Value.Equals(alias, StringComparison.InvariantCultureIgnoreCase)))
                throw new ConsoleParametersException("Given alias is already added: " + alias.ToUpper());

            _keyToAliasDictionary.Add(key.ToUpper(), alias);
        }

        internal static string GetAliasByKey(string key)
        {
            string result = null;
            if (_keyToAliasDictionary.ContainsKey(key))
                    result = _keyToAliasDictionary[key];

            return result;
        }

        internal static string[] GetAllAliases()
        {
            return _keyToAliasDictionary.Select(x => x.Key).ToArray();
        }

    }
}

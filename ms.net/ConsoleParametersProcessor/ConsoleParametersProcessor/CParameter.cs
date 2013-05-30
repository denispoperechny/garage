using ConsoleParametersProcessor.Modifiers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor
{
    /// <summary>
    /// Console parameter object
    /// </summary>
    public class CParameter
    {
        private readonly List<IModifier> _modifiers = new List<IModifier>();
        private readonly string _originalValue;
        private string _calculatedValue = null;

        internal CParameter(string key, string alias, string value)
        {
            _originalValue = value;
            Key = key;
            Alias = alias;
        }

        public string Key { get; private set; }

        public string Alias { get; private set; }

        public string Value 
        {
            get
            {
                if (_calculatedValue == null)
                    UpdateValue();

                return _calculatedValue;
            }
        }

        public ReadOnlyCollection<IModifier> Modifiers 
        {
            get { return _modifiers.AsReadOnly(); }
        }

        public void AddModifier(IModifier modifier)
        {
            _calculatedValue = null;
            _modifiers.Add(modifier);
        }

        private void UpdateValue()
        {
            _calculatedValue = _originalValue;
            foreach (IModifier modifier in _modifiers)
            {
                _calculatedValue = modifier.Modify(_calculatedValue);
            }
        }
    }
}

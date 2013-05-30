using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.Modifiers
{
    public class UnQuoteModifier : IModifier
    {
        private static char[] _quotes = { '"' };
        
        public string Modify(string inputData)
        {
            char currentQuoteType = inputData[0];

            if (!_quotes.Contains(currentQuoteType) || inputData[inputData.Length - 1] != currentQuoteType)
                return inputData;

            return inputData.Substring(1, inputData.Length - 2);
        }
    }
}

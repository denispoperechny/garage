using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.Modifiers
{
    public class LowerCaseModifier : IModifier
    {
        public string Modify(string inputData)
        {
            return inputData.ToLower();
        }
    }
}

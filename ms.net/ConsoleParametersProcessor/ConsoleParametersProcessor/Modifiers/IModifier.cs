using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.Modifiers
{
    public interface IModifier
    {
        string Modify(string inputData);
    }
}

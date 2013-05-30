using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.ParameterParsers
{
    internal abstract class ParametersParserBase
    {
        public abstract List<CParameter> Parse(string[] args);
    }
}

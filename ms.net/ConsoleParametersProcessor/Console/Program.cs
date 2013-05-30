using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleParametersProcessor;
using ConsoleParametersProcessor.Modifiers;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello");

            ConsoleParametersSettings.KeyMask = "/{0}";
            ConsoleParametersSettings.AddKeyAlias("t", "Tested");
            ConsoleParameters.Parameters.Where(x => "tested".Equals(x.Alias, StringComparison.InvariantCultureIgnoreCase)).
                ToList().ForEach(f => f.AddModifier(new UnQuoteModifier()));
            //foreach (var param in ConsoleParameters.Parameters)
            //    param.AddModifier(new UnQuoteModifier());

            System.Console.WriteLine(ConsoleParameters.GetValueByAlias("Tested"));

            System.Console.ReadKey();
        }
    }
}

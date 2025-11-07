using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mso_2.Input
{
    internal static class InputFactory
    {
        public static IInputStrategy Create(string type, string[] arguments)
        {
            return type switch
            {
                "example" => new ExampleInput(arguments),
                "file" => new FileInput(arguments),
                "string" => new StringInput(arguments),
                _ => throw new ArgumentException("Unknown input type")
            };
        }
    }
}

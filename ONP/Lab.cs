using System;
using System.Collections;

namespace ONP
{
    class Lab
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lingiwstyka matematyczna zadanie 4 - ONP");
            Console.WriteLine("----------------------------------------");

            // var input = "((2*5+1)/2)";
            var input = "(2+1)*3-4*(7+4)";

            var stack = new Stack((uint)input.Length);

            var output = "";

            foreach(var character in input)
            {

                // nawias otwierajacy jest specjalnym przypadkiem - musi byc odlozony na dno stosu
                if (character == '(')
                {
                    stack.pushToBottom(character);
                }
            }

            Console.WriteLine(output);

            // pauzuje program
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace ONP
{
    class Lab
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lingwistyka matematyczna zadanie 4 - ONP");
            Console.WriteLine("----------------------------------------");

            var input = "((2*5+1)/2)";
            //  var input = "(2+1)*3-4*(7+4)"; // wynik: 2 1 + 3 * 4 7 4 + * -
            //Console.WriteLine("powinno byc" + "21+3*474+*-"); // TODO: co z liczbami ktore maja kilka cyfr?

            var stack = new ONPStack(input.Length);

            var output = "";

            foreach (var character in input)
            {
                if (Char.IsDigit(character))
                {
                    output += character;
                }
                else if (character == '(')
                {
                    stack.Push(character);
                }
                else if (character == ')')
                {
                    output += stack.PopTillStopSign();
                }
                else
                {
                    if (stack.hasElementWithGreaterPrioryty(character))
                    {
                        output += stack.PopTillStopSign();
                    }

                    stack.Push(character);
                }
            }

            Console.WriteLine(output);
            Console.WriteLine("powinno byc");
            Console.WriteLine("2 5 * 1 + 2 /"); // TODO: dodanie spacji pomiedzy znakami


            // pauzuje program
            Console.ReadLine();
        }
    }
}
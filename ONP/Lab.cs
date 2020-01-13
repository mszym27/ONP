using System;
using System.Collections;
using System.Collections.Generic;

namespace ONP
{
    class Lab
    {
        public static readonly Dictionary<char, int> OperatorPriority = new Dictionary<char, int>() {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 },
            { '(', 3 }, // dodany sztucznie na potrzeby sprawdzenia ponizej
            { ')', 3 },
            { '|', 0 },
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Lingwistyka matematyczna zadanie 4 - ONP");
            Console.WriteLine("----------------------------------------");

            // var input = "((2*5+1)/2)";
            var input = "(2+1)*3-4*(7+4)"; // wynik: 2 1 + 3 * 4 7 4 + * -

            var stack = new Stack(input.Length);

            var output = "";

            foreach(var character in input)
            {
                if (Char.IsDigit(character))
                {
                    output += character;
                }
                else if(character == '(')
                {
                    stack.Push(character);
                }
                else if (character == ')')
                {
                    while(!stack.IsEmpty())
                    {
                        var popped = stack.Pop();

                        // nawias otwierajacy jest specjalnym przypadkiem - jest traktowany jako dno stosu
                        if (popped == '(')
                        {
                            break;
                        }

                        output += popped;
                    }
                }
                else
                {
                    Console.WriteLine(character + " : " + output + " stack: " + stack.head);

                    if (OperatorPriority[character] > OperatorPriority[stack.Peek()])
                    {
                        while (!stack.IsEmpty())
                        {
                            var popped = stack.Pop();

                            // nawias otwierajacy jest specjalnym przypadkiem - jest traktowany jako dno stosu
                            if (popped == '(')
                            {
                                break;
                            }

                            output += popped;
                        }
                    } else
                    {
                        stack.Push(character);
                    }
                }
            }

            Console.WriteLine(output);
            Console.WriteLine("powinno byc");
            Console.WriteLine("21+3*474+*-"); // TODO: co z liczbami ktore maja kilka cyfr?

            // pauzuje program
            Console.ReadLine();
        }
    }
}
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

            var input = "((20*50+10)/20)";
            //  var input = "(2+1)*3-4*(7+4)"; // wynik: 2 1 + 3 * 4 7 4 + * -
            //Console.WriteLine("powinno byc" + "21+3*474+*-"); // TODO: co z liczbami ktore maja kilka cyfr?

            var inputLength = input.Length;

            var stack = new ONPStack(inputLength);

            var output = "";

            for (int i = 0; i < inputLength; i++)
            {
                var character = input[i];

                if (Char.IsDigit(character))
                {
                    // program uwzglednia mozliwosc 
                    // pojawienia sie na wejsciu
                    // liczby kilkucyfrowej
                    // sprawdzane sa nastepne znaki
                    // po napotkaniu cyfr uznaje sie je za czesc liczby
                    var j = i + 1;

                    var wholeNumberToConcat = "" + character;

                    for (; j < inputLength; j++)
                    {
                        character = input[j];

                        if (Char.IsDigit(character))
                        {
                            wholeNumberToConcat += character;
                        }
                        else
                        {
                            j--;

                            break;
                        }
                    }

                    i = j;

                    output += wholeNumberToConcat;
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
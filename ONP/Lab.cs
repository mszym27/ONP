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

                    var wholeNumberToConcat = character.ToString();

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

                    output += wholeNumberToConcat + Consts.SIGN_SEPARATOR;
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

            Console.WriteLine("Wejscie: " + input);
            Console.WriteLine("Po konwersji na ONP: " + output);

            // pauzuje program
            Console.ReadLine();
        }
    }
}
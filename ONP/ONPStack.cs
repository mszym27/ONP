using System.Collections.Generic;

namespace ONP
{
    class ONPStack : Stack
    {
        public static readonly Dictionary<char, int> OperatorPriority = new Dictionary<char, int>() {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 },
            { '(', 3 },
            { ')', 3 },
        };

        public ONPStack(int maxLength) : base(maxLength)
        {
        }

        //specjalna metoda potrzebna do konwersji
        //na ONP - algorytm wymaga mozliwosci
        //przejrzenia stosu w poszukiwaniu elementu o nizszym priorytecie
        //nawiasu otwierajacego lub dna stosu
        public bool hasElementWithGreaterPrioryty(char element)
        {
            for (int i = head; i > stackBottomIndex; i--)
            {
                if(OperatorPriority[element] < OperatorPriority[this.PeekNth(i)])
                {
                    return true;
                }
            }

            return false;
        }

        public string PopTillStopSign()
        {
            var result = "";

            while (!this.IsEmpty())
            {
                var popped = this.Pop();

                if(popped == '(')
                {
                    break;
                }

                result += popped;
            }

            return result;
        }

        public char PeekNth(int n)
        {
            if (this.IsEmpty())
            {
                throw new StackIsEmptyException();
            }
            else
            {
                return this.elements[n];
            }
        }
    }
}
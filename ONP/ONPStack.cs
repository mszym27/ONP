using System.Collections.Generic;

namespace ONP
{
    class ONPStack : Stack
    {
        private static readonly char stackBottom = '|';

        public static readonly Dictionary<char, int> OperatorPriority = new Dictionary<char, int>() {
            { stackBottom, 0 }, // dno stosu - symbol dodany sztucznie na potrzeby sprawdzenia ponizej
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

        // specjalna metoda potrzebna do konwersji 
        // na ONP - algorytm wymaga mozliwosci 
        // przejrzenia stosu w poszukiwaniu elementu o nizszym priorytecie
        // nawiasu otwierajacego lub dna stosu
        //public void checkSignsTillBottom(char element)
        //{
        //    // z natury zadania wynika ze nie ma ryzyka
        //    // ze element taki pojawi sie na koncu stosu - parametrem
        //    // w praktyce moze byc tylko nawias otwierajacy
        //    for (uint i = head; i > 0; i--)
        //    {
        //        elements[i + 1] = elements[i];
        //    }

        //specjalna metoda potrzebna do konwersji
        //na ONP - algorytm wymaga mozliwosci
        //przejrzenia stosu w poszukiwaniu elementu o nizszym priorytecie
        //nawiasu otwierajacego lub dna stosu
        public bool hasElementWithGreaterPrioryty(char element)
        {
            for (int i = head; i > stackBottomIndex; i--)
            {
                if(OperatorPriority[element] > OperatorPriority[this.PeekNth(i)])
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
                return stackBottom;
            }
            else
            {
                return this.elements[n];
            }
        }
    }
}
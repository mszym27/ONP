using System.Collections.Generic;

namespace ONP
{
    class ONPStack : Stack
    {
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
                if(Consts.OP_PRIORITY[element] < Consts.OP_PRIORITY[this.PeekNth(i)])
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

                result += popped + Consts.SIGN_SEPARATOR;
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
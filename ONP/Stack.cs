using System;

namespace ONP
{
    class Stack
    {
        protected const int stackBottomIndex = -1;

        public int head; // wskazuje na szczytowy element stosu
        protected char[] elements;

        public Stack(int maxLength)
        {
            elements = new char[maxLength];

            head = stackBottomIndex;
        }

        public void Push(char element)
        {
            elements[++head] = element;
        }

        //// specjalna metoda potrzebna do konwersji 
        //// na ONP - algorytm wymaga mozliwosci 
        //// dodania elementu na dol stosu
        //public void pushToBottom(char element)
        //{
        //    // z natury zadania wynika ze nie ma ryzyka
        //    // ze element taki pojawi sie na koncu stosu - parametrem
        //    // w praktyce moze byc tylko nawias otwierajacy
        //    for (uint i = head; i > 0; i--)
        //    {
        //        elements[i + 1] = elements[i];
        //    }

        //    elements[0] = element;

        //    head++;
        //}

        public char Pop()
        {
            if (this.IsEmpty())
            {
                throw new StackIsEmptyException();
            }

            return elements[head--];
        }

        public char Peek()
        {
            if (this.IsEmpty())
            {
                throw new StackIsEmptyException();
            }

            return elements[head];
        }

        public bool IsEmpty()
        {
            return (head == stackBottomIndex);
        }

        //public char[] popAll()
        //{
        //    var result = new char[head];

        //    do
        //    {
        //        result[maxLength - head] += this.Pop();
        //    } while (head > 0);

        //    return result;
        //}
    }
}
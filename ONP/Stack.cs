using System;

namespace ONP
{
    class Stack
    {
        private const int stackBottom = -1;

        public int head; // wskazuje na szczytowy element stosu
        private char[] elements;

        public Stack(int maxLength)
        {
            elements = new char[maxLength];

            head = stackBottom;
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
            return elements[head--];
        }

        public char Peek()
        {
            return this.IsEmpty()? '|' : elements[head];
        }

        public bool IsEmpty()
        {
            return (head == stackBottom);
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
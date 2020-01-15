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
    }
}
using System;

namespace ONP
{
    class Stack
    {
        private uint head;
        private char[] elements;

        public Stack(uint length)
        {
            elements = new char[length];
            head = 0;
        }

        public void push(char element)
        {
            elements[head] = element;
            head++;
        }

        // specjalna metoda potrzebna do konwersji 
        // na ONP - algorytm wymaga mozliwosci 
        // dodania elementu na dol stosu
        public void pushToBottom(char element)
        {
            // z natury zadania wynika ze nie ma ryzyka
            // ze element taki pojawi sie na koncu stosu - parametrem
            // w praktyce moze byc tylko nawias otwierajacy
            for (uint i = head; i > 0; i--)
            {
                elements[i + 1] = elements[i];
            }

            elements[0] = element;
            head++;
        }

        public char pop()
        {
            return elements[--head];
        }
    }
}
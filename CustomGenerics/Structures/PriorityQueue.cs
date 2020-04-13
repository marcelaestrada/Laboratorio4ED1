using System;
using CustomGenerics.Interfaces;
using System.IO;

namespace CustomGenerics.Structures
{
    public class PriorityQueue<T> : ILinearDataBase<T> where T : IComparable
    {
        NodePriorityQueue<T> firstHigh = null;
        NodePriorityQueue<T> firstLow = null;
        NodePriorityQueue<T> lastHigh = null;
        NodePriorityQueue<T> lastLow = null;
        bool isEmpty(NodePriorityQueue<T> evaluate)
        {
            if (evaluate == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void InsertPriority(bool priority, T data)
        {
            NodePriorityQueue<T> aux = new NodePriorityQueue<T>();
            aux.value = data;
            aux.Next = null;

            if (priority)
            {
                NodePriorityQueue<T> aux2 = lastHigh;
                if (isEmpty(firstHigh))
                {
                    firstHigh = aux;
                }
                else
                {
                    lastHigh = aux;
                    lastHigh.Previous = aux2;
                }
            }
            else
            {
                NodePriorityQueue<T> aux2 = lastLow;
                if (isEmpty(firstLow))
                {
                    firstLow = aux;
                }
                else
                {
                    lastLow = aux;
                    lastLow.Previous = aux2;
                }
            }

        }

        T DeleteFromQueue()
        {
            NodePriorityQueue<T> aux = null;
            if (firstHigh != null)
            {
                aux = firstHigh;

                if (firstHigh == lastHigh)
                {
                    firstHigh = null;
                    lastHigh = null;
                }
                else
                {
                    firstHigh = firstHigh.Next;
                }
            }
            else
            {
                aux = firstLow;

                if (firstLow == lastLow)
                {
                    firstLow = null;
                    lastLow = null;
                }
                else
                {
                    firstLow = firstLow.Next;
                }
            }
            
            return aux.value;
        }
        public T Delete()
        {
            return DeleteFromQueue();
        }

        public void Insert(bool priority, T data)
        {
            InsertPriority(priority, data);
        }
    }
}

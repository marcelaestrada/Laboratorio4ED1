using System;
using CustomGenerics.Interfaces;
using System.IO;

namespace CustomGenerics.Structures
{
    public class PriorityQueue<T> : ILinearDataBase<T> where T : IComparable
    {
        NodePriorityQueue<T> firstHigh = null;
        NodePriorityQueue<T> lastHigh = null;
        NodePriorityQueue<T> firstLow = null;
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

        public void InsertPriority(bool priority, NodePriorityQueue<T> firstHigh, NodePriorityQueue<T> lastHigh, NodePriorityQueue<T> firstLow, NodePriorityQueue<T> lastLow, T data)
        {
            NodePriorityQueue<T> aux = new NodePriorityQueue<T>();
            aux.value = data;
            aux.Next = null;

            if (priority)
            {
                if (isEmpty(firstHigh))
                {
                    firstHigh = aux;
                }
                else
                {
                    lastHigh.Next = aux;
                }
            }
            else
            {
                if (isEmpty(firstLow))
                {
                    firstLow = aux;
                }
                else
                {
                    lastLow.Next = aux;
                }
            }

        }

        public T DeleteFromQueue(NodePriorityQueue<T> firstHigh, NodePriorityQueue<T> lastHigh, NodePriorityQueue<T> firstLow, NodePriorityQueue<T> lastLow)
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
                    firstHigh = firstHigh.Next;
                }
            }
            
            return aux.value;
        }
        public T Delete()
        {
            return DeleteFromQueue(firstHigh, lastHigh, firstLow, lastLow);
        }

        public void Insert(bool priority, T data)
        {
            InsertPriority(priority, firstHigh, lastHigh, firstLow, lastLow, data);
        }
    }
}

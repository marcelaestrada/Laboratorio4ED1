using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGenerics.Interfaces;

namespace CustomGenerics.Structures
{
    public class Queue<T> : INotLinearDataBase<T> where T : IComparable
    {
        List<Node<T>> priorityQueue = new List<Node<T>>();
        int size = -1;
        public int con { get { return priorityQueue.Count; } }

        int reverseEquation(int x)
        {
            return (x - 1) / 2;
        }

        void change(int x, int y)
        {
            
            var aux = priorityQueue[x];
            priorityQueue[x] = priorityQueue[y];
            priorityQueue[y] = aux;

        }

        int left(int x)
        {
            return (x * 2) + 1;
        }

        int right(int x)
        {
            return (x * 2) + 2;
        }

        void maxHeap(int x)
        {
            int nleft = left(x);
            int nright = right(x);
            int h = x;

            if ((nleft <= size) && (priorityQueue[h].priority < priorityQueue[nleft].priority))
            {
                h = nleft;
            }
            if ((nright <= size) && priorityQueue[h].priority < priorityQueue[nright].priority)
            {
                h = nright;
            }
            if (h != x)
            {
                change(h, x);
                maxHeap(h);
            }
        }

        void heapMax(int x)
        {
            while ((x >= 0) && (priorityQueue[reverseEquation(x)].priority < priorityQueue[x].priority))
            {
                change(x, reverseEquation(x));
                x = reverseEquation(x);
            }
        }

        void Inserting(int p, T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.priority = p;
            newNode.value = data;

            priorityQueue.Add(newNode);
            size++;
            heapMax(size);
        }

        T Deleting ()
        {
            if (size > -1)
            {
                var data = priorityQueue[0].value;
                priorityQueue[0] = priorityQueue[size];
                priorityQueue.RemoveAt(size);
                size--;
                maxHeap(0);
                return data;
            }
            else
            {
                throw new Exception("is empty");
            }
        }

        public void Insert(int value, T data)
        {
            Inserting(value, data);
        }

        public T Delete()
        {
            return Deleting();
        }
    }
}

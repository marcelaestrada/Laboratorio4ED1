using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomGenerics.Interfaces;

namespace CustomGenerics.Structures
{
    public class Heap<T> : INotLinearDataBase<T> where T: IComparable
    {
        
        void moveRight(T[] array, int first, int last)
        {
            int root = first;
            while (((root * 2) + 1) <= last)
            {
                int left = (root * 2) + 1;
                int right = (root * 2) + 2;
                int aux = root;
                if (array[aux].CompareTo(array[left])==0)
                {
                    aux = left;
                }

                if ((right.CompareTo(last) <= 0))
                {
                    if ((array[aux].CompareTo(array[right]) == -1))
                    {
                        aux = right;
                    }
                }

                if (aux != root)
                {
                    T aux2 = array[root];
                    array[root] = array[aux];
                    array[aux] = aux2;
                    root = aux;
                }
            }
        }
        void heapify(T[] array, int first, int last)
        {
            int aux = (last - first - 1) / 2;
            while (aux >= 0)
            {
                moveRight(array, aux, last);
                aux--;
            }
        }
        void heap(T[] array, int size)
        {
            heapify(array, 0, (size - 1));
            int last = size - 1;
            while (last > 0)
            {
                T aux = array[last];
                array[last] = array[0];
                array[0] = aux;
                last--;
                moveRight(array, 0, last);
            }
        }

        public void Insert(T[] array, int size)
        {
            heap(array, size);
        }
    }
}

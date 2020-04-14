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
        public Node<T> root = new Node<T>();
        bool cambio = true;

        static void inOrder(Node<T> aux, T data)
        {
            if (aux == null)
            {
                aux.value = data;
            }
            else
            {
                inOrder(aux.left,data);
                inOrder(aux.right, data);
            }
        }
        
        void postOrden(Node<T> actual)
        {
            T aux2;
            if (root == null)
            {
                root = null;
            }
            else
            {
                if (root.left.value.CompareTo(root.value)==1)
                {
                    aux2 = root.value;
                    root.value = root.left.value;
                    root.left.value = aux2;
                    cambio = false;
                }
                if (root.right.value.CompareTo(root.value) == 1)
                {
                    aux2 = root.value;
                    root.value = root.right.value;
                    root.right.value = aux2;
                    cambio = false;
                }
                postOrden(root.left);
                postOrden(root.right);
            }
            postOrden(root);
        }
        void inserting(Node<T> aux, int data)
        {
            if (aux == null)
            {
                root = aux;
            }
            else
            {
                Queue<Node<T>> priorityQueue = new Queue<Structures.Node<T>>();
                priorityQueue.Enqueue(aux);

                while (priorityQueue.Count != 0)
                {
                    aux = priorityQueue.Peek();
                    priorityQueue.Dequeue();

                    if (aux.left == null)
                    {
                        aux.left = new Node<T>();
                        break;
                    }
                    else
                    {
                        priorityQueue.Enqueue(aux.left);
                    }
                    if (aux.right == null)
                    {
                        aux.right = new Node<T>();
                        break;
                    }
                    else
                    {
                        priorityQueue.Enqueue(aux.right);
                    }
                }
            }
        }

        void insertPriority(Node<T> aux, int data)
        {
            inserting(aux, data);
            while (cambio)
            {
                postOrden(aux);
            }
        }

        public void Insert(Node<T> info, int data)
        {
            insertPriority(info, data);
        }
    }
}

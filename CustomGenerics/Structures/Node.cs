using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    class Node<T>
    {
        public T value { get; set; }
        public int priority { get; set; }
    }
}

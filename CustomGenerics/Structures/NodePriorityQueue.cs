using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class NodePriorityQueue<T> where T : IComparable
    {
        public T value { get; set; }
        public NodePriorityQueue<T> Next { get; set; }
    }
}

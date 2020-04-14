using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio4ED1.Models
{
    public class PriorityQueueModel:IComparable
    {
        public int Priority { get; set; }
        public string Tarea { get; set; }

        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
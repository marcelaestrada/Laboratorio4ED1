using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio4ED1.Models
{
    public class PriorityQueueModel : IComparable
    {
        public int Priority { get; set; }
        public string Tarea { get; set; }

       /* private int Priority = 0;

        public void SetPriority(int value)
        {
            this.Priority = value;
        }

        public int GetPriority()
        {
            return this.Priority;
        }

        private string Tarea = " ";

        public void SetTarea(string value)
        {
            this.Tarea = value;
        }

        public string GetTarea()
        {
            return this.Tarea;
        }*/

        int IComparable.CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
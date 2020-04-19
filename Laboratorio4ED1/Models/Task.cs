using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio4ED1.Models
{
    public class Task : IComparable
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Proyecto { get; set; }
        public string Prioridad { get; set; }
        public string Entrega { get; set; }

        public static Comparison<Task> SearchByPriority = delegate (Task prior, Task taskPrior)
        {
            return prior.Prioridad.CompareTo(taskPrior.Prioridad);
        };

        public int CompareTo(object comming)
        {
            return this.Titulo.CompareTo(((Task)comming).Titulo);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laboratorio4ED1.Models
{
    public class Manager
    {
        [Display(Name = "Usuario")]
        public string user { get; set; }
        
        [Display(Name = "Contraseña")]
        public string password { get; set; }
    }
}
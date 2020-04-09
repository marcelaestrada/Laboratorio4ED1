using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laboratorio4ED1.Models
{
    public class UserInformation
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
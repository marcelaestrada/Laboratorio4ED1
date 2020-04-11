﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio4ED1.Models;

namespace Laboratorio4ED1.Helpers
{
    public class Storage
    {
        private static Storage _instance = null;
        public static Storage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Storage();

                return _instance;
            }
        }

        public List<UserInformation> usersList = new List<UserInformation>();
    }
}
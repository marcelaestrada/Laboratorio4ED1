using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laboratorio4ED1.Models;
using CustomGenerics.Structures;

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
        public int[] priorityArray = new int[10];
        public Heap<PriorityQueueModel> heap = new Heap<PriorityQueueModel>();
        
        public void InitDebugUsers()
        {
            UserInformation joshua = new UserInformation
            {
                Cargo = "Developer",
                Email = "j97valey@gmail.com",
                Nombre = "Joshua",
                Password = "123abc",
            };

            UserInformation raul = new UserInformation
            {
                Cargo = "Project Manager",
                Email = "R97valey@gmail.com",
                Nombre = "Raul",
                Password = "123abc",
            };

            Storage.Instance.usersList.Add(joshua);
            Storage.Instance.usersList.Add(raul);
        }

    }
}
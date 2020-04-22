using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio4ED1.ModelViews;
using Laboratorio4ED1.Helpers;
using Laboratorio4ED1.Models;
using CustomGenerics.Structures;

namespace Laboratorio4ED1.Controllers
{
    public class ManagerController : Controller
    {

        #region Developer
        public ActionResult AddTask()
        {
            return View();
        }
        #endregion

        #region ProjectManager
        public List<UserInformation> ListOfDevelopers()
        {
            List<UserInformation> Developers =
                Storage.Instance.usersList.FindAll(
                    (data) =>
                    {
                        return (data.Cargo.CompareTo("Developer") == 0) ? true : false;
                    });
            return Developers;
        }
        public ActionResult DevelopersList()
        {
            return View(ListOfDevelopers());
        }

        public ActionResult SeeDeveloperTasks(string Username)
        {
            //List<string> TasksOfDeveloper = new List<string>();
            List<Task> TasksInformation = new List<Task>();

            Storage.Instance.usersList.Find((user) => {
                if (user.Username == Username)
                {
                    List<Node<PriorityQueueModel>> developerTasks = user.Tasks.CopyOfData();
                    /* for (int i = developerTasks.size; i >= 0; i--)
                     {
                         //TasksOfDeveloper.Add(developerTasks.Delete());
                         TasksInformation.Add(
                             Storage.Instance.pendingDevelopersTasks.Search(developerTasks.Delete()));


                     }*/
                    foreach (var item in developerTasks)
                    {
                        TasksInformation.Add(
                             Storage.Instance.pendingDevelopersTasks.Search(item.value));
                    }
                    return true;
                }
                else
                    return false;
            });


            //Retornar la vista de las tareas de los developers, falta acceder al diccionario con cada 
            //Titulo de tarea y mandar la lista tipo task con toda la data de las tareas traida del diccionario
            // a la nueva vista tipo listView
            return View(TasksInformation);
        }
        #endregion

        #region Shared Views
        //Login
        public ActionResult Index()
        {
            return View();
        }
        //Sign Up
        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public Task SiguienteTarea()
        {
            Task siguienteTarea = new Task();
            string siguiente = Storage.Instance.currentUser.Tasks.Peek();

            if (siguiente == "No hay tareas pendientes")
            {
                siguienteTarea.Titulo = "No hay tareas pendientes";
                siguienteTarea.Descripcion = "";
                siguienteTarea.Proyecto = "";
                siguienteTarea.Prioridad = "";
                siguienteTarea.Entrega = "";
            }
            else
            {
                siguienteTarea = Storage.Instance.pendingDevelopersTasks.Search(siguiente);
            }
            return siguienteTarea;
        }
        public ActionResult SeeTask()
        {
            return View(SiguienteTarea());
        }
        #endregion

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            foreach (var item in Storage.Instance.usersList)
            {
                if (collection["user"] == item.Username)
                {
                    if (collection["password"] == item.Password)
                    {
                        //El user logeado se asigna a current User
                        Storage.Instance.currentUser = item;

                        //Si User es Developer => Add Task
                        if (item.Cargo.CompareTo("Developer") == 0)
                        {
                            return View("Menu");

                        }
                        //Si User es Project Manager => Lista de Usuarios
                        else if (item.Cargo.CompareTo("Manager") == 0)
                        {
                            return View("GoToUsers");
                        }


                    }
                    else
                    {
                        ViewBag.Error = "Contraseña incorrecta, inténtelo de nuevo";
                    }
                }
                else
                {
                    ViewBag.Error = "Usuario inválido, inténtelo de nuevo";
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult CreateAccount(FormCollection collection)
        {

            UserInformation newUser = new UserInformation
            {
                Nombre = collection["Nombre"],
                Cargo = collection["Cargo"],
                Email = collection["Email"],
                Username = collection["Username"],
                Password = collection["Password"],

            };

            Storage.Instance.usersList.Add(newUser);

            return View("Index");
        }

        [HttpPost]
        public ActionResult AddTask(FormCollection collection)
        {
            #region

            int prioridad = 0;
            if (collection["Prioridad"] == "Alta")
            {
                prioridad = 5;
            }
            else if (collection["Prioridad"] == "Media")
            {
                prioridad = 3;
            }
            else if (collection["Prioridad"] == "Baja")
            {
                prioridad = 1;
            }

            #endregion

            PriorityQueueModel data = new PriorityQueueModel() { Priority = prioridad, Tarea = collection["Titulo"] };


            Task nuevaTarea = new Task
            {
                Titulo = collection["Titulo"],
                Descripcion = collection["Descripcion"],
                Proyecto = collection["Proyecto"],
                Prioridad = collection["Prioridad"],
                Entrega = collection["Entrega"]
            };
            Storage.Instance.usersList.Find(
                (user) => {

                    if (user.Username.CompareTo(Storage.Instance.currentUser.Username) == 0)
                    {
                        //Debug para ver si la data realmente se asigna...
                        Storage.Instance.currentUser.Tasks.Insert(data.Priority, data.Tarea);
                        Storage.Instance.pendingDevelopersTasks.Insert(nuevaTarea.Titulo, nuevaTarea);
                        return true;
                    }
                    else return false;

                }
                );

            return View("Menu");
        }

        public ActionResult Siguiente()
        {
            Storage.Instance.currentUser.Tasks.Delete();
            return View("SeeTask", SiguienteTarea());
        }
        public ActionResult Agregar()
        {
            return View("AddTask");
        }
        public ActionResult Cerrar()
        {
            return View("Index");
        }
    }
}
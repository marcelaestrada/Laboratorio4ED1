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
            //Tomar de la lista de usuarios todos 
            //aquellos que son desarrolladores
            //Para que el PM pueda visualizarlos
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

        #endregion


        public ActionResult MainPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //Storage.Instance.InitDebugUsers();
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
                            return View("AddTask");
                        }
                        //Si User es Project Manager => Lista de Usuarios
                        else if (item.Cargo.CompareTo("Manager") == 0)
                        {
                            return View("DevelopersList", ListOfDevelopers());
                        }

                        
                    }
                    else
                    {
                        ViewBag.Error = "Contraseña incorrecta, inténtelo de nuevo";
                       // return View("Index"); //Interrumpe el flujo de la app
                    }
                }
                else
                {
                    ViewBag.Error = "Usuario inválido, inténtelo de nuevo";
                   // return View("Index"); //Interrumpe el flujo de la app
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult CreateAccount(FormCollection collection)
        {

            Storage.Instance.userinfo.Nombre = collection["Nombre"];
            Storage.Instance.userinfo.Cargo = collection["Cargo"];
            Storage.Instance.userinfo.Email = collection["Email"];
            Storage.Instance.userinfo.Username = collection["Username"];
            Storage.Instance.userinfo.Password = collection["Password"];
            Storage.Instance.usersList.Add(Storage.Instance.userinfo);
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddTask(FormCollection collection)
        {

            int prioridad = 0;
            if (collection["Prioridad"] == "Alta")
            {
                prioridad = 5;
            }else if(collection["Prioridad"] == "Media")
            {
                prioridad = 3;
            }
            else if (collection["Prioridad"] == "Baja")
            {
                prioridad = 1;
            }

            PriorityQueueModel data = new PriorityQueueModel() { Priority = prioridad, Tarea = collection["Titulo"] };

            List<Task> tasks = new List<Task>();
            Task tareas = new Task();
            tareas.Titulo = collection["Titulo"];
            tareas.Descripcion = collection["Descripcion"];
            tareas.Proyecto = collection["Proyecto"];
            tareas.Prioridad = collection["Prioridad"];
            tareas.Entrega = collection["Entrega"];
            tasks.Add(tareas);
            Storage.Instance.userinfo.queue.Insert(data.Priority, data.Tarea);
            return View("MainPage");
        }
    }
}
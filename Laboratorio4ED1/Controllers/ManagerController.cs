using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio4ED1.ModelViews;
using Laboratorio4ED1.Helpers;
using Laboratorio4ED1.Models;

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
        public ActionResult DevelopersList()
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
            return View(Developers);
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
                        
                        //Si User es Developer => Add Task
                        if (item.Cargo.CompareTo("Developer") == 0)
                        {
                            return View("AddTask");
                        }
                        //Si User es Project Manager => Lista de Usuarios
                        else if (item.Cargo.CompareTo("Project Manager") == 0)
                        {
                            return View("AddTask");
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
            UserInformation userinfo = new UserInformation();
            userinfo.Nombre = collection["Nombre"];
            userinfo.Cargo = collection["Cargo"];
            userinfo.Email = collection["Email"];
            userinfo.Username = collection["Username"];
            userinfo.Password = collection["Password"];
            Storage.Instance.usersList.Add(userinfo);
            return View("Index");
        }

        [HttpPost]
        public ActionResult AddTask(FormCollection collection)
        {
            List<Task> tasks = new List<Task>();
            Task tareas = new Task();
            tareas.Titulo = collection["Titulo"];
            tareas.Descripcion = collection["Descripcion"];
            tareas.Proyecto = collection["Proyecto"];
            tareas.Prioridad = collection["Prioridad"];
            tareas.Entrega = collection["Entrega"];
            tasks.Add(tareas);
            return View("MainPage");
        }
    }
}
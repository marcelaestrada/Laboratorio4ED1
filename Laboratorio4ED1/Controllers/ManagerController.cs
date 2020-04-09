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
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        //Get
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (Storage.Instance.usersList != null)
            {
                foreach (var item in Storage.Instance.usersList)
                {
                    if (collection["user"] == item.Username)
                    {
                        if (collection["password"] == item.Password)
                        {
                            return View("AddTask");
                        }
                        else
                        {
                            ViewBag.Error = "Contraseña incorrecta, inténtelo de nuevo";
                            return View("Index");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Usuario inválido, inténtelo de nuevo";
                        return View("Index");
                    }
                }
            }
            else
            {
                return View("CreateAccount");
            }
                

            return View("Index");
        }

        [HttpPost]
        public ActionResult CreateAccount(FormCollection collection)
        {
            //lo de la lista es una prueba, tengo que hacer un recorrido para que se agregue al final
            try
            {
                Storage.Instance.usersList[0].Name = collection["Name"];
                Storage.Instance.usersList[0].Position = collection["Position"];
                Storage.Instance.usersList[0].Email = collection["Email"];
                Storage.Instance.usersList[0].Username = collection["Username"];
                Storage.Instance.usersList[0].Password = collection["Password"];
                return View("AddTask");
            }
            catch
            {
                return View("CreateAccount");
            }
        }
    }
}
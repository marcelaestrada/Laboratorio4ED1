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

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult AddTask()
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
            else if (Storage.Instance.usersList == null)
            {
                return View("CreateAccount");
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
    }
}
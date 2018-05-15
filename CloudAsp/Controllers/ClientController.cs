using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CloudAsp.Models;
using CloudAspData;
using CloudAspData.Entity;

namespace CloudAsp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IDataCloud _data;

        public ClientController(IDataCloud data)
        {
            _data = data;
        }
        // GET: Client
        public ActionResult Index()
        {
            return null;
        }

        public bool CheckUniqueEmail()
        {
            return true;
        }
        public ActionResult ExitUser()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = new Client()
                    {
                        Email = registration.Email,
                        Password = registration.Password,
                        FirstName = registration.FirstName,
                        MiddleName = registration.MiddleName,
                        LastName = registration.LastName
                    };
                    _data.AddClient(client);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View("Create", registration);
        }
        [HttpPost]
        public ActionResult Authorisation(Authorisation authorisation)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(authorisation.Login, authorisation.Password))
                {
                    FormsAuthentication.SetAuthCookie(authorisation.Login, true);
                    return Json(new { url = Url.Action("Index", "Home") });
                }
            }
            return Json(new { errorText = "Неправильний логін чи пароль" });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SML.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
      if (Session["UserID"] != null)
      {
        return View();
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }
        }



    //For Logout
    public ActionResult Logout()
    {
      Session.Abandon();
      return RedirectToAction("Index", "Home");
    }

}
}

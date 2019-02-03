using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SML.Models;
using System.Web.Security;

namespace SML.Controllers
{
  public class HomeController : Controller
  {

    public ActionResult Index()
    {
      if (Session["UserID"] != null)
      {
        return RedirectToAction("UserDashboard");
      }
      else
      {
         return View();
      }
    }

    //For User Registration
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(UserTable obj)
    {
      if (ModelState.IsValid)
      {
        SMLDBEntities db = new SMLDBEntities();
        db.UserTables.Add(obj);
        db.SaveChanges();
      }
      return RedirectToAction("Index");
    }


    //For User Login
    [HttpPost]
    public ActionResult Login(UserTable objUser)
    {
      if (ModelState.IsValid)
      {
        using (SMLDBEntities db = new SMLDBEntities())
        {
          var obj = db.UserTables.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
          if (obj != null)
          {
            Session["UserID"] = obj.UserID.ToString();
            Session["UserName"] = obj.UserName.ToString();
            Session["Email"] = obj.Email.ToString();
            return RedirectToAction("UserDashboard");
          }
        }
      }
      return View(objUser);
    }

    public ActionResult UserDashboard()
    {
      if (Session["UserID"] != null)
      {
        return View();
      }
      else
      {
        return RedirectToAction("Index");
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
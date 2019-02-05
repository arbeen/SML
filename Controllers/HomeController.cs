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
        return RedirectToAction("Index", "User");
      }
      else
      {
         return View();
      }
    }

    //For User Registration
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(BigViewModel obj)
    {
      if (ModelState.IsValid)
      {
        SMLDBEntities db = new SMLDBEntities();
        db.UserTables.Add(obj.UserTable);
        db.SaveChanges();
      }
      return RedirectToAction("Index");
    }


    //For User Login
    [HttpPost]
    public ActionResult Login(BigViewModel objUser)
    {
      if (ModelState.IsValid)
      {
        using (SMLDBEntities db = new SMLDBEntities())
        {
          var obj = db.UserTables.Where(a => a.UserName.Equals(objUser.UserTable.UserName) && a.Password.Equals(objUser.UserTable.Password)).FirstOrDefault();
          if (obj != null)
          {
            Session["UserID"] = obj.UserID.ToString();
            Session["UserName"] = obj.UserName.ToString();
            Session["Email"] = obj.Email.ToString();
            return RedirectToAction("Index", "User");
          }
        }
      }
      return RedirectToAction("Index", "Home");
    }



  }
}
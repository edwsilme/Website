using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CloseController : Controller
    {
        // GET: Close
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Acceso");
        }
    }
}
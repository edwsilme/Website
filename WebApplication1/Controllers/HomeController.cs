using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private bdPruebawebEntities db = new bdPruebawebEntities();


        public ActionResult Index()
        {
           return View();

            /**
            if(User.Identity.IsAuthenticated)
            {
                using (Models.bdPruebawebEntities db = new Models.bdPruebawebEntities())
                {
                    var idUsuarioActual = User.Identity.GetUserId();

                    var roleManager = new RoleManager<IdentityRole>
                        ()
                }
            }
    **/

        }
        [Authorize(Roles = "db.TBL_USUARIO.idRol == 1")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
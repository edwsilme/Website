using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {

        private TBL_USUARIO oUsuario;
        private bdPruebawebEntities db = new bdPruebawebEntities();
        private int idRol;

        public AuthorizeUser(int idRol = 0)
        {
            this.idRol = idRol;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            try
            {
                oUsuario = (TBL_USUARIO)HttpContext.Current.Session["User"];
                var lstMisOperaciones = from m in db.TBL_USUARIO
                                        where m.id == oUsuario.idRol
                                        select m.nombre;

                if (lstMisOperaciones.ToList().Count() == 1)
                {
                    filterContext.Result = new RedirectResult("~/sinAcceso/sinAcceso");
                }

            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/sinAcceso/sinAcceso" + ex.Message);
            }
        }

    }
}
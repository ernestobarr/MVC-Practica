using System;
using System.Linq;
using System.Web.Mvc;
using MVC1.Models;
using BCrypt.Net;

namespace MVC1.Controllers
{
    public class AccessController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string user, string password)
        {
            try
            {
                using (Clasifica db = new Clasifica())
                {
                    // Obtener usuarios que cumplan con los criterios del correo y el status
                    var activeUsers = from u in db.users
                                      where u.email == user && u.idStatus == 1
                                      select u;

                    foreach (var userEntity in activeUsers)
                    {
                        if (BCrypt.Net.BCrypt.Verify(password, userEntity.password))
                        {
                            // Inicio de sesión exitoso
                            Session["User"] = userEntity;
                            return Content("1");
                        }
                    }

                    // Cuando el usuario es incorrecto
                    return Content("Usuario sin Acceso");
                }
            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo: " + ex.Message);
            }
        }
    }
}
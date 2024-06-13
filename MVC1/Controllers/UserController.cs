using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//importar el models 
using MVC1.Models;
using MVC1.Models.TableViewModels;

//Agreamos el modelo de nuestro formulario
using MVC1.Models.ViewModels;
using WebGrease.Css.Extensions;

namespace MVC1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            //Creamos una Lista
            List<UserTableViewModel> lst = null;
            using(Clasifica db = new Clasifica())
            {
                //Llenamos la lista
                lst = (from d in db.users
                      where d.idStatus == 1
                      orderby d.email
                      select new UserTableViewModel
                      {
                          Email = d.email,
                          Id = d.id,
                          Edad = d.edad
                      }).ToList();


            }


            return View(lst);
        }

        [HttpGet] //metodo
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost] //metodo
        public ActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid) //validando los dataanotation
            {
                return View(model);
            }

            using( var db = new Clasifica())
            {
                user oUser = new user();
                oUser.idStatus = 1;
                oUser.email = model.Email;
                oUser.edad =model.Edad;
                oUser.password = model.Password;

                db.users.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));

        }


        //Meteod para edtiar  si no le pondemos httpget por defecto lo es
        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db= new Clasifica())
            {
                var oUser = db.users.Find(Id);
                //llenamos el model
                model.Edad = (int)oUser.edad; //porque permite nullos
                model.Email = oUser.email;
                //No ponemos pasww porque no se puede ver
                model.Id = oUser.id;

            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model) //Recibe modelo
        {
            if (!ModelState.IsValid) //validando los dataanotation
            {
                return View(model);
            }

            using (var db = new Clasifica())
            {
                var oUser = db.users.Find(model.Id);
                oUser.edad = model.Edad;
                oUser.email = model.Email;
                if(model.Password!=null && model.Password.Trim()!="")
                    {
                    oUser.password = model.Password;

                }
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;  //le decimos al entity que se edita
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/User/"));
        }
    }
}


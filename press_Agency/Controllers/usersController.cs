using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using press_Agency.Models;

namespace press_Agency.Controllers
{
    public class usersController : Controller
    {
        private identityModel db = new identityModel();
        string Alredy_username;

        // GET: users


        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(user_login user1)
        {
            if (ModelState.IsValid)
            {

                IEnumerable<user> users = db.users.ToList();
                IEnumerable<post> post = db.posts.ToList();
                if (user1.username != null)
                {
                    foreach (var item in users)
                    {
                        if (item.username == user1.username)
                        {
                            if (item.password == user1.password)
                            {
                                ViewBag.Alredy_username = user1.username;

                                Alredy_username = user1.username;
                                if (item.userRole == "admin")
                                {
                                    return RedirectToAction("profile", new RouteValueDictionary(new { Controller = "users", Action = "profile", id = user1.username }));

                                }
                                else if (item.userRole == "Editor")
                                {
                                    return RedirectToAction("Create", new RouteValueDictionary(new { Controller = "posts", Action = "Create", id = Alredy_username }));


                                    return RedirectToAction("profile", new RouteValueDictionary(new { Controller = "users", Action = "profile", id = user1.username }));

                                    return RedirectToAction("My_posts", new RouteValueDictionary(new { Controller = "posts", Action = "My_posts", id = user1.username }));


                                    return RedirectToAction("Create", new RouteValueDictionary(new { Controller = "posts", Action = "Create", id = Alredy_username }));

                                }
                                else if (item.userRole == "Viewer")
                                {

                                    return RedirectToRoute(new { Controller = "posts", Action = "Wall", id = Alredy_username });
                                }
                                else
                                {

                                    return Content("wrong password or username");

                                }
                            }
                            else
                            {
                                return Content("wrong password or username");
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }
            return View(user1);
        }

        public ActionResult profile()
        {
            user admin = db.users.Find("admin");
            return View(admin);
        }

        [Route("users/profile_E/{username}")]
        public ActionResult profile_E(string username)
        {
            user admin = db.users.Find(username);
            return View(admin);
        }


        public ActionResult pr()
        {
            var create = GetProfileEditor().ToList();
            var profi= db.users.Find("admin");
            return View(profi);

        }

        public IEnumerable<user> GetProfileEditor()
        {
            List<user> createnew = db.users.ToList();
            // var profile = db.users.ToList();

            return createnew;
        }
    


    public string EditorUsername()
        {

            return (Alredy_username);
        }
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: users/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "username,Fname,Lname,Email,password,phoneNumber,photo,ImageFile")] user user, FormCollection frm)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                string Extension = Path.GetExtension(user.ImageFile.FileName);
                fileName = fileName + Extension;
                user.photo = "~/Images_face_users/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images_face_users/"), fileName);
                user.ImageFile.SaveAs(fileName);
                string userRoleRadio = frm["userRole"].ToString();
                user.userRole = userRoleRadio;

                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return Json(new { result = 0 });
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,Fname,Lname,Email,password,phoneNumber,photo,ImageFile")] user user, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                string Extension = Path.GetExtension(user.ImageFile.FileName);
                fileName = fileName + Extension;
                user.photo = "~/Images_face_users/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images_face_users/"), fileName);
                user.ImageFile.SaveAs(fileName);

                string userRoleRadio = frm["userRole"].ToString();
                user.userRole = userRoleRadio;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }



        // GET: users/Edit/5
        public ActionResult Edit_E(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_E([Bind(Include = "username,Fname,Lname,Email,password,phoneNumber,photo,ImageFile")] user user, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                string Extension = Path.GetExtension(user.ImageFile.FileName);
                fileName = fileName + Extension;
                user.photo = "~/Images_face_users/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images_face_users/"), fileName);
                user.ImageFile.SaveAs(fileName);

                string userRoleRadio = frm["userRole"].ToString();
                user.userRole = userRoleRadio;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return View(user);
            }
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }

}

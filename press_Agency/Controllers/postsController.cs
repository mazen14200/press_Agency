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
    public class postsController : Controller
    {
        private identityModel db = new identityModel();
        // GET: All Waiting posts
        public ActionResult Index_waiting_posts()
        {
            return View(db.posts.Where(x=>x.artical_Type== "waiting").ToList());
        }

        // GET: All Approved posts
        public ActionResult Index_Approved_posts()
        {
            return View(db.posts.Where(x => x.artical_Type == "Approved").ToList());
        }

        public ActionResult wall()
        {
            IEnumerable<post> posts = db.posts.Where(x => x.artical_Type == "Approved");
            return View(posts);
        }

        // GET: posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }


        // GET: posts/Approve/5  type="Approved" / "waiting"
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }



        // POST: posts/Approve/5   type="Approved" / "waiting"
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveConfirmed(int id)
        {
            db.posts.Find(id).artical_Type = "Approved";
            db.SaveChanges();
            return RedirectToAction("Index_waiting_posts");
        }

        // GET: posts/Approve/5  type="Approved" / "waiting"
        public ActionResult Refuse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }



        // POST: posts/Approve/5   type="Approved" / "waiting"
        [HttpPost, ActionName("Refuse")]
        [ValidateAntiForgeryToken]
        public ActionResult RefuseConfirmed(int id)
        {
            db.posts.Find(id).artical_Type = "Refused";
            db.SaveChanges();
            return RedirectToAction("Index_waiting_posts");
        }





        // GET: posts/Create
        [Route("posts/Create/{id}")]

        public ActionResult Create(string id)
        {
            ViewBag.editorusername = id;

            ViewData["username"] = id;
            return View();
        }

        // POST: posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("posts/Create/{id}")]
        public ActionResult Create([Bind(Include = "id,artical_Title,artical_Body,postCreationDate,artical_Type,NumberOfViewers,artical_image,ImageFile,editor_username")] post post, string id)
        {
            post.artical_Type = "Waiting";
            post.editor_username = id;
            
                post.postCreationDate = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                string Extension = Path.GetExtension(post.ImageFile.FileName);
                post.artical_image = "~/post_images/" + fileName + Extension;
                fileName = Path.Combine(Server.MapPath("~/post_images/"), fileName);
                post.ImageFile.SaveAs(fileName + Extension);

                db.posts.Add(post);
                db.SaveChanges();
                return RedirectToRoute(new { Controller = "posts", Action = "create", id  });
            
            return View(post);
        }

        // GET: posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,artical_Title,artical_Body,postCreationDate,artical_Type,NumberOfViewers,artical_image,ImageFile")] post post )
        {
            if (ModelState.IsValid)
            {

                post.postCreationDate = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                string Extension = Path.GetExtension(post.ImageFile.FileName);
                post.artical_image = "~/post_images/" + fileName + Extension;
                fileName = Path.Combine(Server.MapPath("~/post_images/"), fileName);
                post.ImageFile.SaveAs(fileName + Extension);
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index_waiting_posts");
            }
            return View(post);
        }

        // GET: posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post post = db.posts.Find(id);
            db.posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index_waiting_posts");
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

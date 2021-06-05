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
            return View(db.posts.Where(x=>x.post_status== "waiting").ToList());
        }

        // GET: All Approved posts
        public ActionResult Index_Approved_posts()
        {
            return View(db.posts.Where(x => x.post_status == "Approved").ToList());
        }


        public ActionResult Time_line()
        {
            IEnumerable<post> posts = db.posts.Where(x => x.post_status == "Approved");
            return View(posts);
        }



        public ActionResult wall2(int? id)
        {

            if (id == null)
            {
                IEnumerable<post> posts1 = db.posts.Where(x => x.post_status == "Approved");
                return View(posts1);
            }
            else if (id > 0)
            {
                db.posts.Find(id).num_of_likes += 1;
                db.SaveChanges();

            }
            else if (id < 0)
            {
                db.posts.Find(-id).num_of_dislikes += 1;
                db.SaveChanges();
            }
            IEnumerable<post> posts = db.posts.Where(x => x.post_status == "Approved");
            return View(posts);
        }


        public ActionResult wall(int? id)
        {

            if (id == null)
            {
                IEnumerable<post> posts1 = db.posts.Where(x => x.post_status == "Approved");
                return View(posts1);
            }
            else if (id > 0)
            {
                db.posts.Find(id).num_of_likes += 1;
                db.SaveChanges();

            }
            else if (id < 0)
            {
                db.posts.Find(-id).num_of_dislikes += 1;
                db.SaveChanges();
            }
            IEnumerable<post> posts = db.posts.Where(x => x.post_status == "Approved"); return View(posts);
        }




        //[HttpPost]
        //public ActionResult wall(int id)
        //{
        //    if (id == null)
        //    {
        //        IEnumerable<post> posts1 = db.posts.Where(x => x.post_status == "Approved");
        //        return View(posts1);
        //    }
        //    else if(id > 0) {
        //        return Content("ghgh");
        //        db.posts.Find(id).num_of_likes+=1;
        //        db.SaveChanges();

        //    }
        //    else if (id < 0)
        //    {

        //    }
        //    IEnumerable<post> posts = db.posts.Where(x => x.post_status == "Approved");
        //    return View(posts);

        //}

        public ActionResult artical_body(int? id)
        {
            post post1 =new post();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            else if (id > 0)
            {
                db.posts.Find(id).NumberOfViewers += 1;
                db.posts.Find(id).num_of_likes += 1;
                db.SaveChanges();
                post1 = db.posts.Find(id);

            }
            else if (id < 0)
            {
                db.posts.Find(-id).num_of_dislikes += 1;
                db.SaveChanges();
                post1 = db.posts.Find(-id);
            }
            return View(post1);
        }



        public ActionResult artical_body2(int? id)
        {
            post post1 = new post();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            else if (id > 0)
            {
                db.posts.Find(id).NumberOfViewers += 1;
                db.posts.Find(id).num_of_likes += 1;
                db.SaveChanges();
                post1 = db.posts.Find(id);

            }
            else if (id < 0)
            {
                db.posts.Find(-id).num_of_dislikes += 1;
                db.SaveChanges();
                post1 = db.posts.Find(-id);
            }
            return View(post1);
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
            db.posts.Find(id).post_status = "Approved";
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
            db.posts.Find(id).post_status = "Refused";
            db.SaveChanges();
            return RedirectToAction("Index_waiting_posts");
        }


        [Route("posts/My_posts/{username}")]
        public ActionResult My_posts(string username)
        {
            var create = GetEditorHistories(username).ToList();
            return View(create);
        }

        public ActionResult savedPosts(string username,int? id)
        {
            if (username==null) { 
            return Content("gfg");
            }
            var create = GetEditorHistories(username).ToList();
            return View(create);
        }
        public IEnumerable<post> GetEditorHistories(string userName)
        {
            IEnumerable<post> createnew = db.posts.Where(x=>x.editor_username == userName).ToList();

            return createnew;
        }


        public ActionResult Article_body()
        {
            return View();
        }


        public ActionResult Question()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Question([Bind(Include = "username,Qusetions,editor_name")] Questions Q)
        {
            db.questions.Add(Q);
            db.SaveChanges();

            return View();
        }



        public ActionResult Answeres()
        {
            IEnumerable<Questions> questions = db.questions.Where(x => x.Answer != null).ToList();
            return View(questions);
        }


        // GET: posts/Create
        [Route("posts/Create/{username}")]

        public ActionResult Create(string username)
        {
            ViewBag.editorusername = username;

            ViewData["username"] = username;
            return View();


        }

        // POST: posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("posts/Create/{username}")]
        public ActionResult Create([Bind(Include = "id,artical_Title,artical_Body,postCreationDate,artical_Type,NumberOfViewers,artical_image,ImageFile,editor_username")] post post, string username)
        {
            post.post_status = "Waiting";
            post.editor_username = username;
            
                post.postCreationDate = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(post.ImageFile.FileName);
                string Extension = Path.GetExtension(post.ImageFile.FileName);
                post.artical_image = "~/post_images/" + fileName + Extension;
                fileName = Path.Combine(Server.MapPath("~/post_images/"), fileName);
                post.ImageFile.SaveAs(fileName + Extension);

                post.NumberOfViewers = post.num_of_dislikes = post.num_of_likes = 0;

                db.posts.Add(post);
                db.SaveChanges();
                return RedirectToRoute(new { Controller = "posts", Action = "create", username });
            
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




        // GET: posts/Edit/5
        public ActionResult Edit_E(int? id)
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
        public ActionResult Edit_E([Bind(Include = "id,artical_Title,artical_Body,postCreationDate,artical_Type,NumberOfViewers,artical_image,ImageFile")] post post)
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
        public ActionResult Delete_E(int? id)
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
        [HttpPost, ActionName("Delete_E")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_E(int id)
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

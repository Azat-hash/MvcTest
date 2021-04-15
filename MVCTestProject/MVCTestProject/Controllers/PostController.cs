using MVCTestProject.Context;
using MVCTestProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestProject.Controllers
{
    public class PostController : Controller
    {
        PostContext db = new PostContext();
        public ActionResult Index()
        {
            return View(db.Posts);
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            ViewBag.Author = GetAuthor();
            ViewBag.Categories = GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post post, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                
                post.Image = imageData;

                ViewBag.Author = GetAuthor();
                ViewBag.Categories = GetCategories();
                db.Posts.Add(post);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(post);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var post = db.Posts.FirstOrDefault(x => x.Id == id);
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = db.Posts.Find(id);
            ViewBag.Author = GetAuthor();
            ViewBag.Categories = GetCategories();

            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Author = GetAuthor();
                return View(post);
            }

            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private SelectList GetAuthor()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = null, Text = "Не выбрано" });
            list.AddRange(db.Authors
                .ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.FirstName,
                    Value = x.Id.ToString()
                }).ToList());

            return new SelectList(list, "Value", "Text");
        }

        private SelectList GetCategories()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = null, Text = "Не выбрано" });
            list.AddRange(db.Categories
                .ToList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList());

            return new SelectList(list, "Value", "Text");
        }
    }
}
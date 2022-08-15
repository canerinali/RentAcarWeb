using BLL;
using BLL.Results;
using Dekorasyon.WebApp.Filters;
using Dekorasyon.WebApp.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Galeri.Web.UI.YonetimControllers
{
    public class YonetimBlogController : Controller
    {
        BlogManager blogManager = new BlogManager();
        [Auth]
        // GET: Blog
        public ActionResult Index()
        {
            return View(blogManager.List());
        }
        [Auth]
        public ActionResult Create()
        {
            return View();
        }


        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GaleriBlog post, HttpPostedFileBase PostImages)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");

            if (ModelState.IsValid)
            {
                if (PostImages != null &&
                (PostImages.ContentType == "image/jpeg" ||
                PostImages.ContentType == "image/jpg" ||
                PostImages.ContentType == "image/png"))
                {
                    string filename = $"blog_{post.Title.Trim(',', '.', ' ', '+', '-', '*', '/', '!', '?')}.{post.Id.ToString()}.{PostImages.ContentType.Split('/')[1]}";

                    PostImages.SaveAs(Server.MapPath($"~/images/{filename}"));
                    post.BlogImageFilename = filename;
                }
                blogManager.InsertBlogFoto(post);
                return RedirectToAction("Index");
            }

            BusinessLayerResult<GaleriBlog> res = blogManager.InsertBlogFoto(post);
            return View(post);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleriBlog galeriblog = blogManager.Find(x => x.Id == id);

            if (galeriblog == null)
            {
                return HttpNotFound();
            }
            return View(galeriblog);
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GaleriBlog post, HttpPostedFileBase PostImage)
        {
            CacheHelper.RemoveResimsFromCache();
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");
            if (ModelState.IsValid)
            {
                if (PostImage != null &&
                (PostImage.ContentType == "image/jpeg" ||
                PostImage.ContentType == "image/jpg" ||
                PostImage.ContentType == "image/png"))
                {
                    string filename = $"vitrin_{post.Title.Trim(',', '.', ' ', '+', '-', '*', '/', '!', '?')}.{post.Id.ToString()}.{PostImage.ContentType.Split('/')[1]}";

                    PostImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                    post.BlogImageFilename = filename;
                }

            }

            BusinessLayerResult<GaleriBlog> res = blogManager.UpdatePostFoto(post);

            if (res.Errors.Count > 0)
            {
                // Hata koduna göre özel işlem yapmamız gerekirse..
                // Hatta hata mesajına burada müdahale edilebilir.
                // (Login.cshtml'deki kısmında açıklama satırı şeklinden kurtarınız)
                //
                //if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                //{
                //    ViewBag.SetLink = "http://Home/Activate/1234-4567-78980";
                //}

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));

                return View(post);
            }
            return RedirectToAction("Index");
        }
        //[Auth]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(GaleriBlog post, HttpPostedFileBase PostImage, IEnumerable<HttpPostedFileBase> PostImageDetay, HttpPostedFileBase PostImage2)
        //{
        //    CacheHelper.RemoveResimsFromCache();
        //    ModelState.Remove("CreatedOn");
        //    ModelState.Remove("ModifiedOn");
        //    ModelState.Remove("ModifiedName");
        //    if (ModelState.IsValid)
        //    {
        //        if (PostImage != null &&
        //        (PostImage.ContentType == "image/jpeg" ||
        //        PostImage.ContentType == "image/jpg" ||
        //        PostImage.ContentType == "image/png"))
        //        {
        //            string filename = $"vitrin_{post.Title.Trim()}.{post.Id.ToString()}.{PostImage.ContentType.Split('/')[1]}";

        //            PostImage.SaveAs(Server.MapPath($"~/images/{filename}"));
        //            post.BlogImageFilename = filename;
        //        }

        //    }

        [Auth]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleriBlog post = blogManager.Find(x => x.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleriBlog post = blogManager.Find(x => x.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }


            return View(post);
        }

        [Auth]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            GaleriBlog post = blogManager.Find(x => x.Id == id);
         
            blogManager.Delete(post);
            return RedirectToAction("Index");
        }

    }








}
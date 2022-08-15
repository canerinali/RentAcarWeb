using BLL;
using BLL.Results;
using Dekorasyon.WebApp.Filters;
using Dekorasyon.WebApp.Models;
using Blog.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Dekorasyon.WebApp.YonetimControllers
{
    public class YonetimPostController : Controller
    {
        private PostManager postManager = new PostManager();
        private CategoryManager categoryManager = new CategoryManager();
        private ResimManager resimManager = new ResimManager();

        [Auth]
        public ActionResult Index()
        {
            var notes = postManager.ListQueryable().Include("Category").Include("Owner").OrderByDescending(
                x => x.ModifiedOn);

            return View(notes.ToList());
        }
        [Auth]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title");
            ViewBag.FirmaId = new SelectList(CacheHelper.GetFirmaFromCache(), "Id", "FirmaName");
            return View();
        }
        [Auth]
        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase PostImage, IEnumerable<HttpPostedFileBase> PostImageDetay, HttpPostedFileBase PostImage2)
        {
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
                    string filename = $"vitrin_{post.Title.Trim('*', '/', '!')}.{PostImage.ContentType.Split('/')[1]}";

                    PostImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                    post.PostImageFilename = filename;
                }
                if (PostImage == null)
                {
                    ViewBag.ErrorMessage = "Vitrin boş geçilemez";
                }
                if (PostImage2 != null &&
                (PostImage2.ContentType == "image/jpeg" ||
                PostImage2.ContentType == "image/jpg" ||
                PostImage2.ContentType == "image/png"))
                {
                    string filename2 = $"expertiz_{post.Title.Trim('*', '/', '!')}.{PostImage2.ContentType.Split('/')[1]}";


                    PostImage2.SaveAs(Server.MapPath($"~/img/{filename2}"));
                    post.ExpertizImage = filename2;
                }
                if (PostImage2 == null)
                {
                    ViewBag.ErrorMessage = "Expertiz boş geçilemez";
                }
                postManager.Insert(post);
                post.Owner = CurrentSession.User;
            }

            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", post.CategoryId);
            ViewBag.FirmaId = new SelectList(CacheHelper.GetFirmaFromCache(), "Id", "FirmaName", post.FirmaId);
            string cokluResims = System.IO.Path.GetExtension(Request.Files[1].FileName);
            if (cokluResims == "")
            {
                ViewBag.ErrorMessage = "Araç resimleri boş geçilemez";
            }
            if (cokluResims == null)
            {
                ViewBag.ErrorMessage = "Araç resimleri boş geçilemez";
            }
            if (cokluResims != "")
            {
                foreach (var file in PostImageDetay)
                {
                    if (file.ContentLength > 0)
                    {
                        string Dosyaadi = Guid.NewGuid().ToString().Replace("-", "");
                        string Uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                        string Tamyol = "/immages/" + Dosyaadi + Uzanti;
                        file.SaveAs(Server.MapPath(Tamyol));

                        var resim = new Resim
                        {
                            ResimUrl = Tamyol
                        };

                        resim.PostID = post.Id;
                        resimManager.Insert(resim);
                        CacheHelper.RemoveResimsFromCache();
                        resimManager.Save();
                    }

                }

                ViewBag.Resims = new SelectList(CacheHelper.GetFirmaFromCache(), "Id", "ResimUrl", post.Resims);
                return RedirectToAction("Index");
            }
            
            BusinessLayerResult<Post> res = postManager.InsertPostFoto(post);
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
            return View(post);

        }

        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postManager.Find(x => x.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", post.CategoryId);
            ViewBag.FirmaId = new SelectList(CacheHelper.GetFirmaFromCache(), "Id", "FirmaName", post.Firma);

            return View(post);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post, HttpPostedFileBase PostImage, IEnumerable<HttpPostedFileBase> PostImageDetay, HttpPostedFileBase PostImage2)
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
                    string filename = $"vitrin_{post.Title.Trim()}.{PostImage.ContentType.Split('/')[1]}";

                    PostImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                    post.PostImageFilename = filename;
                }

            }
            if (ModelState.IsValid)
            {
                if (PostImage2 != null &&
               (PostImage2.ContentType == "image/jpeg" ||
               PostImage2.ContentType == "image/jpg" ||
               PostImage2.ContentType == "image/png"))
                {
                    string filename2 = $"expertiz_{post.Title.Trim()}.{PostImage2.ContentType.Split('/')[1]}";


                    PostImage2.SaveAs(Server.MapPath($"~/img/{filename2}"));
                    post.ExpertizImage = filename2;
                }

            }


            string cokluResims = System.IO.Path.GetExtension(Request.Files[1].FileName);
            if (cokluResims != "")
            {
                foreach (var file in PostImageDetay)
                {
                    if (file.ContentLength > 0)
                    {
                        string file_name = Guid.NewGuid().ToString().Replace("-", "");
                        string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                        string Tamyol = "/immages/" + file_name + uzanti;
                        file.SaveAs(Server.MapPath(Tamyol));
                        var img = new Resim()
                        {
                            ResimUrl = Tamyol
                        };
                        img.PostID = post.Id;
                        resimManager.Insert(img);
                    }

                }


            }

            post.Owner = CurrentSession.User;
            BusinessLayerResult<Post> res = postManager.UpdatePostFoto(post);
            ViewBag.CategoryId = new SelectList(CacheHelper.GetCategoriesFromCache(), "Id", "Title", post.CategoryId);
            ViewBag.FirmaId = new SelectList(CacheHelper.GetFirmaFromCache(), "Id", "FirmaName", post.FirmaId);

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
        [Auth]
        public ActionResult ResimSil(int? id)
        {
            Resim dbResim = resimManager.Find(x => x.Id == id);
            if (dbResim == null)
            {
                throw new Exception("Resim Bulunamadı");
            }
            string filename = dbResim.ResimUrl;
            string path = Server.MapPath(filename);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            resimManager.Delete(dbResim);
            return RedirectToAction("Index", "YonetimPost");
        }
        [Auth]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = postManager.Find(x => x.Id == id);
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
            Post post = postManager.Find(x => x.Id == id);
            Resim resim = resimManager.Find(x => x.PostID == post.Id);
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
            Post post = postManager.Find(x => x.Id == id);
            Resim resim = resimManager.Find(x => x.PostID == post.Id);
            if (resim != null)
            {
                var dbDetayResim = resimManager.ListQueryable().Where(x => x.PostID == post.Id);
                string filename = resim.ResimUrl;
                string path = Server.MapPath(filename);
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
                if (dbDetayResim != null)
                {
                    foreach (var item in dbDetayResim)
                    {
                        file.Delete();
                        resimManager.Save();
                    }
                }
            }

            postManager.Delete(post);
            return RedirectToAction("Index");
        }
    }
}
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
    public class YonetimFirmaController : Controller
    {
        // GET: YonetimFirma
        private FirmaManager firmaManager = new FirmaManager();
        // GET: Category
        [Auth]
        public ActionResult Index()
        {
            return View(firmaManager.List());
        }
        [Auth]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Firma firma = firmaManager.Find(x => x.Id == id.Value);

            if (firma == null)
            {
                return HttpNotFound();
            }

            return View(firma);
        }
        [Auth]
        public ActionResult Create()
        {
            return View();
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Firma firma, HttpPostedFileBase PostImage4)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");

            if (ModelState.IsValid)
            {
                if (PostImage4 != null &&
                (PostImage4.ContentType == "image/jpeg" ||
                PostImage4.ContentType == "image/jpg" ||
                PostImage4.ContentType == "image/png"))
                {
                    string filename = $"post_{firma.FirmaName}.{firma.Id}.{PostImage4.ContentType.Split('/')[1]}";

                    PostImage4.SaveAs(Server.MapPath($"~/images/firmalar/{filename}"));
                    firma.FirmaImage = filename;
                }

                firmaManager.Insert(firma);
                return RedirectToAction("Index");
            }
            BusinessLayerResult<Firma> res = firmaManager.InsertFirmaFoto(firma);

            return View(firma);
        }
        [Auth]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Firma firma = firmaManager.Find(x => x.Id == id.Value);

            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Firma firma, HttpPostedFileBase PostImage4)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");

            if (ModelState.IsValid)
            {
                if (PostImage4 != null &&
                (PostImage4.ContentType == "image/jpeg" ||
                PostImage4.ContentType == "image/jpg" ||
                PostImage4.ContentType == "image/png"))
                {
                    string filename = $"firmalar_{firma.Id}.{PostImage4.ContentType.Split('/')[1]}";

                    PostImage4.SaveAs(Server.MapPath($"~/images/firmalar/{filename}"));
                    firma.FirmaImage = filename;
                }
                BusinessLayerResult<Firma> res = firmaManager.UpdateFirmaFoto(firma);
                Firma fir = firmaManager.Find(x => x.Id == firma.Id);
                fir.FirmaImage = firma.FirmaImage;

                firmaManager.Update(fir);

                return RedirectToAction("Index");
            }
            return View(firma);
        }
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Firma firma = firmaManager.Find(x => x.Id == id.Value);

            if (firma == null)
            {
                return HttpNotFound();
            }

            return View(firma);
        }
        [Auth]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firma firma = firmaManager.Find(x => x.Id == id);
            firmaManager.Delete(firma);

            CacheHelper.RemoveFirmaFromCache();


            return RedirectToAction("Index");
        }

    }
}
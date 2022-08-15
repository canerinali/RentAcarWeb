using BLL;
using BLL.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Galeri.Web.UI.YonetimControllers
{
    public class YonetimSSSController : Controller
    {
        SSSManager sssmanager = new SSSManager();
        // GET: YonetimSSS
        public ActionResult Index()
        {
            return View(sssmanager.List());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SSS sss)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");

               sssmanager.Insert(sss);
     

            return RedirectToAction("Index", "YonetimSSS");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SSS sss = sssmanager.Find(x => x.Id == id.Value);

            if (sss == null)
            {
                return HttpNotFound();
            }

            return View(sss);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SSS sSS = sssmanager.Find(x => x.Id == id);
            sssmanager.Delete(sSS);


            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SSS sss = sssmanager.Find(x => x.Id == id.Value);

            if (sss == null)
            {
                return HttpNotFound();
            }

            return View(sss);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SSS sss)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");

            if (ModelState.IsValid)
            {
                sssmanager.Update(sss);

                return RedirectToAction("Index");
            }
            return View(sss);
        }
    }
}
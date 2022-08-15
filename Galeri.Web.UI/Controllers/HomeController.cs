using BLL;
using BLL.Results;
using Blog.Entities;
using Dekorasyon.WebApp.Models;
using Entities;
using Galeri.Web.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Galeri.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private PostManager postManager = new PostManager();
        private ResimManager resimManager = new ResimManager();
        private AboutManager aboutManager = new AboutManager();
        private ContactManager contactManager = new ContactManager();
        private AracistekManager aracistekManager = new AracistekManager();
        private SSSManager SSSManager = new SSSManager();
        private BlogManager blogManager = new BlogManager();
        private CategoryManager categoryManager = new CategoryManager();
        // GET: Home

        public ActionResult Index()
        {
            return View(postManager.ListQueryable().Where(x => x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList());
        }
        [Route("Kategoriler")]
        public ActionResult Category()
        {
            return View();
        }
        [Route("tamam")]
        public ActionResult Tamam()
        {
            return View(postManager.ListQueryable().Where(x => x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult Okey()
        {
            return View(postManager.ListQueryable().Where(x => x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult SSS()
        {
            return View(SSSManager.List());
        }
        [Route("Arac-Listesi")]
        public ActionResult UrunListesi()
        {
            return View(postManager.ListQueryable().Where(x => x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList());
        }
        [Route("Kategori/{kategori}")]
        public ActionResult ByCategory(string kategori)
        {
            if (string.IsNullOrEmpty(kategori))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Post> posts = postManager.ListQueryable().Where(
                x => x.IsDraft == false && x.Title == kategori).OrderByDescending(
                x => x.ModifiedOn).ToList();

            return View("Tamam", posts);
        }
        [Route("Firma/{firma}")]
        public ActionResult ByFirma(int? id, string firma)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Post> posts = postManager.ListQueryable().Where(
                x => x.IsDraft == false && x.FirmaId == id).OrderByDescending(
                x => x.ModifiedOn).ToList();

            return View("UrunListesi", posts);
        }


        [Route("Arac-{arac}")]
        public ActionResult PostDetail(int id, string arac)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var posts = postManager.ListQueryable().Where(
                    x => x.IsDraft == false && x.Id == id).ToList();

            var resim = resimManager.ListQueryable().Where(x => x.PostID == id).ToList();

            var result = new ProductViewModel()
            {
                posts = posts,
                resims = resim
            };


            return View("PostDetail", result);
        }

        public ActionResult PostDetailRecent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Post> posts = postManager.ListQueryable().Where(
                x => x.IsDraft == false && x.Id == id).OrderByDescending(x => x.ModifiedOn).ToList();

            return PartialView("_PartialPostDetailRecentPost", posts);
        }
        [Route("Hakkimizda")]
        public ActionResult Hakkimizda()
        {

            var abouts = aboutManager.List();

            var sss = SSSManager.List();

            var result = new AboutListModel()
            {
                about = abouts,
                SSSes = sss
            };

            return View(result);
        }
        [Route("Iletisim")]
        public ActionResult Iletisim()
        {
            return View();
        }
        [Route("Iletisim")]
        [HttpPost]
        public ActionResult Iletisim(Contact contact)
        {
            ModelState.Remove("ModifiedOn");
            DateTime now = DateTime.Now;
            contact.ModifiedOn = now;
            contactManager.Insert(contact);
            return RedirectToAction("Iletisim", "Home");
        }
        [Route("AracAlmak")]
        public ActionResult AracAlmak()
        {
            return View();
        }
        [Route("Blog")]
        public ActionResult Blog()
        {
            return View(blogManager.List());
        }
        [HttpPost]
        [Route("uzundonemarac")]
        public ActionResult AracAlmak(Aracistek aracistek)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");
            aracistekManager.Insert(aracistek);
            return RedirectToAction("AracAlmak", "Home");
        }
        [Route("AracSatmak")]
        public ActionResult AracSatmak()
        {
            return View();
        }
        [HttpPost]
        [Route("AracSatmak")]
        public ActionResult AracSatmak(Aracistek aracistek)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");
            aracistekManager.Insert(aracistek);
            return RedirectToAction("AracSatmak", "Home");
        }
        [Route("Konsinye")]
        public ActionResult Konsinye()
        {
            return View();
        }
        [HttpPost]
        [Route("Konsinye")]
        public ActionResult Konsinye(Aracistek aracistek)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedName");
            aracistekManager.Insert(aracistek);
            return RedirectToAction("Konsinye", "Home");
        }
        [Route("BlogDetail")]
        public ActionResult BlogDetail()
        {
            return View();
        }
    }
}
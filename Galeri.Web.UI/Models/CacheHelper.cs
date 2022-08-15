using BLL;
using Blog.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Dekorasyon.WebApp.Models
{
    public class CacheHelper
    {
        public static List<Firma> GetFirmaFromCache()
        {
            var result = WebCache.Get("firma-cache");

            if (result == null)
            {
                FirmaManager firmaManager = new FirmaManager();
                result = firmaManager.List();

                WebCache.Set("firma-cache", result, 20, true);
            }

            return result;
        }
        public static List<Category> GetCategoriesFromCache()
        {
            var result = WebCache.Get("category-cache");

            if (result == null)
            {
                CategoryManager categoryManager = new CategoryManager();
                result = categoryManager.List();

                WebCache.Set("category-cache", result, 20, true);
            }

            return result;
        }
        public static List<Resim> GetResimFromCache()
        {
            var result1 = WebCache.Get("resim-cache");

            if (result1 == null)
            {
                ResimManager resimManager = new ResimManager();
                result1 = resimManager.List();

                WebCache.Set("resim-cache", result1, 20, true);
            }

            return result1;
        }
        public static List<Post> GetPostFromCache()
        {
            var result = WebCache.Get("post-cache");

            if (result == null)
            {
                PostManager postManager = new PostManager();
                result = postManager.List();

                WebCache.Set("post-cache", result, 20, true);
            }

            return result;
        }
        public static List<Contact> GetMessageFromCache()
        {
            var result = WebCache.Get("message-cache");

            if (result == null)
            {
                ContactManager contactManager  = new ContactManager();
                result = contactManager.List();

                WebCache.Set("message-cache", result, 20, true);
            }

            return result;
        }
        public static List<About> GetAboutsFromCache()
        {
            var result = WebCache.Get("about-cache");

            if (result == null)
            {
                AboutManager aboutManager = new AboutManager();
                result = aboutManager.List();

                WebCache.Set("about-cache", result, 20, true);
            }

            return result;
        }
        public static List<Home> GetHomesFromCache()
        {
            var result = WebCache.Get("home-cache");

            if (result == null)
            {
                HomeManager homeManager = new HomeManager();
                result = homeManager.List();

                WebCache.Set("home-cache", result, 20, true);
            }

            return result;
        }
        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }
        public static void RemoveResimsFromCache()
        {
            Remove("resim-cache");
        }
        public static void RemoveFirmaFromCache()
        {
            Remove("firma-cache");
        }
        public static void RemoveMessageFromCache()
        {
            Remove("message-cache");
        }
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}
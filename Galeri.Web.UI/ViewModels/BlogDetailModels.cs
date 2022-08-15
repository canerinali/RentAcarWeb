using Blog.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeri.Web.UI.ViewModels
{
    public class BlogDetailModels
    {
        public List<GaleriBlog> GaleriBlogs { get; set; }
        public List<Category> Categories { get; set; }
    }
}
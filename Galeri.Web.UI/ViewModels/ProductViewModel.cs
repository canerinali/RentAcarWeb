using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeri.Web.UI.ViewModels
{
    public class ProductViewModel
    {
        public List<Post> posts { get; set; }
        public List<Resim> resims { get; set; }
    }
}
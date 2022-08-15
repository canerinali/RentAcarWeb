using Blog.Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeri.Web.UI.ViewModels
{
    public class AboutListModel
    {
        public List<About> about { get; set; }
        public List<SSS> SSSes { get; set; }
    }
}
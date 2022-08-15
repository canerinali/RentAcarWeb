using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Resim : MyEntityBase
    {
        public string ResimUrl { get; set; }
        public int PostID { get; set; }
        public virtual Post Posts { get; set; }
    }
}

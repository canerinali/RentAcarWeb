using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Firma:MyEntityBase
    {
        public string FirmaName { get; set; }
        public string FirmaImage { get; set; }
        public virtual List<Post> Posts { get; set; }

        public Firma()
        {
            Posts = new List<Post>();
        }
    }
}

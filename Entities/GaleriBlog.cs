using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GaleriBlog : MyEntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string BlogImageFilename { get; set; }
    }
}

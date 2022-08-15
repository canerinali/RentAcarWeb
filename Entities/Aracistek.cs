using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Aracistek : MyEntityBase
    {
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Fiyat { get; set; }
        public int Km { get; set; }
        public int Telefon { get; set; }
        public string Decreption { get; set; }
    }
}

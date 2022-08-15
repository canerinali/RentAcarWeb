using Blog.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SatilanAraclar : MyEntityBase
    {
        [DisplayName("Araç Başlığı"), Required, StringLength(20000)]
        public string Title { get; set; }
        [DisplayName("Araç Metni"), Required, StringLength(2000000)]
        public string Text { get; set; }
        [DisplayName("Araç Km"), Required, StringLength(2000)]
        public string Km { get; set; }
        [DisplayName("Araç Dış Renk"), Required, StringLength(2000)]
        public string DisRenk { get; set; }
        [DisplayName("Araç İç Renk"), Required, StringLength(2000)]
        public string IcRenk { get; set; }
        [DisplayName("Araç Motor"), Required, StringLength(2000)]
        public string MotorHacmi { get; set; }
        [DisplayName("Araç Beygir"), Required, StringLength(2000)]
        public string BeygirGücü { get; set; }
        [DisplayName("Araç Çekiş"), Required, StringLength(2000)]
        public string CekisTipi { get; set; }
        [DisplayName("Araç Yakıt"), Required, StringLength(2000)]
        public string YakıtTipi { get; set; }
        [DisplayName("Araç Vites"), Required, StringLength(2000)]
        public string Vites { get; set; }
        [DisplayName("Araç Açıklama"), Required, StringLength(200000)]
        public string Description { get; set; }
        [DisplayName("Araç Fiyatı"), Required]
        public int Price { get; set; }

        public string PostImageFilename { get; set; }
        public string ExpertizImage { get; set; }

        public bool IsDraft { get; set; }

        public virtual ICollection<Resim> Resims { get; set; }
        public virtual BlogUser Owner { get; set; }
    }
}

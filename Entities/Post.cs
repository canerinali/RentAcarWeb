using Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    [Table("Posts")]
    public class Post : MyEntityBase
    {
        [DisplayName("Araç Başlığı"), Required(ErrorMessage = "This field is required."), StringLength(20000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Title { get; set; }
        [DisplayName("Araç Metni"), Required(ErrorMessage = "This field is required."), StringLength(2000000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Text { get; set; }
        [DisplayName("Kişi Sayısı"), Required(ErrorMessage = "This field is required."), StringLength(2000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string UserNumber { get; set; }
        [DisplayName("Günlük Fiyat"), Required(ErrorMessage = "This field is required.")]
        public int DayPrice { get; set; }
        [DisplayName("Araç Yakıt"), Required(ErrorMessage = "This field is required."), StringLength(2000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string YakıtTipi { get; set; }
        [DisplayName("Araç Vites"), Required(ErrorMessage = "This field is required."), StringLength(2000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Vites { get; set; }
        [DisplayName("Kasa Tipi"), Required(ErrorMessage = "This field is required."), StringLength(200000, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string CarType { get; set; }
        [DisplayName("Aylık Fiyatı"), Required(ErrorMessage = "This field is required.")]
        public int MonthlyPrice { get; set; }

        public string PostImageFilename { get; set; }
        public string ExpertizImage { get; set; }

        public bool IsDraft { get; set; }
        public int CategoryId { get; set; }
        public int FirmaId { get; set; }
        

        public virtual ICollection<Resim> Resims { get; set; }
        public virtual BlogUser Owner { get; set; }
        public virtual Category Category { get; set; }
        public virtual Firma Firma { get; set; }

      

    }
}

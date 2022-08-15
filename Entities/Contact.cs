using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("İsim"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string AdSoyad { get; set; }
        [DisplayName("Soyad"),
           StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Konu { get; set; }
        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }
        [DisplayName("Post Metni"), Required, StringLength(2000)]
        public string Text { get; set; }
        [DisplayName("Güncelleme Tarihi"), ScaffoldColumn(false), Required]
        public DateTime ModifiedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Order
    {

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "User Id ")]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Adı ")]
        public string? Adı { get; set; }


        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "SoyAdı ")]

        public string? SoyAdı { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MaxLength(11)]
        [MinLength(10)]
        [Display(Name = "Telefon ")]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Email ")]
        public string? Email { get; set; }

     





        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Yemek Kategorisi ")]
        public string? Yemek_Kategorisi { get; set; }



        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MinLength(2)]
        [MaxLength(100)]
        [Display(Name = "Yemek Adı ")]
        public string ?Yemek_Adi { get; set; }


        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Fiyat ")]

        public float fiyat { get; set; }


        //[Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Resim ")]
        public string? Resim { get; set; }

        [Display(Name = "Checked ")]
        public bool Check { get; set; }

        [Display(Name = "durum ")]

        public string durum { get; set; }
        [Display(Name = "Teslim Kodu ")]

        public string Teslim_Kodu { get; set; }

    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Restoran.ViewModels
{
    public class yemekMenusu
    {
        [Key]
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        public int id { get; set; }
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Yemek Kategorisi ")]
        public string Yemek_Kategorisi { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MinLength(2)]
        [MaxLength(100)]
        [Display(Name = "Yemek Adı ")]
        public string Yemek_Adi { get; set; }


        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Fiyat ")]

        public float fiyat { get; set; }


        //[Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Resim ")]
        public IFormFile? Resim { get; set; }


    }
}

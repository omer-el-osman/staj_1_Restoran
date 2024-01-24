using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Reservasyon
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Adı ")]
        public string ? Adı { get; set; }


        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "SoyAdı ")]

        public string? SoyAdı { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MaxLength(11)]
        [MinLength(10)]
        [Display(Name = "Telefon ")]
        public string ?Telefon { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Email ")]
        public string? Email { get; set; }

        [Display(Name = "şübe Adı ")]
        public string  ?SubeAdi { get; set; }
        [Display(Name = "Masa Numrasi ")]

        public int Masa_num { get; set; }

        [Display(Name = "tarih ")]
        public string ?tarih { get; set; }
        [Display(Name = "Durum ")]
        public string? Durum { get; set; }

    }
}

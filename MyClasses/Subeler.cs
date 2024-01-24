using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Subeler
    {
        [Key]
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "şübe Adı ")]
        public string SubeAdi { get; set; }


        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "About ")]
        public string About { get; set; }


        //[Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Resim ")]
        public string ? Resim { get; set; }

        //[Required(ErrorMessage = "Lütfen boş bırakmayın")]
        //[Display(Name = "Katigori ")]
        //public string? yemekKatigorisi { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Masalarin sayisi ")]
        public int  masalar { get; set; }
    }
}

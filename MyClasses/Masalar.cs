using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Masalar
    {
        [Key]
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "şübe Adı ")]
        public string ? SubeAdi { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Masa No ")]
        public int masalar { get; set; }

        [Display(Name = "Checked Masa ")]
        public bool Mycheck { get; set; }



    }
}

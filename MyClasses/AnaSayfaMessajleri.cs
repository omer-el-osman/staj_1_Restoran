using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class AnaSayfaMessajleri
    {



        [Key]
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        public int id { get; set; }

        //[Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Resim ")]
        public string? Resim { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Messaj ")]
        public string Messaj { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Adı ")]
        public string Adi { get; set; }




    }
}

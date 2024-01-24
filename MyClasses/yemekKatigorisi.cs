using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
	public class yemekKatigorisi
	{

        [Key]
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Yemek Katigorisi ")]
        public string Katigori { get; set; }

    }
}

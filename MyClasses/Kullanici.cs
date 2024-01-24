using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class Kullanici
    {
        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "User Id ")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Adı ")]
        public string Adı { get; set; }


        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "SoyAdı ")]

        public string SoyAdı { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [MaxLength(11)]
        [MinLength(10)]
        [Display(Name = "Telefon ")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Şifre ")]
        public string password { get; set; }

        [Required(ErrorMessage = "Lütfen boş bırakmayın")]
        [Display(Name = "Email Onaylama ")]
        public bool Email_Onaylama { get; set; }

        public string? Confirme_password { get; set; }

    }
}

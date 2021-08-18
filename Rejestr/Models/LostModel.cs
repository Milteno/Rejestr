using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rejestr.Models
{
    public class LostModel
    {
        public int Id { get; set; }
        [Display(Name= "Imie")]
        [Required(ErrorMessage = "Musisz podać imie")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Musisz podać nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Wiek")]
        [Required(ErrorMessage = "Musisz podać wiek")]
        public int Age { get; set; }
        [Display(Name = "Płeć")]
        [Required(ErrorMessage = "Musisz podać płeć")]
        public GenderEnum Gender { get; set; }
    }
    public enum GenderEnum
    {
        Mężczyzna,
        Kobieta
    }
}
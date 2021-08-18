using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class LostModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public GenderEnum Gender { get; set; }
    }
    public enum GenderEnum
    {
        Mężczyzna,
        Kobieta
    }
}

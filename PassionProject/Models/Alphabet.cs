using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProject.Models
{
    public class Alphabet
    {
        [Key]
        public int AlphabetID { get; set; }
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PassionProject.Models
{
    public class Pair
    {
        [Key]
        public int PairID { get; set; }
        public string EnglishLetter { get; set; }
        public string JapaneseLetter { get; set; }

        [ForeignKey("Alphabet")]
        public int AlphabetID { get; set; }
        public virtual Alphabet Alphabet { get; set; }
    }

    public class PairDto
    {
        public int PairID { get; set; }
        public string EnglishLetter { get; set; }
        public string JapaneseLetter { get; set; }
        public int AlphabetID { get; set; }
    }
}
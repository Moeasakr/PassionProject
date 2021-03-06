using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PassionProject.Models
{
    public class Statistic
    {
        [Key]
        public int StatisticID { get; set; }
        public int Status { get; set; }
        public string UserID { get; set; }
        public int NumberOfPairs { get; set; }
        public int? NumberOfFailedPairs { get; set; }

        [ForeignKey("Alphabet")]
        public int AlphabetID { get; set; }
        public virtual Alphabet Alphabet { get; set; }

    }
}
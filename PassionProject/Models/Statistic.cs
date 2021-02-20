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
        public string Status { get; set; }
        public bool Visibility { get; set; }
        public int UserID { get; set; }
    }
}
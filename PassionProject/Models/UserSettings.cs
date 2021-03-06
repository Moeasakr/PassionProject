using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProject.Models
{
    public class UserSettings
    {
        [Key]
        public int SettingID { get; set; }
        public string UserID { get; set; }
        public int LowSuccessRate { get; set; }
        public int NumberOfPairs { get; set; }
        public string HiraganaLetters { get; set; }
    }

    public class UserSettingsDto
    {
        public int SettingID { get; set; }
        public string UserID { get; set; }
        public int LowSuccessRate { get; set; }
        public int NumberOfPairs { get; set; }
        public string HiraganaLetters { get; set; }
    }
}
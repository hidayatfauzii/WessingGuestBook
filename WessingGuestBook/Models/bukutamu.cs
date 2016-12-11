using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WessingGuestBook.Models
{
    public class bukutamu
    {
        public int id { get; set; }
        [Required]
        public string nama { get; set; }
        public string email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime tanggal { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string pesan { get; set; }
        public string pict { get; set; }
    }
}
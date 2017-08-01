using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Surefinder.Models
{
    public class Zip
    {
        [Display(Name ="Zip")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ZipID { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surefinder.Models
{
    public class Realtor
    {
        public int RealtorID { get; set; }
        public string UserID { get; set; }
        public int? CompanyID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(25)]
        public string State { get; set; }
        [MaxLength(25)]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }

        public Company Company { get; set; }


    
    }
}

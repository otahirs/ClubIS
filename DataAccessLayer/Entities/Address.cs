using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Address : BaseEntity
    {
        [MaxLength(50)]
        public string StreetAndNumber { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }
    }
}

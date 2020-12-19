﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace clubIS.CoreLayer.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [MaxLength(50)]
        public string StreetAndNumber { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }
    }
}
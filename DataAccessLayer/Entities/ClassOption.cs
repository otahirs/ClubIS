using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ClassOption
    {
        [Key]
        public int Id { get; set; }
        public string Class { get; set; }
    }
}

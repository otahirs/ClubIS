using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class News : BaseEntity
    {
        public int? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Text { get; set; }
        public bool? Public { get; set; }
    }
}

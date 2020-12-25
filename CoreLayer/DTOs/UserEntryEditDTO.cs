using System.Collections;
using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserEntryEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ISet<SiCardDTO> SiCardNumbers { get; set; }
    }
}

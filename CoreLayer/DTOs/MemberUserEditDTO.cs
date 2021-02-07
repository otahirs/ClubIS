using ClubIS.CoreLayer.Entities;
using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class MemberUserEditDTO
    {
        public int Id { get; set; }
        public ISet<SiCardDTO> SiCards { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class EntryUserListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ISet<SiCardDTO> SiCards { get; set; }
    }
}

using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserEntryEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ISet<SiCardDTO> SiCardNumbers { get; set; }
    }
}

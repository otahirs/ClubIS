using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserEntryListDTO
    {
        public IEnumerable<UserEntryEditDTO> Supervised { get; set; }
        public UserEntryEditDTO User { get; set; }
    }
}

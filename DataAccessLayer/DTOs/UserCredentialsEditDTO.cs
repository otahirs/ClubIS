using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.DTOs
{
    class UserCredentialsEditDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Passsword { get; set; }
    }
}

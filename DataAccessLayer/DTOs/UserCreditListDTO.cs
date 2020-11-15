using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.DTOs
{
    class UserCreditListDTO
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public int CreditBalance { get; set; }
        public MemberFee MemberFee { get; set; }
        public User BilledUser { get; set; }
    }
}

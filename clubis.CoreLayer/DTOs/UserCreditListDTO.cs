using System;
using System.Collections.Generic;
using System.Text;
using clubIS.CoreLayer.Entities;

namespace clubIS.CoreLayer.DTOs
{
    public class UserCreditListDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public int CreditBalance { get; set; }
        public MemberFee MemberFee { get; set; }
        public User BilledUser { get; set; }
    }
}

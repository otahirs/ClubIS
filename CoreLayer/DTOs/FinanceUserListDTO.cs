﻿using ClubIS.CoreLayer.Entities;

namespace ClubIS.CoreLayer.DTOs
{
    public class FinanceUserListDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public int CreditBalance { get; set; }
        public MemberFee MemberFee { get; set; }
        public FinanceUserListDTO FinanceSupervisor { get; set; }
    }
}
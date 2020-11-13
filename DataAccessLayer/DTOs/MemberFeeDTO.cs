using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Enums;

namespace clubIS.DataAccessLayer.DTOs
{
    class MemberFeeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public MemberFeeType MemberFeeType { get; set; }
    }
}

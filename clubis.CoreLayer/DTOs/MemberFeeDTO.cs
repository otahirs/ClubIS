using System;
using System.Collections.Generic;
using System.Text;
using clubIS.CoreLayer.Enums;

namespace clubIS.CoreLayer.DTOs
{
    public class MemberFeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public MemberFeeType MemberFeeType { get; set; }
    }
}

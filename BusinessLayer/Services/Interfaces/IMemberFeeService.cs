using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IMemberFeeService
    {
        Task Create(MemberFeeDTO news);
        Task<MemberFeeDTO> GetById(int id);
        Task<IEnumerable<MemberFeeDTO>> GetAll();
        Task Update(MemberFeeDTO news);
        Task Delete(int id);
    }
}
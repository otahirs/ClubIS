using ClubIS.CoreLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

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

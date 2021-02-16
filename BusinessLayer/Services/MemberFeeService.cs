using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
{
    public class MemberFeeService : IMemberFeeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MemberFeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(MemberFeeDTO feeType)
        {
            var feeEntity = _mapper.Map<MemberFee>(feeType);
            await _unitOfWork.MemberFees.Add(feeEntity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.MemberFees.Remove(await _unitOfWork.MemberFees.GetById(id));
        }

        public async Task<IEnumerable<MemberFeeDTO>> GetAll()
        {
            var list = await _unitOfWork.MemberFees.GetAll();
            return _mapper.Map<IEnumerable<MemberFeeDTO>>(list);
        }

        public async Task<MemberFeeDTO> GetById(int id)
        {
            return _mapper.Map<MemberFeeDTO>(await _unitOfWork.MemberFees.GetById(id));
        }

        public async Task Update(MemberFeeDTO feeType)
        {
            var feeEntity = await _unitOfWork.MemberFees.GetById(feeType.Id);
            _mapper.Map(feeType, feeEntity);
        }
    }
}
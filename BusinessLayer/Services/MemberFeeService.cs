using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services
{
    public class MemberFeeService : IMemberFeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MemberFeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(MemberFeeDTO feeType)
        {
            MemberFee feeEntity = _mapper.Map<MemberFee>(feeType);
            await _unitOfWork.MemberFees.Add(feeEntity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.MemberFees.Remove(await _unitOfWork.MemberFees.GetById(id));
        }

        public async Task<IEnumerable<MemberFeeDTO>> GetAll()
        {
            IEnumerable<MemberFee> list = await _unitOfWork.MemberFees.GetAll();
            return _mapper.Map<IEnumerable<MemberFeeDTO>>(list);
        }

        public async Task<MemberFeeDTO> GetById(int id)
        {
            return _mapper.Map<MemberFeeDTO>(await _unitOfWork.MemberFees.GetById(id));
        }

        public async Task Update(MemberFeeDTO feeType)
        {
            MemberFee feeEntity = await _unitOfWork.MemberFees.GetById(feeType.Id);
            _mapper.Map(feeType, feeEntity);
        }
    }
}


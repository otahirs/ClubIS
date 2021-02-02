using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserFacade(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task Create(UserDTO user)
        {
            await _userService.Create(user);
            await _unitOfWork.Save();
        }

        public async Task Update(UserDTO user)
        {
            await _userService.Update(user);
            await _unitOfWork.Save();
        }

        public async Task Update(MemberUserEditDTO user)
        {
            await _userService.Update(user);
            await _unitOfWork.Save();
        }

        public async Task UpdateSupervisions(UserSupervisionsDTO user)
        {
            await _userService.UpdateSupervisions(user);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await _userService.Delete(id);
            await _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<UserListDTO>> GetAll()
        {
            return await _userService.GetAll();
        }

        public async Task<UserDTO> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        public async Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors()
        {
            return await _userService.GetAllEntriesSupervisors();
        }

        public async Task<UserEntryListDTO> GetAllEntriesSupervisorsById(int id)
        {
            return await _userService.GetAllEntriesSupervisorsById(id);


        }


        public async Task<UserSupervisionsDTO> GetUserSupervisions(int id)
        {
            return await _userService.GetUserSupervisions(id);
        }
    }
}

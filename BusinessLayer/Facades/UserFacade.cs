using clubIS.BusinessLayer.Facades.Interfaces;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.DTOs;

namespace clubIS.BusinessLayer.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public UserFacade(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task Create(UserEditDTO user)
        {
            await _userService.Create(user);
            await _unitOfWork.Save();
        }

        public async Task Update(UserEditDTO user)
        {
            await _userService.Update(user);
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

        public async Task<UserDetailDTO> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        public async Task UpdateLogin(UserCredentialsEditDTO user)
        {
            await _userService.UpdateLogin(user);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors()
        {
            return await _userService.GetAllEntriesSupervisors();
        }
    }
}

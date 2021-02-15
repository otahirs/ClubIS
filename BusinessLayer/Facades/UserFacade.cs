using AutoMapper;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Enums;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UserFacade(IUnitOfWork unitOfWork, IUserService userService, IAuthService authService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _authService = authService;
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

        public async Task<IEnumerable<UserPermListDTO>> GetAllWithPermissions()
        {
            var users = await _userService.GetAll();
            var result = new List<UserPermListDTO>();
            foreach(var user in users)
            {
                result.Add(new UserPermListDTO()
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Surname = user.Surname,
                    RegistrationNumber = user.RegistrationNumber,
                    AccountState = user.AccountState,
                    Permissions = (await _authService.GetRoles(user.Id)).Roles
                });
            }
            return result;
        }

        public async Task<UserDTO> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        public async Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors()
        {
            return await _userService.GetAllEntriesSupervisors();
        }

        public async Task<IEnumerable<EntryUserListDTO>> GetEntryUserList(int id)
        {
            var result = new List<EntryUserListDTO>();
            result.Add(await _userService.GetEntryUser(id));
            result.AddRange(await _userService.GetEntrySupervisedUsers(id));

            var userRoles = await _authService.GetRoles(id);
            if (userRoles.Roles.Any(r => r == Role.Entries || r == Role.Admin))
            {
                result.AddRange(await _userService.GetEntryAllUsers());
                result = result
                    .GroupBy(g => g.Id)
                    .Select(g => g.First())
                    .ToList(); // == distinct()
            }

            return result;
        }


        public async Task<UserSupervisionsDTO> GetUserSupervisions(int id)
        {
            return await _userService.GetUserSupervisions(id);
        }
    }
}

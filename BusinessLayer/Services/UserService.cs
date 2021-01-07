using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(UserDTO user)
        {
            User entity = _mapper.Map<User>(user);
            await _unitOfWork.Users.Add(entity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Users.Remove(await _unitOfWork.Users.GetById(id));
        }

        public async Task<IEnumerable<UserListDTO>> GetAll()
        {
            var list = await _unitOfWork.Users.GetAll();
            return _mapper.Map<IEnumerable<UserListDTO>>(list);
        }

        public async Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors()
        {
            return _mapper.Map<IEnumerable<UserEntriesSupervisedListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<UserEntryListDTO> GetAllEntriesSupervisorsById(int id)
        {
            var user = await _unitOfWork.Users.GetEntriesSupervisorsById(id);
            var supervised = new List<User_EntriesSupervisor>(user.EntriesSupervisedUsers)
                .Select(s => s.User).ToList();
            var x = _mapper.Map<IEnumerable<UserEntryEditDTO>>(supervised);
            return new UserEntryListDTO
            {
                Supervised = _mapper.Map<IEnumerable<UserEntryEditDTO>>(supervised),
                User = _mapper.Map<UserEntryEditDTO>(user)
            };
        }

        public async Task<UserDTO> GetById(int id)
        {
            return _mapper.Map<UserDTO>(await _unitOfWork.Users.GetById(id));
        }

        public async Task Update(UserDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }
    }
}

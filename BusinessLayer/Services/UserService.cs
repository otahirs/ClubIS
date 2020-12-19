using AutoMapper;
using clubIS.BusinessLayer.MapperConfig;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.DTOs;
using clubIS.CoreLayer.Entities;

namespace clubIS.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        }
        public async Task Create(UserEditDTO user)
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

        public async Task<UserDetailDTO> GetById(int id)
        {
            return _mapper.Map<UserDetailDTO>(await _unitOfWork.Users.GetById(id));
        }

        public async Task Update(UserEditDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }

        public async Task UpdateLogin(UserCredentialsEditDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }
    }
}

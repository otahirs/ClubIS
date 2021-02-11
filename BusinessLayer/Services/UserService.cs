using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            entity.Address = new Address();
            entity.Account = new FinanceAccount();
            await _unitOfWork.Users.Add(entity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Users.Remove(await _unitOfWork.Users.GetById(id));
        }

        public async Task<IEnumerable<UserListDTO>> GetAll()
        {
            IEnumerable<User> list = await _unitOfWork.Users.GetAll();
            return _mapper.Map<IEnumerable<UserListDTO>>(list);
        }

        public async Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors()
        {
            return _mapper.Map<IEnumerable<UserEntriesSupervisedListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<UserEntryListDTO> GetAllEntriesSupervisorsById(int id)
        {
            User user = await _unitOfWork.Users.GetEntriesSupervisorsById(id);
            return new UserEntryListDTO
            {
                Supervised = _mapper.Map<IEnumerable<UserEntryEditDTO>>(user.EntriesSupervisedUsers),
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

        public async Task Update(MemberUserEditDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }

        public async Task UpdateSupervisions(UserSupervisionsDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.UserId);
            userEntity.EntriesSupervisors.Clear();
            userEntity.EntriesSupervisors = _mapper.Map<ISet<User>>(
                    await _unitOfWork.Users.GetAllById(user.EntriesSupervisors.Select(u => u.Id))
                );
            userEntity.EntriesSupervisedUsers.Clear();
            userEntity.EntriesSupervisedUsers = _mapper.Map<ISet<User>>(
                    await _unitOfWork.Users.GetAllById(user.EntriesSupervisedUsers.Select(u => u.Id))
                );
            userEntity.FinanceSupervisorId = user.FinanceSupervisor?.Id;

            _unitOfWork.Users.RemoveFinanceSupervisor(user.UserId);
            foreach (UserListDTO u in user.FinanceSupervisedUsers)
            {
                User finSupervisedUser = await _unitOfWork.Users.GetById(u.Id);
                finSupervisedUser.FinanceSupervisorId = user.UserId;
            }
        }

        public async Task<UserSupervisionsDTO> GetUserSupervisions(int id)
        {
            User user = await _unitOfWork.Users.GetById(id);
            IEnumerable<User> financeSupervisedUsers = await _unitOfWork.Users.GetFinanceSupervisored(id);
            return new UserSupervisionsDTO()
            {
                UserId = id,
                EntriesSupervisors = _mapper.Map<ISet<UserListDTO>>(user.EntriesSupervisors),
                EntriesSupervisedUsers = _mapper.Map<ISet<UserListDTO>>(user.EntriesSupervisedUsers),
                FinanceSupervisor = _mapper.Map<UserListDTO>(user.FinanceSupervisor),
                FinanceSupervisedUsers = _mapper.Map<ISet<UserListDTO>>(financeSupervisedUsers)
            };
        }
    }
}

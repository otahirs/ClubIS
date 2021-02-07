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
            FinanceAccount account = new FinanceAccount();
            await _unitOfWork.Accounts.Add(account);
            await _unitOfWork.Save();
            user.AccountId = account.Id;
            User entity = _mapper.Map<User>(user);
            entity.Address = new Address();
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
            List<User> supervised = new List<User_EntriesSupervisor>(user.EntriesSupervisedUsers)
                .Select(s => s.User).ToList();
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

        public async Task Update(MemberUserEditDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }

        public async Task UpdateSupervisions(UserSupervisionsDTO user)
        {
            User userEntity = await _unitOfWork.Users.GetById(user.UserId);
            userEntity.EntriesSupervisors.Clear();
            userEntity.EntriesSupervisors = user.EntriesSupervisors
                .Select(es => new User_EntriesSupervisor()
                {
                    UserId = user.UserId,
                    EntriesSupervisorId = es.Id
                })
                .ToHashSet();
            userEntity.EntriesSupervisedUsers.Clear();
            userEntity.EntriesSupervisedUsers = user.EntriesSupervisedUsers
                .Select(esd => new User_EntriesSupervisor()
                {
                    UserId = esd.Id,
                    EntriesSupervisorId = user.UserId
                })
                .ToHashSet();
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
                EntriesSupervisors = _mapper.Map<ISet<UserListDTO>>(user.EntriesSupervisors.Select(u => u.EntriesSupervisor)),
                EntriesSupervisedUsers = _mapper.Map<ISet<UserListDTO>>(user.EntriesSupervisedUsers.Select(u => u.User)),
                FinanceSupervisor = _mapper.Map<UserListDTO>(user.FinanceSupervisor),
                FinanceSupervisedUsers = _mapper.Map<ISet<UserListDTO>>(financeSupervisedUsers)
            };
        }
    }
}

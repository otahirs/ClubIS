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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(UserDTO user)
        {
            var entity = _mapper.Map<User>(user);
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
            var list = await _unitOfWork.Users.GetAll();
            return _mapper.Map<IEnumerable<UserListDTO>>(list);
        }

        public async Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors()
        {
            return _mapper.Map<IEnumerable<UserEntriesSupervisedListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<UserDTO> GetById(int id)
        {
            return _mapper.Map<UserDTO>(await _unitOfWork.Users.GetById(id));
        }

        public async Task Update(UserDTO user)
        {
            var userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }

        public async Task Update(MemberUserEditDTO user)
        {
            var userEntity = await _unitOfWork.Users.GetById(user.Id);
            _mapper.Map(user, userEntity);
        }

        public async Task UpdateSupervisions(UserSupervisionsDTO userSupervisions)
        {
            var userEntity = await _unitOfWork.Users.GetById(userSupervisions.UserId);
            userEntity.UnderSupervision.Clear();
            userEntity.SupervisedBy.Clear();

            var supervised = userSupervisions.EntriesSupervisedUsers.Select(ent => ent.Id)
                    .Union(userSupervisions.FinanceSupervisedUsers.Select(fin => fin.Id));

            userEntity.UnderSupervision = supervised.Select(sup => new Supervision
            {
                SupervisorUserId = userSupervisions.UserId,
                SupervisedUserId = sup,
                IsEntrySupervisionEnabled = userSupervisions.EntriesSupervisedUsers.Any(ent => ent.Id == sup),
                IsFinanceSupervisionEnabled = userSupervisions.FinanceSupervisedUsers.Any(fin => fin.Id == sup),
            }).ToList();
            
            var supervisors = userSupervisions.EntriesSupervisors.Select(ent => ent.Id)
                .Union(userSupervisions.FinanceSupervisors.Select(fin => fin.Id));
            
           userEntity.SupervisedBy = supervisors.Select(sup => new Supervision
           {
               SupervisorUserId = sup,
               SupervisedUserId = userSupervisions.UserId,
               IsEntrySupervisionEnabled = userSupervisions.EntriesSupervisors.Any(ent => ent.Id == sup),
               IsFinanceSupervisionEnabled = userSupervisions.FinanceSupervisors.Any(fin => fin.Id == sup),
           }).ToList();
        }

        public async Task<UserSupervisionsDTO> GetUserSupervisions(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            user.UnderSupervision ??= new List<Supervision>();
            user.SupervisedBy ??= new List<Supervision>();

            return new UserSupervisionsDTO
            {
                UserId = id,
                EntriesSupervisors = _mapper.Map<List<UserListDTO>>(await _unitOfWork.Users.GetAllById(
                    user.SupervisedBy
                            .Where(s => s.IsEntrySupervisionEnabled)
                            .Select(s => s.SupervisorUserId))),
                EntriesSupervisedUsers = _mapper.Map<List<UserListDTO>>(await _unitOfWork.Users.GetAllById(
                    user.UnderSupervision
                        .Where(s => s.IsEntrySupervisionEnabled)
                        .Select(s => s.SupervisedUserId))),
                FinanceSupervisors = _mapper.Map<List<UserListDTO>>(await _unitOfWork.Users.GetAllById(
                    user.SupervisedBy
                        .Where(s => s.IsFinanceSupervisionEnabled)
                        .Select(s => s.SupervisorUserId))),
                FinanceSupervisedUsers = _mapper.Map<List<UserListDTO>>(await _unitOfWork.Users.GetAllById(
                    user.UnderSupervision
                        .Where(s => s.IsFinanceSupervisionEnabled)
                        .Select(s => s.SupervisedUserId)))
            };
        }

        public async Task<EntryUserListDTO> GetEntryUser(int id)
        {
            return _mapper.Map<EntryUserListDTO>(await _unitOfWork.Users.GetById(id));
        }

        public async Task<IEnumerable<EntryUserListDTO>> GetUsersUnderEntrySupervision(int userId)
        {
            var userEntity = await _unitOfWork.Users.GetById(userId);
            return _mapper.Map<IEnumerable<EntryUserListDTO>>( 
                await _unitOfWork.Users.GetAllById(
                userEntity.UnderSupervision.Where(u => u.IsEntrySupervisionEnabled)
                    .Select(p => p.SupervisedUserId)));
        }

        public async Task<IEnumerable<EntryUserListDTO>> GetEntryAllUsers()
        {
            return _mapper.Map<IEnumerable<EntryUserListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<IEnumerable<UserListDTO>> GetUsersUnderFinanceSupervision(int userId)
        {
            var userEntity = await _unitOfWork.Users.GetById(userId);
            return _mapper.Map<IEnumerable<UserListDTO>>(await _unitOfWork.Users.GetAllById(
                userEntity.UnderSupervision.Where(sp => sp.IsFinanceSupervisionEnabled)
                    .Select(s => s.SupervisedUserId)));
        }
    }
}
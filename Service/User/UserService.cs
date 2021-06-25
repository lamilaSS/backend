using System.Threading.Tasks;
using AutoMapper;
using mcq_backend.Dataset.User;
using mcq_backend.Helper.Exception;
using mcq_backend.Repository;
using mcq_backend.Repository.User;
using Microsoft.AspNetCore.Authorization;

namespace mcq_backend.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDataset> GetById(string userId)
        {
            //TODO: user get self info and user get others info
            var user = await _unitOfWork.UserRepository.GetById(userId);
            return _mapper.Map<UserDataset>(user);
        }

        public async Task<UserDataset> UpdateUser(string userId, UserUpdateDataset userUpdateDataset)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId);
            user = _mapper.Map<Model.User>(userUpdateDataset);
            _unitOfWork.UserRepository.Update(user);
            if (await _unitOfWork.SaveAsync() <= 0) throw new CommonException("Saving update failed.");
            return _mapper.Map<UserDataset>(user);
        }
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportManagement.Data.IRepositories;
using SportManagement.Domain.Entities;
using SportManagement.Service.DTOs.Users;
using SportManagement.Service.Exceptions;
using SportManagement.Service.Interfaces;
using SportManagement.Service.Validators;

namespace SportManagement.Service.Services
{
    public class UserService : IUserInterface
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> userRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }


        public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            UserValidator.ValidateUser(dto);

            var existingUser = await userRepository.SelectAll()
                .FirstOrDefaultAsync(u => u.UserName == dto.UserName);

            if (existingUser != null)
                throw new SportManagementException(409, "This username is already taken!");

            var newUser = mapper.Map<User>(dto);
            await userRepository.InsertAsync(newUser);

            return mapper.Map<UserForResultDto>(newUser);
        }

        public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
        {
            UserValidator.ValidateUser(mapper.Map<UserForCreationDto>(dto));

            var user = await userRepository.SelectByIdAsync(id);
            if (user == null)
                throw new SportManagementException(404, "User not found!");

            var existingUser = await userRepository.SelectAll()
                .FirstOrDefaultAsync(u => u.UserName == dto.UserName);

            if (existingUser != null && existingUser.Id != id)
                throw new SportManagementException(409, "A user with this username already exists!");

            var updatedUser = mapper.Map(dto, user);
            await userRepository.UpdateAsync(updatedUser);

            return mapper.Map<UserForResultDto>(updatedUser);
        }

        public async Task<bool> RemoveAsync(long id)
        {
            var user = await userRepository.SelectByIdAsync(id);
            if (user == null)
                throw new SportManagementException(404, "User not found!");

            await userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync()
        {
            var users = await userRepository.SelectAll()
                .AsNoTracking()
                .ToListAsync();

            return mapper.Map<IEnumerable<UserForResultDto>>(users);
        }

        public async Task<UserForResultDto> RetrieveByIdAsync(long id)
        {
            var user = await userRepository.SelectByIdAsync(id);
            if (user == null)
                throw new SportManagementException(404, "User not found!");

            return mapper.Map<UserForResultDto>(user);
        }
    }
}

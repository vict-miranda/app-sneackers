using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services.Interfaces;
using AppSneackers.Domain.Entities;
using AppSneackers.Domain.Repositories;
using AutoMapper;

namespace AppSneackers.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<UserDto> GetSneackersByUserId(int userId)
        {
            var user = (await _userRepository.GetAsync(new CancellationToken(),
                        d => d.Id == userId,
                        includeProperties: "Sneackers")).FirstOrDefault();

            return _mapper.Map<User, UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<UserDto> CreateUser(CreateUserDto userDto)
        {
            User entity = User.CreateNew(userDto.FirstName, userDto.LastName, userDto.Email, userDto.Password);
            await _userRepository.Create(entity);

            return _mapper.Map<User, UserDto>(entity);
        }

        /// <inheritdoc/>
        public async Task<UserDto> AddSneacker(int userId, CreateSneackerDto snickerDto)
        {
            var user = await _userRepository.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            user.AddSneacker(snickerDto.Name, snickerDto.Brand, snickerDto.Size, snickerDto.Price, snickerDto.Year, snickerDto.Rate);
            await _userRepository.Update(userId, user);

            return _mapper.Map<User, UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<UserDto> UpdateSneacker(int sneackerId, UpdateSneackerDto snickerDto)
        {
            var user = (await _userRepository.GetAsync(new CancellationToken(),
                        d => d.Id == snickerDto.UserId,
                        includeProperties: "Sneackers")).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (user.Sneackers != null && user.Sneackers.Count > 0)
            {
                user.UpdateSneacker(sneackerId, snickerDto.Name, snickerDto.Brand, snickerDto.Size, snickerDto.Price, snickerDto.Year, snickerDto.Rate);
                await _userRepository.Update(snickerDto.UserId, user);
            }            

            return _mapper.Map<User, UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<UserDto> RemoveSneacker(int userId, int sneackerId)
        {
            var user = (await _userRepository.GetAsync(new CancellationToken(),
                        d => d.Id == userId,
                        includeProperties: "Sneackers")).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            if (user.Sneackers != null && user.Sneackers.Count > 0)
            {
                user.RemoveSneacker(sneackerId);
                await _userRepository.Update(userId, user);
            }

            return _mapper.Map<User, UserDto>(user);
        }

    }
}

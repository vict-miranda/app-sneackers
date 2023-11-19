﻿using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services.Interfaces;
using AppSneackers.Domain.Entities;
using AppSneackers.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            var user = await _userRepository.GetUserById(userId);

            return _mapper.Map<User, UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<(UserDto, ServiceResult)> CreateUser(CreateUserDto userDto)
        {
            var user = _userRepository.GetAll().Where(x => x.Email.ToLower() == userDto.Email.ToLower()).FirstOrDefault();
            if (user != null)
            {
                return (null, new ServiceResult("Email is already registered"));
            }

            ServiceResult serviceResult = new ServiceResult();
            User entity = User.CreateNew(
                userDto.FirstName, 
                userDto.LastName, 
                userDto.Email, 
                BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            );

            if (!entity.ValidateModel().IsValid)
            {
                return (null, new ServiceResult(entity.ValidateModel().Errors));
            }

            await _userRepository.Create(entity);

            return (_mapper.Map<User, UserDto>(entity), serviceResult);
        }

        /// <inheritdoc/>
        public async Task<UserDto> AddSneacker(int userId, CreateSneackerDto snickerDto)
        {
            ServiceResult serviceResult = new ServiceResult();
            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                return null;
            }

            user.AddSneacker(snickerDto.Name, snickerDto.Brand, snickerDto.Size, snickerDto.Price, snickerDto.Year, snickerDto.Rate);
            await _userRepository.Update(userId, user);

            return _mapper.Map<User, UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<UserDto> UpdateSneacker(int sneackerId, UpdateSneackerDto snickerDto)
        {
            var user = await _userRepository.GetUserById(snickerDto.UserId); 

            if (user == null)
            {
                return null;
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
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                return null;
            }

            if (user.Sneackers != null && user.Sneackers.Count > 0)
            {
                user.RemoveSneacker(sneackerId);
                await _userRepository.Update(userId, user);
            }

            return _mapper.Map<User, UserDto>(user);
        }

        //public async Task<UserDto> GetUserById(int id)
        //{
        //    var entity = await _userRepository.GetById(id);
        //    return _mapper.Map<UserDto>(entity);
        //}

        public async Task<UserDto> ValidateUserCredentials(string email, string password)
        {
            var user = await _userRepository.GetAll().Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (verified)
                    return _mapper.Map<UserDto>(user);
            }
            return null;
        }

    }
}

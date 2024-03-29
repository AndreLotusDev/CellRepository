﻿using AutoMapper;
using CellRepository.ApplicationModels;
using CellRepository.Domain.Entities;
using CellRepository.Services.Areas.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationService.Areas.User
{
    public class UserLoginApplicationService : IUserApplicationService
    {
        private readonly IUserLoginDomainService _userDs;
        private readonly IMapper _mapper;
        public UserLoginApplicationService(IUserLoginDomainService userDs, IMapper mapper)
        {
            _userDs = userDs;
            _mapper = mapper;
        }

        public async Task<(UserLoginDto user, string message, bool status)> LoginAsync(UserLoginDto userLoginDto)
        {
            var modelToRecover = _mapper.Map<UserLoginEntity>(userLoginDto);

            (var user, var message, var status)  = await _userDs.LoginAsync(modelToRecover);

            return (_mapper.Map<UserLoginDto>(user), message, status);
        }

        public async Task<(string message, bool status)> RegisterANewUserAsync(UserLoginDto userToRegister)
        {
            var modelToPersistInDb = _mapper.Map<UserLoginEntity>(userToRegister);

            return await _userDs.RegisterANewUserAsync(modelToPersistInDb);
        }
    }
}

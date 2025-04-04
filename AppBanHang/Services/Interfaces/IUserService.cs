﻿using AppBanHang.Models;
using System;
using System.Threading.Tasks;

namespace AppBanHang.Services.Interfaces
{
    public interface IUserService
    {
        delegate void ChangeUserHandler(User user);
        User? CurrentUser { get; }
        event ChangeUserHandler? CurrentUserChanged;
        User Login(string userName, string password);
        Task<User> AddUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User?> GetUserByUserNameAsync(string username);
        Task<User> LoginAsync(string userName, string password);
    }
}

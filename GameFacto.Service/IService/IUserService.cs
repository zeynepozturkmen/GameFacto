using GameFacto.Contract.RequestModel;
using GameFacto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.IService
{
    public interface IUserService
    {
        Task<User> GetAdminUser();
        Task<User> AddUserAsync(UserModel model);
        //Task<User> UpdateUserAsync(UserModel model);
        //Task<User> DeleteUserAsync(Guid UserId);
        //bool IsExitsUser(Guid UserId, string Email);
        Task<int> AddRoles();
        User GetUserByEmail(string Email);
    }
}

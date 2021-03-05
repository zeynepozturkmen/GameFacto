using GameFacto.Contract.RequestModel;
using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.Service.Service
{
  
        public class UserService : IUserService
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<AppRole> _roleManager;
    
            public UserService(UserManager<User> userManager, RoleManager<AppRole> roleManager)
            {
                _userManager = userManager;             
                _roleManager = roleManager;
            }

            public async Task<User> GetAdminUser()
            {
                var user = await _userManager.FindByNameAsync("admin");

                if (user != null)
                {
                    return user;
                }
                return null;
            }

            public async Task<int> AddRoles()
            {

                List<string> roleName = new List<string>() { "Admin", "User" };
                List<string> roleDescription = new List<string>() { "Admin", "User" };

                if (!_roleManager.Roles.Any())
                {
                    for (int i = 0; i < roleName.Count(); i++)
                    {
                        AppRole role = new AppRole();
                        role.Name = roleName[i];
                        role.RoleDescription = roleDescription[i];
                        IdentityResult result = await _roleManager.CreateAsync(role);

                        if (result.Succeeded)
                        {
                            continue;
                        }

                    }
                }

                return 1;

            }

        public async Task<User> AddUserAsync(UserModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            return user;
        }

        //public async Task<User> UpdateUserAsync(UserModel model)
        //{
        //    var user = await _userManager.Users.Where(x => x.Id == model.Id && !x.IsDeleted).Include(x => x.UserProjects).FirstOrDefaultAsync();

        //    if (user != null)
        //    {
        //        user = _mapper.Map(model, user);
        //        user.UpdateUserId = model.UserId.Value;
        //        user.UserName = model.Email;
        //        await _userManager.UpdateAsync(user);


        //        var removeProjects = await _uow.UserProjectRepository.Where(x => x.UserId == model.Id).ToListAsync();
        //        _uow.UserProjectRepository.RemoveRange(removeProjects);
        //        await _uow.CommitAsync();

        //        if (model.ProjectIdList != null && model.ProjectIdList.Count() > 0)
        //        {
        //            foreach (var item in model.ProjectIdList)
        //            {
        //                var project = await _uow.Project.Where(x => x.Id == item).FirstOrDefaultAsync();

        //                if (project != null)
        //                {
        //                    var userProject = new UserProject();
        //                    userProject.ProjectId = project.Id;
        //                    userProject.UserId = user.Id;
        //                    userProject.RecordUserId = model.UserId.Value;

        //                    await _uow.UserProjectRepository.AddAsync(userProject);
        //                    await _uow.CommitAsync();
        //                }

        //            }
        //        }
        //    }


        //    return user;

        //}

        public async Task<User> DeleteUserAsync(int UserId)
            {
                var user = await _userManager.Users.Where(x => x.Id == UserId && !x.IsDeleted).FirstOrDefaultAsync();

                if (user != null)
                {
                    user.IsDeleted = true;
                    user.Email = null;
                    user.NormalizedEmail = null;
            
                }

                return user;
            }


            public User GetUserByEmail(string Email)
            {
                var user = _userManager.Users.Where(x => !x.IsDeleted && x.Email == Email).FirstOrDefault();

                return user;
            }

        }
    
}

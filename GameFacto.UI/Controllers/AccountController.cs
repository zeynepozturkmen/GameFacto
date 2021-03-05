using GameFacto.Contract.RequestModel;
using GameFacto.Core.Entities;
using GameFacto.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFacto.UI.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;
        private static Random random = new Random();


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<AppRole> roleManager, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var roleCount = await _userService.AddRoles();
            var user = await _userService.GetAdminUser();

            if (user is null)
            {
                User newUser = new User
                {
                    UserName = "admin",
                    FullName = "Admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, "12345");
                var model = new UserModel();
                model.Email = newUser.Email;            

                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("Admin");

                    if (role != null)
                    {
                        await _userManager.AddToRoleAsync(newUser, role.Name);
                    }

                    //model.UserId = User.Identity.GetUserId();
                    var userProject = await _userService.AddUserAsync(model);
                }
            }

            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {

            User user = await _userManager.FindByEmailAsync(model.UserName);
            if (user != null)
            {
                //İlgili kullanıcıya dair önceden oluşturulmuş bir Cookie varsa siliyoruz.
                await _signInManager.SignOutAsync();

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.Persistent, model.Lock);

                //Lock:belirli bir sürede (mesela 5 dk) kullanıcı yanlıs girerse hesabı bloklasın  mı(true,false)
                if (result.Succeeded)
                {
                    //HttpContext.Session.SetString("FullName", user.FullName);
                    var key = "FullName";
                    var str = JsonConvert.SerializeObject(user.FullName);
                    _httpContextAccessor.HttpContext.Session.SetString(key, str);

                    var userRole = await _userManager.GetRolesAsync(user);


                    var keyRole = "UserRole";
                    var strRole = JsonConvert.SerializeObject(userRole.FirstOrDefault());
                    _httpContextAccessor.HttpContext.Session.SetString(keyRole, strRole);

                    return RedirectToAction("Index", "Home");
                }
              
            }

            return RedirectToAction("Login", "Account");

        }

        //[AllowAnonymous]
        //public IActionResult PasswordReset()
        //{


        //    return View();
        //}

        //[AllowAnonymous]
        //[FormValidator]
        //[HttpPost]
        //public async Task<IActionResult> PasswordReset(PasswordResetModel model)
        //{
        //    var findUserByEmail = _userService.GetUserByEmail(model.Email);

        //    if (findUserByEmail != null)
        //    {

        //        var newPassword = RandomString(5);

        //        var code = await _userManager.GeneratePasswordResetTokenAsync(findUserByEmail);
        //        var result = await _userManager.ResetPasswordAsync(findUserByEmail, code, newPassword);
        //        if (result.Succeeded)
        //        {
        //            PasswordResetMetod(findUserByEmail, newPassword);
        //            return FormResult.CreateSuccessResult("Şifre başarıyla sıfırlandı");
        //        }
        //        else
        //        {
        //            return FormResult.CreateErrorResult("Şifre sıfırlanırken hata oluştu");
        //        }

        //    }


        //    return FormResult.CreateErrorResult("Lütfen geçerli email giriniz");
        //}


        //public IActionResult AccessDenied()
        //{

        //    return View();
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login", "Account");

        //}

        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UserList()
        //{
        //    var userId = User.Identity.GetUserId();

        //    var userList = await _userManager.Users.Where(x => !x.IsDeleted && x.Id != userId).ToListAsync();
        //    return View(userList);
        //}

        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> AddUser()
        //{
        //    var projectList = await _projectService.GetAllProjectAsync();
        //    var model = new UserModel();

        //    if (projectList != null && projectList.Count() > 0)
        //    {
        //        model.ProjectList = projectList.Select(item => _mapper.Map<ProjectGetAllResponseModel>(item)).ToList();

        //    }

        //    List<AppRole> allRoles = _roleManager.Roles.ToList();

        //    if (allRoles != null && allRoles.Count() > 0)
        //    {
        //        model.RoleList = allRoles.Select(item => _mapper.Map<RoleAssignViewModel>(item)).ToList();

        //    }

        //    return View(model);
        //}

        //[Authorize(Roles = "Admin")]
        //[FormValidator]
        //[HttpPost]
        //public async Task<IActionResult> AddUser(UserModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);

        //    if (user == null || user.IsDeleted)
        //    {

        //        User newUser = new User
        //        {
        //            UserName = model.Email,
        //            Email = model.Email,
        //            PhoneNumber = model.PhoneNumber,
        //            Tc = model.Tc,
        //            FullName = model.FullName
        //        };

        //        IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);
        //        if (result.Succeeded)
        //        {
        //            model.UserId = User.Identity.GetUserId();

        //            var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());

        //            if (role != null)
        //            {
        //                await _userManager.AddToRoleAsync(newUser, role.Name);
        //            }


        //            var userProject = await _userService.AddUserAsync(model);
        //            if (userProject != null)
        //            {
        //                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
        //                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token = token }, Request.Scheme);

        //                string FilePath = _webHostEnvironment.WebRootPath + @"\HtmlMailTemplate\\EmailTemplate.html";
        //                StreamReader str = new StreamReader(FilePath);
        //                string MailText = str.ReadToEnd();
        //                str.Close();
        //                MailText = MailText.Replace("#Link#", confirmationLink);
        //                MailText = MailText.Replace("#FullName#", newUser.FullName);
        //                MailText = MailText.Replace("#Message1#", "Hesabınız oluşturuldu.Hesabınıza aşagıdaki bilgilerle giriş sağlayabilirsiniz.Aktif etmek için bağlantı adresine tıklayınız.");

        //                MailText = MailText.Replace("#Message2#", @$"Kullanıcı Adı: {newUser.Email}");

        //                MailText = MailText.Replace("#Message3#", @$"Şifre: {model.Password} ");

        //                var email = new MailRequestEntity
        //                {
        //                    Subject = "Aktivasyon",
        //                    Body = MailText,
        //                    FromEmail = "bilgi@farmakod.com",
        //                    Host = "mail.farmakod.com",
        //                    Port = 587,
        //                    Password = "FArm010203##"
        //                };
        //                email.ToEmail = new List<string>();
        //                email.ToEmail.Add(newUser.Email);
        //                var mailResult = await _emailService.SendMail(email);

        //                if (mailResult != "")
        //                {
        //                    return FormResult.CreateErrorResult(mailResult);
        //                }

        //                return FormResult.CreateSuccessResult("Sistem kullanıcısı eklendi");
        //            }
        //            else
        //            {
        //                return FormResult.CreateErrorResult("Kullanıcıya projeler atanırken hata oluştu");
        //            }
        //        }
        //        else
        //        {
        //            return FormResult.CreateErrorResult("Hata oluştu");
        //        }

        //    }

        //    return FormResult.CreateErrorResult("Böyle bir kullanıcı var");

        //}

        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    await _signInManager.SignOutAsync();
        //    if (userId == null || token == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
        //        return View("NotFound");
        //    }
        //    var result = await _userManager.ConfirmEmailAsync(user, token);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }
        //    return RedirectToAction("NotFoundPage", "Home");
        //}


        //public static string RandomString(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}


        //public void PasswordResetMetod(User model, string newPassword)
        //{

        //    var token = _userManager.GenerateEmailConfirmationTokenAsync(model);
        //    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = model.Id, token = token }, Request.Scheme);

        //    string FilePath = _webHostEnvironment.WebRootPath + @"\HtmlMailTemplate\\EmailTemplate.html";

        //    StreamReader str = new StreamReader(FilePath);
        //    string MailText = str.ReadToEnd();
        //    str.Close();
        //    MailText = MailText.Replace("#Link#", confirmationLink);
        //    MailText = MailText.Replace("#FullName#", model.FullName);
        //    MailText = MailText.Replace("#Message1#", "Kullanıcı bilgileriniz aşağıda bulunmaktadır");

        //    MailText = MailText.Replace("#Message2#", @$"Kullanıcı Adı: {model.Email}");

        //    MailText = MailText.Replace("#Message3#", @$"Şifre: {newPassword}");

        //    var email = new MailRequestEntity
        //    {
        //        Subject = "Kullanıcı bilgileri",
        //        Body = MailText,
        //        FromEmail = "bilgi@farmakod.com",
        //        Host = "mail.farmakod.com",
        //        Port = 587,
        //        Password = "FArm010203##"
        //    };
        //    email.ToEmail = new List<string>();
        //    email.ToEmail.Add(model.Email);
        //    _emailService.SendMail(email);


        //}

    }

}

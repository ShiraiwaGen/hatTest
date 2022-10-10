// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Dairiten.Data;
using Dairiten.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Dairiten.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly IUserEmailStore<AppUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<AppUser> userManager,
            IUserStore<AppUser> userStore,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "入力してください。")]
            [StringLength(20, ErrorMessage = "{0}は {2} 文字から {1} 文字以内で入力してください。", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "パスワード")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "パスワードをもう一度入力してください")]
            [Compare("Password", ErrorMessage = "パスワードと再入力パスワードの内容が異なります。")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "入力してください。")]
            [Display(Name = "募集人コード")]
            [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "半角英数字のみ入力できます")]
            [StringLength(50, ErrorMessage = "募集人コードは５０文字以内でお願いします")]
            public string employee_code { get; set; }

            [Required(ErrorMessage = "入力してください。")]
            [Display(Name = "代理店キー")]
            public int m_dairiten_id { get; set; }

            [Required(ErrorMessage = "入力してください。")]
            [Display(Name = "社員_姓")]
            [StringLength(50, ErrorMessage = "社員_姓は５０文字以内でお願いします")]
            public string employee_sei { get; set; }

            [Required(ErrorMessage = "入力してください。")]
            [Display(Name = "社員_名")]
            [StringLength(50, ErrorMessage = "社員_名は５０文字以内でお願いします")]
            public string employee_mei { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            // 入力内容チェック
            var appUser = await _userManager.FindByNameAsync(Input.employee_code);
            // 募集人コード重複チェック
            if (appUser != null)
            {
                ModelState.AddModelError(string.Empty, "この募集人コードは既に登録されています。");
                return Page();
            }

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    m_dairiten_id = Input.m_dairiten_id,
                    employee_code = Input.employee_code,
                    employee_sei = Input.employee_sei,
                    employee_mei = Input.employee_mei,
                    EmailConfirmed = true,
                };

                await _userStore.SetUserNameAsync(user, Input.employee_code, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }

        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<AppUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AppUser>)_userStore;
        }
    }
}

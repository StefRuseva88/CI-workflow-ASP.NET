using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Services.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HouseRentingSystem.Web.Areas.Admin;
using static HouseRentingSystem.Services.Data.DataConstants.User;
using Microsoft.Extensions.Caching.Memory;

namespace HouseRentingSystem.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache cache;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMemoryCache cache)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.cache = cache; 
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [StringLength(UserFirstNameMaxLength, 
                MinimumLength = UserFirstNameMinLength)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [StringLength(UserLastNameMaxLength,
                MinimumLength = UserLastNameMinLength)]
            public string LastName { get; set; }

            [Required]
            [StringLength(100, 
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", 
                MinimumLength = 5)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", 
                ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName
                };

                var result = await this.userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    // Clear the users cache for the "All Users" page
                    this.cache.Remove(AdminConstants.UsersCacheKey);
                    return LocalRedirect("~/Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}

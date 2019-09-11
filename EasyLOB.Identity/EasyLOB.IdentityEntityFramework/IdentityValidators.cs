using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace EasyLOB.Identity
{
    public class CustomPasswordValidator : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            IdentityResult result = await base.ValidateAsync(password);

            //if (password.Contains("12345"))
            //{
            //    var errors = result.Errors.ToList();
            //    errors.Add("Passwords cannot contain numeric sequences");
            //    result = new IdentityResult(errors);
            //}

            return result;
        }
    }

    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager manager)
            : base(manager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            //if (!user.Email.ToLower().EndsWith("@example.com"))
            //{
            //    var errors = result.Errors.ToList();
            //    errors.Add("Only example.com email addresses are allowed");
            //    result = new IdentityResult(errors);
            //}

            return result;
        }
    }
}
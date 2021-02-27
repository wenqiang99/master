using Abp.Authorization;
using MyPractice.Authorization.Roles;
using MyPractice.Authorization.Users;

namespace MyPractice.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

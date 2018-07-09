using Abp.Authorization;
using DomainDrivenProject.Authorization.Roles;
using DomainDrivenProject.Authorization.Users;

namespace DomainDrivenProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

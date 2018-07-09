using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DomainDrivenProject.Roles.Dto;
using DomainDrivenProject.Users.Dto;

namespace DomainDrivenProject.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}

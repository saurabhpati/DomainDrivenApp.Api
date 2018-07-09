using System.Threading.Tasks;
using DomainDrivenProject.Configuration.Dto;

namespace DomainDrivenProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

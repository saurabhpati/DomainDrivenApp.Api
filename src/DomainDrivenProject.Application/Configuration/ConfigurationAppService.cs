using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DomainDrivenProject.Configuration.Dto;

namespace DomainDrivenProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DomainDrivenProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

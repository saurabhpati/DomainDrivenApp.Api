using System.Threading.Tasks;
using DomainDrivenProject.Authorization.Users;

namespace DomainDrivenProject.Events
{
    public interface IEventRegistrationPolicy
    {
        Task<bool> CheckRegistrationAttemptAsync(Event @event, User user);
    }
}
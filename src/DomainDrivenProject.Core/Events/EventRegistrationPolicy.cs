using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Timing;
using DomainDrivenProject.Authorization.Users;
using DomainDrivenProject.Configuration;

namespace DomainDrivenProject.Events
{
    public class EventRegistrationPolicy : IEventRegistrationPolicy
    {
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;
        private readonly ISettingManager _settingManager;

        public EventRegistrationPolicy(
            IRepository<EventRegistration> eventRegistrationRepository,
            ISettingManager settingManager)
        {
            _eventRegistrationRepository = eventRegistrationRepository;
            _settingManager = settingManager;
        }

        public async Task<bool> CheckRegistrationAttemptAsync(Event @event, User user)
        {
            return await CheckEventRegistrationFrequencyAsync(user) && CheckEventDate(@event);
        }

        private static bool CheckEventDate(Event @event)
        {
            return !@event.IsInPast();
        }

        private async Task<bool> CheckEventRegistrationFrequencyAsync(User user)
        {
            var oneMonthAgo = Clock.Now.AddDays(-30);
            int allowed = await _settingManager.GetSettingValueAsync<int>(AppSettingNames.MaxAllowedEventRegistrationInLast30DaysPerUser);
            int regCount = await _eventRegistrationRepository.CountAsync(reg => reg.UserId == user.Id && reg.CreationTime >= oneMonthAgo);
            return !(regCount >= allowed && allowed > 0);
        }
    }
}

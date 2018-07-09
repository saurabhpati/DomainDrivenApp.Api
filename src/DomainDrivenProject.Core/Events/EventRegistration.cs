using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.UI;
using DomainDrivenProject.Authorization.Users;

namespace DomainDrivenProject.Events
{
    [Table("AppEventRegistrations")]
    public class EventRegistration : CreationAuditedEntity, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; protected set; }
        public Guid EventId { get; protected set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual long UserId { get; set; }

        protected EventRegistration()
        {
        }

        public static async Task<EventRegistration> CreateAsync(Event @event, User user, IEventRegistrationPolicy registrationPolicy)
        {
            if (!await registrationPolicy.CheckRegistrationAttemptAsync(@event, user))
            {
                return null;
            }

            return new EventRegistration()
            {
                TenantId = @event.TenantId,
                EventId = @event.Id,
                Event = @event,
                UserId = user.Id,
                User = user
            };
        }

        public async Task CancelAsync(IRepository<EventRegistration> repository)
        {
            if (Event.IsInPast())
            {
                throw new UserFriendlyException("Cannot cancel past events");
            }

            await repository.DeleteAsync(this);
        }
    }
}
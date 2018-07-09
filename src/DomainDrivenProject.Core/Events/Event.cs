using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;

namespace DomainDrivenProject.Events
{
    [Table("AppEvents")]
    public class Event : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(128)]
        public virtual string Title { get; protected set; }

        [StringLength(2048)]
        public virtual string Description { get; protected set; }

        public virtual DateTime Date { get; protected set; }

        public virtual bool IsCancelled { get; protected set; }

        [Range(0, int.MaxValue)]
        public virtual int MaxRegistrationCount { get; protected set; }

        [ForeignKey("EventId")]
        public virtual ICollection<EventRegistration> Registrations { get; protected set; }

        protected Event()
        {
        }

        public static Event Create(int tenantId, string title, DateTime date, string description = null, int maxRegistrationCount = 0)
        {
            Event @event = new Event()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Title = title,
                Description = description,
                MaxRegistrationCount = maxRegistrationCount
            };

            @event.SetDate(date);
            @event.Registrations = new Collection<EventRegistration>();
            return @event;
        }

        public void ChangeDate(DateTime date)
        {
            if (date == Date)
            {
                return;
            }

            SetDate(date);
        }

        public bool IsInPast()
        {
            return Date < Clock.Now;
        }

        internal void Cancel()
        {
            if (IsInPast())
            {
                throw new UserFriendlyException("Cannot cancel a past event");
            }

            IsCancelled = true;
        }

        private void SetDate(DateTime date)
        {
            if (date < Clock.Now)
            {
                throw new UserFriendlyException("Event date cannot be set in past");
            }

            Date = date;
        }
    }
}

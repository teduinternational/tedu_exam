using MediatR;

namespace Examination.Domain.Events
{
    public class ExamStartedDomainEvent : INotification
    {
        public ExamStartedDomainEvent(string userId, string firstName, string lastName)
            => (UserId, FirstName, LastName) = (userId, firstName, lastName);
        public string UserId { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
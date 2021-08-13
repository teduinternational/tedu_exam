using System.Threading;
using System.Threading.Tasks;
using Examination.Domain.AggregateModels.UserAggregate;
using Examination.Domain.Events;
using MediatR;

namespace Examination.Application.DomainEventHandlers
{
    public class SynchronizeUserWhenExamStartedDomainEventHandler : INotificationHandler<ExamStartedDomainEvent>
    {
        private readonly IUserRepository _userRepository;
        public SynchronizeUserWhenExamStartedDomainEventHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(ExamStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(notification.UserId);
            if (user == null)
            {
                user = User.CreateNewUser(notification.UserId, notification.FirstName, notification.LastName);
                await _userRepository.InsertAsync(user);
            }
        }
    }
}
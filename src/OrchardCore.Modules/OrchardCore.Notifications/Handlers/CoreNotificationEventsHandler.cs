using System.Threading.Tasks;
using OrchardCore.Entities;
using OrchardCore.Notifications.Models;
using OrchardCore.Notifications.Services;
using OrchardCore.Users.Models;

namespace OrchardCore.Notifications.Handlers;

public class CoreNotificationEventsHandler : NotificationEventsHandler
{
    public override Task CreatingAsync(NotificationContext context)
    {
        var user = context.Notify as User;

        if (user != null)
        {
            context.Notification.UserId = user.UserId;
        }

        if (context.NotificationMessage is INotificationBodyMessage nm)
        {
            var bodyPart = context.Notification.As<NotificationBodyInfo>();

            bodyPart.IsHtmlBody = nm.IsHtmlBody;
            bodyPart.Body = nm.Body;

            context.Notification.Put(bodyPart);
        }

        return Task.CompletedTask;
    }
}

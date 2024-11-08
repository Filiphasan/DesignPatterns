using ObserverDp.Common.Models;
using ObserverDp.Observers.Interfaces;

namespace ObserverDp.Observers;

public class UserNewsletterNotificationObserver : INewsletterObserver
{
    public async Task SendNewsletterAsync(NewsletterUserSendModel newsletter)
    {
        // Simulate user newsletter notification
        await Task.Delay(100);
        Console.WriteLine($"User newsletter notification sent, Newsletter: {newsletter.NewsletterId} User: {newsletter.UserId}");
    }
}
using ObserverDp.Common.Entities;
using ObserverDp.Common.Models;

namespace ObserverDp.Observers.Interfaces;

public interface INewsletterObserver
{
    Task SendNewsletterAsync(NewsletterUserSendModel newsletter);
}
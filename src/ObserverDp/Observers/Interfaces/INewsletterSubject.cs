using ObserverDp.Common.Entities;
using ObserverDp.Common.Models;

namespace ObserverDp.Observers.Interfaces;

public interface INewsletterSubject
{
    void Attach(INewsletterObserver observer);
    void Detach(INewsletterObserver observer);
    Task NotifyAsync(NewsletterUserSendModel newsletter);
}
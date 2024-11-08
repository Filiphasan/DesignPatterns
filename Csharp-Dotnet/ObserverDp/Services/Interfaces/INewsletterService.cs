using ObserverDp.Common.Models;
using ObserverDp.Observers.Interfaces;

namespace ObserverDp.Services.Interfaces;

public interface INewsletterService : INewsletterSubject
{
    Task AddNewsletterAsync(CreateNewsletterRequest model);
}
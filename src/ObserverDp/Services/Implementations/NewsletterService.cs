using Microsoft.EntityFrameworkCore;
using ObserverDp.Common.Entities;
using ObserverDp.Common.Models;
using ObserverDp.Data;
using ObserverDp.Observers.Interfaces;
using ObserverDp.Services.Interfaces;

namespace ObserverDp.Services.Implementations;

public class NewsletterService : INewsletterService
{
    private readonly List<INewsletterObserver> _observers = [];
    
    private readonly NewsletterDbContext _context;

    public NewsletterService(NewsletterDbContext context)
    {
        _context = context;
    }

    public async Task AddNewsletterAsync(CreateNewsletterRequest model)
    {
        var category = await _context.Categories
            .Where(x => x.Id == model.CategoryId)
            .Include(x => x.CategoryUsers)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync();
        
        ArgumentNullException.ThrowIfNull(category);
        
        var newsletter = new Newsletter
        {
            Title = model.Title,
            CategoryId = model.CategoryId,
            Content = model.Content,
        };
        await _context.Newsletters.AddAsync(newsletter);
        await _context.SaveChangesAsync();

        foreach (var categoryUser in category.CategoryUsers)
        {
            await NotifyAsync(new NewsletterUserSendModel
            {
                NewsletterId = newsletter.Id,
                UserId = categoryUser.User!.Id
            });
        }
    }

    public void Attach(INewsletterObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(INewsletterObserver observer)
    {
        _observers.Remove(observer);
    }

    public async Task NotifyAsync(NewsletterUserSendModel newsletter)
    {
        foreach (var newsletterObserver in _observers)
        {
            await newsletterObserver.SendNewsletterAsync(newsletter);
        }
    }
}
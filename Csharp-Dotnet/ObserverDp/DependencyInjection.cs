using Microsoft.EntityFrameworkCore;
using ObserverDp.Common.Entities;
using ObserverDp.Data;
using ObserverDp.Observers;
using ObserverDp.Observers.Interfaces;
using ObserverDp.Services.Implementations;
using ObserverDp.Services.Interfaces;

namespace ObserverDp;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddNewsletterDbContext();

        services.AddScoped<INewsletterObserver, UserNewsletterNotificationObserver>();
        services.AddScoped<INewsletterService>(sp =>
        {
            var serviceList = sp.GetServices<INewsletterObserver>();
            var context = sp.GetRequiredService<NewsletterDbContext>();
            var service = new NewsletterService(context);

            foreach (var serviceItem in serviceList)
            {
                service.Attach(serviceItem);
            }

            return service;
        });
    }

    private static void AddNewsletterDbContext(this IServiceCollection services)
    {
        services.AddDbContext<NewsletterDbContext>(opt => { opt.UseInMemoryDatabase("NewsletterDb"); });

        var context = services.BuildServiceProvider().GetRequiredService<NewsletterDbContext>();

        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            var users = new[]
            {
                new User { Id = 1, Name = "User 1", Email = "p3Jt0@example.com" }
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
        }

        if (!context.Categories.Any())
        {
            var categories = new[]
            {
                new Category { Id = 1, Name = "Category 1" }
            };
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
        }

        if (!context.CategoryUsers.Any())
        {
            var categoryUsers = new[]
            {
                new CategoryUser { Id = 1, UserId = 1, CategoryId = 1 }
            };
            foreach (var categoryUser in categoryUsers)
            {
                context.CategoryUsers.Add(categoryUser);
            }
        }
        context.SaveChanges();
    }
}
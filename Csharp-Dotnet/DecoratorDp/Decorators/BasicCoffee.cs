using DecoratorDp.Decorators.Interfaces;

namespace DecoratorDp.Decorators;

public class BasicCoffee : ICoffee
{
    public virtual string GetCoffeeInfo()
    {
        return "Basic Coffee";
    }
}
using DecoratorDp.Decorators.Interfaces;

namespace DecoratorDp.Decorators;

public abstract class CoffeeBaseDecorator : BasicCoffee
{
    protected readonly ICoffee Coffee;

    protected CoffeeBaseDecorator(ICoffee coffee)
    {
        Coffee = coffee;
    }

    public override string GetCoffeeInfo()
    {
        return Coffee.GetCoffeeInfo();
    }
}
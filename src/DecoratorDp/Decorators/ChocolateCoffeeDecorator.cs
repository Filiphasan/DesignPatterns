using DecoratorDp.Decorators.Interfaces;

namespace DecoratorDp.Decorators;

public class ChocolateCoffeeDecorator : CoffeeBaseDecorator
{
    public ChocolateCoffeeDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetCoffeeInfo()
    {
        return $"{Coffee.GetCoffeeInfo()} with chocolate";
    }
}
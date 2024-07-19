using DecoratorDp.Decorators.Interfaces;

namespace DecoratorDp.Decorators;

public class MilkCoffeeDecorator : CoffeeBaseDecorator
{
    public MilkCoffeeDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override string GetCoffeeInfo()
    {
        return $"{Coffee.GetCoffeeInfo()} with milk";
    }
}
struct Milk
{
    public double Fat;

    public Milk(double fat)
    {
        Fat = fat;
    }
}

struct Sugar
{
    public string Sort;

    public Sugar(string sort)
    {
        Sort = sort;
    }
}

struct Coffee
{
    public string Sort;
    public List<Milk> Milk;
    public List<Sugar> Sugar;

    public Coffee()
    {
        Sort = string.Empty;
        Milk = new List<Milk>();
        Sugar = new List<Sugar>();
    }

    public Coffee(string sort, List<Milk> milk, List<Sugar> sugar)
    {
        Sort = sort;
        Milk = milk;
        Sugar = sugar;
    }
}

class CoffeeBuilder
{

    private Coffee _coffee;
    public CoffeeBuilder()
    {
        _coffee = new Coffee
        {
            Milk = new List<Milk>(),
            Sugar = new List<Sugar>()
        };
    }

    public CoffeeBuilder SetBlackCoffee()
    {
        _coffee.Sort = "Black";
        return this;
    }

    public CoffeeBuilder SetCubanoCoffee()
    {
        _coffee.Sort = "Cubano";
      _coffee.Sugar.Add(new Sugar("Brown"));
        return this;

    }

    public CoffeeBuilder SetAntoccinoCoffee()
    {
        _coffee.Sort = "Americano";
      _coffee.Milk.Add(new Milk(0.5));
        return this;
    }

    public CoffeeBuilder WithMilk(double fat)
    {
        _coffee.Milk.Add(new Milk(fat));
        return this;
    }

    public CoffeeBuilder WithSugar(string sort)
    {
        _coffee.Sugar.Add(new Sugar(sort));
        return this;
    }

    public Coffee Build()
    {
        return _coffee;
    }
};
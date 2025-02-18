using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class CafeteriaTests
    {
        [Test, Order(1)]
        public void Test1()
        {
            var actual = new CoffeeBuilder().SetBlackCoffee().WithSugar("Regular").WithMilk(3.2).Build();
            var expected = new Coffee("Black", new List<Milk>{new Milk(3.2)}, new List<Sugar>{new Sugar("Regular")});
            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
        }
    
        [Test, Order(2)]
        public void Test2()
        {
            var actual = new CoffeeBuilder().SetAntoccinoCoffee().Build();
            var expected = new Coffee("Americano", new List<Milk>{new Milk(0.5)}, new List<Sugar>());
            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
        }
    
        [Test, Order(3)]
        public void Test3()
        {
            var actual = new CoffeeBuilder().SetCubanoCoffee().Build();
            var expected = new Coffee("Cubano", new List<Milk>(), new List<Sugar>{new Sugar("Brown")});
            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
        }
    }

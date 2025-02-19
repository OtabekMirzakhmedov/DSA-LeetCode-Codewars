using System.Reflection;
using NUnit.Framework;


[TestFixture]
public class SingletonPatternTests
{
    [Test, Order(1)]
    public void Adam_is_unique()
    {
        Adam adam = Adam.GetInstance();   
        Adam anotherAdam = Adam.GetInstance();
        
        Assert.That(adam, Is.InstanceOf<Adam>());
        Assert.That(adam, Is.EqualTo(anotherAdam));
    }
    
    [Test, Order(2)]
    public void Adam_is_unique_and_only_GetInstance_can_return_adam()
    {   
        // GetInstance() is the only static method on Adam
        var staticMethodCount = typeof(Adam).GetMethods().Where(x => x.IsStatic).Count();
        Assert.That(staticMethodCount, Is.EqualTo(1));
        
        // Adam does not have public or internal constructors
        var hasPublicConstructor = typeof(Adam).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
          .Any(x => x.IsPublic || x.IsAssembly );
        Assert.That(hasPublicConstructor, Is.False);
    }
    
    [Test, Order(3)]
    public void Adam_is_unique_and_cannot_be_overriden()
    {
        Assert.That(typeof(Adam).IsSealed, Is.True);
    }
    
    [Test, Order(4)]
    public void Adam_is_a_human()
    {
        Assert.That(Adam.GetInstance(), Is.InstanceOf<Human>()); 
    }

    [Test, Order(5)]
    public void Adam_is_a_male()
    { 
        Assert.That(Adam.GetInstance(), Is.InstanceOf<Male>());
    }
    
    [Test, Order(6)]
    public void Eve_is_unique_and_created_from_a_rib_of_adam()
    {
        Adam adam = Adam.GetInstance();
        Eve eve = Eve.GetInstance(adam);
        Eve anotherEve = Eve.GetInstance(adam);
        
        Assert.That(eve, Is.InstanceOf<Eve>());
        Assert.That(eve, Is.EqualTo(anotherEve));

        // GetInstance() is the only static method on Eve
        var staticMethodCount = typeof(Eve).GetMethods().Where(x => x.IsStatic).Count();
        Assert.That(staticMethodCount, Is.EqualTo(1));

        // Eve has no public or internal constructor
        var hasPublicConstructor = typeof(Eve).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
          .Any(x => x.IsPublic || x.IsAssembly);
        Assert.That(hasPublicConstructor, Is.False);
        
        // Eve cannot be overridden
        Assert.That(typeof(Eve).IsSealed, Is.True);
    }
    
    [Test, Order(7)]
    public void Eve_can_only_be_create_of_a_rib_of_adam()
    {
        Assert.Throws<ArgumentNullException>(() => Eve.GetInstance(null));
    }

    [Test, Order(8)]
    public void Eve_is_a_human()
    {
        Assert.That(Eve.GetInstance(Adam.GetInstance()), Is.InstanceOf<Human>());
    }

    [Test, Order(9)]
    public void Eve_is_a_female()
    {
        Assert.That(Eve.GetInstance(Adam.GetInstance()), Is.InstanceOf<Female>());
    }
 
    [Test, Order(10)]
    public void Reproduction_always_result_in_a_male_or_female()
    {
        Assert.That(typeof(Human).IsAbstract, Is.True);
    }
    
    [Test, Order(11)]
    public void Humans_can_reproduce_when_there_is_a_name_a_mother_and_a_father()
    {
        var adam = Adam.GetInstance();
        var eve = Eve.GetInstance(adam);
        var seth = new Male("Seth", eve, adam);
        var azura = new Female("Azura", eve, adam);
        var enos = new Male("Enos", azura, seth);

        Assert.That(eve.Name, Is.EqualTo("Eve"));
        Assert.That(adam.Name, Is.EqualTo("Adam"));
        Assert.That(seth.Name, Is.EqualTo("Seth"));
        Assert.That(azura.Name, Is.EqualTo("Azura"));
        Assert.That(((Human)enos).Name, Is.EqualTo("Enos"));
        Assert.That(((Human)enos).Father, Is.EqualTo(seth));
        Assert.That(((Human)enos).Mother, Is.EqualTo(azura));
    }
    
    [Test, Order(12)]
    public void Father_and_mother_are_essential_for_reproduction()
    {
        // There is just 1 way to reproduce 
        var maleConstructorCount = typeof(Male).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
          .Where(x => x.IsPublic || x.IsAssembly).Count();
        Assert.That(maleConstructorCount, Is.EqualTo(1));

        var femaleConstructorCount = typeof(Female).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
          .Where(x => x.IsPublic || x.IsAssembly).Count();
        Assert.That(femaleConstructorCount, Is.EqualTo(1));
        
        var adam = Adam.GetInstance();
        var eve = Eve.GetInstance(adam);
        Assert.Throws<ArgumentNullException>(() => new Male("Seth", null, null));
        Assert.Throws<ArgumentNullException>(()=> new Male("Abel", eve, null));
        Assert.Throws<ArgumentNullException>(() => new Male("Seth", null, adam));
        Assert.Throws<ArgumentNullException>(() => new Female("Azura", null, null));
        Assert.Throws<ArgumentNullException>(() => new Female("Awan", eve, null));
        Assert.Throws<ArgumentNullException>(() => new Female("Dina", null, adam));
        Assert.Throws<ArgumentNullException>(() => new Female("Eve", null, null));
        Assert.Throws<ArgumentNullException>(() => new Male("Adam", null, null));
    }
}
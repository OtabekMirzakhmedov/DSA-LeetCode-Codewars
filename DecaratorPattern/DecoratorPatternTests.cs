using System;
using NUnit.Framework;

[TestFixture]
public class DecoratorPatternTests
{
    [Test, Order(1)]
    public void _0_SingleUpgrade()
    {
        IMarine marine = new Marine(10, 1);

        Assert.That(new MarineWeaponUpgrade(marine).Damage, Is.EqualTo(11));
        Assert.That(new MarineWeaponUpgrade(marine).Damage, Is.EqualTo(11));
    }

    [Test, Order(2)]
    public void _1_DoubleUpgrade()
    {
        IMarine marine = new Marine(15, 1);
        marine = new MarineWeaponUpgrade(marine);
        marine = new MarineWeaponUpgrade(marine);

        Assert.That(marine.Damage, Is.EqualTo(17));
    }

    [Test, Order(3)]
    public void _2_TripleUpgrade()
    {
        IMarine marine = new Marine(20, 1);
        marine = new MarineWeaponUpgrade(marine);
        marine = new MarineWeaponUpgrade(marine);
        marine = new MarineWeaponUpgrade(marine);

        Assert.That(marine.Damage, Is.EqualTo(23));
    }
}
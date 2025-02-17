using System;

public interface IMarine
{
    int Damage { get; set; }
    int Armor { get; set; }
}

public class Marine : IMarine
{
    public Marine(int damage, int armor)
    {
        Damage = damage;
        Armor = armor;
    }

    public int Damage { get; set; }
    public int Armor { get; set; }
}

public class MarineWeaponUpgrade : IMarine
{
    private IMarine _marine;

    public MarineWeaponUpgrade(IMarine marine)
    {
        _marine = marine;
    }

    public int Damage
    {
        get { return _marine.Damage + 1; }
        set { _marine.Damage = value; }
    }

    public int Armor
    {
        get { return _marine.Armor; }
        set { _marine.Armor = value; }
    }
}

public class MarineArmorUpgrade : IMarine
{
    private IMarine _marine;

    public MarineArmorUpgrade(IMarine marine)
    {
        _marine = marine;
    }

    public int Damage
    {
        get { return _marine.Damage; }
        set { _marine.Damage = value; }
    }

    public int Armor
    {
        get { return _marine.Armor + 1; }
        set { _marine.Armor = value; }
    }
}
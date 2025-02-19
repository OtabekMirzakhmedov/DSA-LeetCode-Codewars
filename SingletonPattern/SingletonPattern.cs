using System;
using System.Linq;

public sealed class Eve : Female
{
    private static Eve eve;

    private Eve(): base("Eve")
    {
    }

    public static Eve GetInstance(Adam adam)
    {
        if (adam==null)
        {
            throw new ArgumentNullException();
        }
        return eve??(eve=new Eve());
    }
}

public abstract class Human
{
    protected Human(string name)
    {
        Name = name;
    }

    public Human(string name, Female mother, Male father):this(name)
    {
        if (mother==null) throw new ArgumentNullException("mother");
        if (father==null) throw new ArgumentNullException("father");
        Mother = mother;
        Father = father; 
    }

    public string Name { get; }
    public Male Father { get; }
    public Female Mother { get; }
}

public class Male : Human
{
    protected Male(string name):base(name)
    {
    }

    public Male(string name, Female mother, Male father):base(name, mother, father)
    {
    }
}

public class Female : Human
{
    protected Female(string name): base (name)
    {
    }

    public Female(string name, Female mother, Male father):base(name, mother, father)
    {
    }
}

public sealed class Adam : Male
{
    private static Adam adam;
    private static Eve eve;

    private Adam(): base ("Adam")
    {
    }

    public static Adam GetInstance()
    {
        return adam??(adam=new Adam());
    }
}
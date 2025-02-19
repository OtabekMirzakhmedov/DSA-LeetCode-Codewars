
using System;
public abstract class Human
{
    public string Name { get; protected set; }
    public Female Mother { get; protected set; }
    public Male Father { get; protected set; }

    protected Human(string name, Female mother, Male father)
    {
        ValidateParameters(name, mother, father);
        Name = name;
        Mother = mother;
        Father = father;
    }

    private void ValidateParameters(string name, Female mother, Male father)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (name == null)
            throw new ArgumentNullException(nameof(name));
    
        // Allow null parents only for the true singleton instances of Adam and Eve.
        if ((name == "Adam" && this.GetType() == typeof(Adam)) ||
            (name == "Eve" && this.GetType() == typeof(Eve)))
        {
            return;
        }
        if (mother == null)
            throw new ArgumentNullException(nameof(mother));
        
        if (father == null)
            throw new ArgumentNullException(nameof(father));
    }
}

public class Male : Human
{
    public Male(string name, Female mother, Male father) : base(name, mother, father)
    {
    }
}

public class Female : Human
{
    public Female(string name, Female mother, Male father) : base(name, mother, father)
    {
    }
}

public sealed class Adam : Male
{
    private static readonly Adam instance = new Adam();

    private Adam() : base("Adam", null, null)
    {
    }

    public static Adam GetInstance()
    {
        return instance;
    }
}

public sealed class Eve : Female
{
    private static Eve instance;
    private readonly Adam adam;

    private Eve(Adam adam) : base("Eve", null, null)
    {
        this.adam = adam ?? throw new ArgumentNullException(nameof(adam));
    }

    public static Eve GetInstance(Adam adam)
    {
        if (adam == null)
        {
            throw new ArgumentNullException(nameof(adam), "Eve can only be created from Adam's rib");
        }

        if (instance == null)
        {
            instance = new Eve(adam);
        }
        return instance;
    }
}
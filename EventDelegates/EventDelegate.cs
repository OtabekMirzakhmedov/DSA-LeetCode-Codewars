public class PersonEventArgs : EventArgs
{
    public string Name { get; }
    
    public PersonEventArgs() { }
    
    public PersonEventArgs(string name)
    {
        Name = name;
    }
}

public class Publisher
{
    public event EventHandler<PersonEventArgs>? ContactNotify;

    public void CountMessages(List<string> peopleList)
    {
        Dictionary<string, int> counts = new Dictionary<string, int>();

        foreach (string person in peopleList)
        {
            if (!counts.ContainsKey(person))
                counts[person] = 0;

            counts[person]++;

            if (counts[person] % 3 == 0)
            {
                OnContactNotify(new PersonEventArgs(person));
            }
        }
    }

    protected virtual void OnContactNotify(PersonEventArgs e)
    {
        ContactNotify?.Invoke(this, e);
    }
}

public class TextMessageSend
{
    public static string TextMessageList { get; set; }
    public static void Send(object source, PersonEventArgs e)
    {
        if (string.IsNullOrEmpty(TextMessageList))
        {
            TextMessageList = e.Name;
        }
        else
        {
            TextMessageList += ", " + e.Name;
        }
    }
}
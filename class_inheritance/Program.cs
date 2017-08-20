using System;

interface ITitled
{
    string Title { get; }
}

interface IExample
{
    void SomeMethod();
}

class Person : ITitled, IExample
{
    public Person(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
    private virtual string Title
    {
        get
        {
            return "";
        }
    }
    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Title))
            return Name;
    }
}
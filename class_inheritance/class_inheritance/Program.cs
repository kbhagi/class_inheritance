using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_inheritance
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Person eric = new Person("Eric");
            Person obama = new Person("Barack Obama");
            Console.WriteLine(obama.ToString());
            string result = obama.VirtualMethod();
            result = eric.Title;
            result = obama.Title;
            ChangeRequest request = new ChangeRequest("", "", eric);
            request.SubmitRequest();
         }
    }
    abstract class CovarianceExampleBase
    {
        public abstract ChangeRequest Example();
    }
    class CovarianceExampleDericed : CovarianceExampleBase
    {
        public override ChangeRequest Example()
        {
            return null;
        }
    }
    }
abstract class ChangeRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Person Implementer { get; set; }

    public void SubmitRequest()
    {
        ValidateRequest();
        PersistToDatabase();
    }
    protected abstract void ValidateRequest();
    protected abstract void PersistToDatabase();
}

class DefectFixRequest : ChangeRequest
{
public DefectFixRequest(string title, string description,Person implementer,Person reporter)
    : base(title, description, implementer)
    {
        this.Reporter = reporter;
    }
    public string ExpectedBehavior { get; set; }
    public string ObservedBehavior { get; set; }
    public Person Reporter { get; set; }
}
class FeatureRequest : ChangeRequest
{
    public FeatureRequest(
        string title,
        string description,
        Person implementer,
        Person requestedBy)
        : base(title, description, implementer)
    {
        this.RequestedBy = requestedBy;
    }
    public Person RequestedBy { get; set; }
}

class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
    public virtual string VirtualMethod()
    {
        return "Hello";
    }
    public virtual string Title
    {
        get
        {
            return "";
        } 
    }

}
sealed class President : Person
{
    public President(string name) : base(name)
    {

    }
    public override string ToString()
    {
        return $"President {Name}";
    }
    public override string VirtualMethod()
    {
        return base.VirtualMethod() +" Goodbye";
    }
    public override string Title
    {
        get
        {
            return "President";
        }
    }
}










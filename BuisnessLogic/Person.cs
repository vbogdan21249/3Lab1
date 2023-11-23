using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic;
public interface IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
public interface IStudy
{
    public string Study();
}
public interface ICompose
{
    public string Compose();
}
public interface IFly
{
    public string Fly();
}
public abstract class Entity : IEntity
{
    protected string firstName;
    protected string lastName;
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    protected Entity(string FirstNameInput, string LastNameInput)
    {
        firstName = FirstNameInput;
        lastName = LastNameInput;
    }
}
public class Student : Entity, IStudy
{
    private int course;
    private string studentCard;
    private string gender;
    private string dormitory;
    public int Course
    {
        get => course;
        set => course = value;
    }
    public string StudentCard
    {
        get => studentCard;
        set => studentCard = value;
    }
    public string Gender
    {
        get => gender;
        set => gender = value;
    }
    public string Dormitory
    {
        get => dormitory;
        set => dormitory = value;
    }
    public Student(string FirstName, string LastName, string gender, int course, string studentCard, string dormitory) :
        base(FirstName, LastName)
    {
        Gender = gender;
        Course = course;
        StudentCard = studentCard;
        Dormitory = dormitory;
    }
    public override string ToString()
    {
        return "EntityType Student\n" +
               "{FirstName: '" + firstName + "'\n" +
               "LastName: '" + lastName + "'\n" +
               "Gender: '" + gender + "'\n" +
               "Course: '" + course + "'\n" +
               "StudentCard: '" + studentCard + "'\n" +
               "Dormitory: '" + dormitory + "'};\n";
    }
    public string Study()
    {
        return firstName + " " + lastName + " is studying";
    }
}
public class Musician : Entity, ICompose
{
    public Musician(string FirstName, string LastName) : base(FirstName, LastName)
    {

    }
    public override string ToString()
    {
        return "EntityType Musician\n" +
               "{FirstName: '" + firstName + "'\n" +
               "LastName: '" + lastName + "'};\n";
    }
    public string Compose()
    {
        return firstName + " " + lastName + " is composing";
    }
}
public class Pilot : Entity, IFly
{
    public Pilot(string FirstName, string LastName) : base(FirstName, LastName)
    {

    }
    public override string ToString()
    {
        return "EntityType Pilot\n" +
               "{FirstName: '" + firstName + "'\n" +
               "LastName: '" + lastName + "'};\n";
    }
    public string Fly()
    {
        return firstName + " " + lastName + " is flying";
    }
}

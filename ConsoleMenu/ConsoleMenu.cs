using BuisnessLogic;
using DB;

namespace UI;
public class ConsoleMenu
{
    public static string commands()
    {
        Console.Clear();
        string commandsSTR = "To choose command write:\n" +
                          "1 - add student\n" +
                          "2 - add musician\n" +
                          "3 - add pilot\n" +
                          "4 - show database\n" +
                          "5 - delete person\n" +
                          "6 - calculate the number and show 1th-year who live in dormitory\n" +
                          "7 - clear database\n" +
                          "8 - entities actions\n" +
                          "EXIT - stop program\n";
        Console.Write(commandsSTR);
        return $"{Console.ReadLine()}";
    }

    public static int userInput(string input)
    {
        try
        {
            switch (input)
            {
                case "1":
                    {
                        addStudent();
                        return 0;
                    }
                case "2":
                    {
                        addMusician();
                        return 0;
                    }
                case "3":
                    {
                        addPilot();
                        return 0;
                    }
                case "4":
                    {
                        showDatabase();
                        return 0;
                    }
                case "5":
                    {
                        deletePerson();
                        return 0;
                    }
                case "6":
                    {
                        calculate();
                        return 0;
                    }
                case "7":
                    {
                        clearDB();
                        return 0;
                    }
                case "8":
                    {
                        actions();
                        return 0;
                    }
                case "EXIT":
                    {
                        return 1;
                    }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }
    private static void addStudent()
    {
        Console.Clear();
        string firstName = Input.InputName("firstName");
        string lastName = Input.InputName("lastName");
        string gender = Input.InputGender("gender");
        int course = Input.InputCourse();
        string card = Input.InputStudentCard();
        string dormitory = Input.InputDormitory();
        Student student = new Student(firstName, lastName, gender, course, card, dormitory);
        DBMethods.Writer(student.ToString());
    }
        private static void addMusician()
    {
        Console.Clear();
        string firstName = Input.InputName("firstName");
        string lastName = Input.InputName("lastName");
        Musician musician = new Musician(firstName, lastName);
        DBMethods.Writer(musician.ToString());
    }

    private static void addPilot()
    {
        Console.Clear();
        string firstName = Input.InputName("firstName");
        string lastName = Input.InputName("lastName");
        Pilot pilot = new Pilot(firstName, lastName);
        DBMethods.Writer(pilot.ToString());
    }

    private static void showDatabase()
    {
        Console.Clear();
        EntitiesManager.listOfEntities(0);
        Console.ReadLine();
    }

    private static void deletePerson()
    {
        Console.Clear();
        Console.WriteLine("Choose person to delete. Enter 'x' to return.\n");
        EntitiesManager.listOfEntities(1);
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                if (input == "x") break;
                EntitiesManager.deleteEntity(int.Parse(input));
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Invalid input.");
            }
        }

    }
    private static void calculate()
    {
        Console.Clear();
        EntitiesManager.searchStudent();
        Console.ReadLine();
    }
    private static void clearDB()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to delete all of the entities? Yes/No");
        string input = Console.ReadLine();
        if (input == "Yes")
        {
            DBMethods.Cleaner();
            Console.WriteLine("Message: DB file is empty!");
            Console.ReadLine();
        }
        
    }
    private static void actions()
    {
        Console.Clear();

        EntitiesManager.listOfEntities(2);
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] info = EntitiesManager.RecreateFromDB(int.Parse(input));
                if (info[0] == "Student")
                {
                    Student student = new Student(info[1], info[2], info[3], int.Parse(info[4]), info[5], info[6]);
                    Console.WriteLine(student.Study());
                    Console.ReadLine();
                    break;
                }

                if (info[0] == "Musician")
                {
                    Musician musician = new Musician(info[1], info[2]);
                    Console.WriteLine(musician.Compose());
                    Console.ReadLine();
                    break;
                }

                if (info[0] == "Pilot")
                {
                    Pilot pilot = new Pilot(info[1], info[2]);
                    Console.WriteLine(pilot.Fly());
                    Console.ReadLine();
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Invalid input.");
            }

        }
    }
}
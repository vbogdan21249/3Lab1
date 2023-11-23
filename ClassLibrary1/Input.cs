using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BuisnessLogic;

public class Input
{
    public static string InputName(string input)
    {
        Regex regex = new Regex(@"^[A-Z]{1}[a-z]+$");
        Console.WriteLine($"Enter {input}:");
        string data = Console.ReadLine();
        while (!regex.IsMatch(data))
        {
            Console.WriteLine("Error: invalid input. Try Again.");
            data = Console.ReadLine();
        }
        return data;
    }
    public static string InputGender(string input)
    {
        return InputName(input);
    }
    public static int InputCourse()
    {
        Regex regex = new Regex(@"^[1-6]$");
        Console.WriteLine($"Enter the course of the student:");
        string data = Console.ReadLine();
        while (!regex.IsMatch(data))
        {
            Console.WriteLine("Error: invalid input. Try Again.");
            data = Console.ReadLine();
        }
        return int.Parse(data);
    }
    public static string InputStudentCard()
    {
        Regex regex = new Regex(@"^KB\d{8}$");
        Console.WriteLine($"Enter StudentCard in format (KB12345678):");
        string data = Console.ReadLine();
        while (!regex.IsMatch(data))
        {
            Console.WriteLine("Error: invalid input. Try Again.");
            data = Console.ReadLine();
        }
        return data;
    }
    public static string InputDormitory()
    {
        Regex regexDormitory = new Regex(@"^\d{2}|-?$");
        Console.WriteLine($"Enter the number of the dormitory where the student lives:");
        string dormitory = Console.ReadLine();
        
        if (dormitory == "-")
        {
            return "-";
        }

        if (!regexDormitory.IsMatch(dormitory))
        {
            Console.WriteLine("Error: invalid input. Try Again.");
            return InputDormitory();
        }
        else { 
            string room = InputDormRoom();
            return dormitory + "." + room;
        }
    }

    public static string InputDormRoom()
    {
        Regex regexRoom = new Regex(@"^\d{3}$");
        Console.WriteLine($"Enter the number of the room where the student lives:");
        string room = Console.ReadLine();
        if (!regexRoom.IsMatch(room))
        {
            Console.WriteLine("Error: invalid input. Try Again.");
            return InputDormRoom();
        }
        else
        {
            return room;
        }

    }
}

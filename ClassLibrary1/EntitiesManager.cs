using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DB;
namespace BuisnessLogic;

public class EntitiesManager
{
    public static void listOfEntities(int number)
    {
        string entity = DBMethods.Reader();
        string[] entities = entity.Split(";\n");
        for (int i = 0; i < entities.Length - 1; i++)
        {
            if (number == 1)
            {
                Console.WriteLine("Enter " + i + " to delete this entity:");
            }
            if (number == 2)
            {
                Console.WriteLine("Enter " + i + " to watch actions of this entity:");
            }
            Console.WriteLine(entities[i] + ";");
        }
    }
    public static int getSizeOfList()
    {
        string entity = DBMethods.Reader();
        string[] entities = entity.Split(";\n");
        return entities.Length - 1;
    }

    public static void deleteEntity(int index)
    {
        if (index > getSizeOfList() - 1)
        {
            throw new Exception("Error: index out of range.");
        }
        try
        {
            string entity = DBMethods.Reader();
            string[] entities = entity.Split(";\n");
            int sizeOfList = entities.Length - 2;
            string[] newList = new string[sizeOfList];
            for (int i = 0; i < entities.Length - 1; i++)
            {
                if (i < index)
                {
                    newList[i] = entities[i];
                }

                if (i > index)
                {
                    newList[i - 1] = entities[i];
                }
            }
            DBMethods.Cleaner();
            for (int i = 0; i < newList.Length; i++)
            {
                string text = newList[i] + ";\n";
                DBMethods.Writer(text);
            }
            Console.WriteLine("Entity with index " + index + " deleted.");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: index out of range!");
        }
    }
    public static void searchStudent() // Calculate the number of 1th-year students who live in dormmitory.
    {
        string entity = DBMethods.Reader();
        string[] entities = entity.Split(";\n");
        int number = 0;

        Regex regex1 = new Regex("EntityType Student");
        Regex regex2 = new Regex("Gender: 'Female");
        Regex regex3 = new Regex("Course: '1");
        Regex regex4 = new Regex(@"\d{2}");

        Console.WriteLine("List of 1th-year students who live in dormitory:");
        for (int i = 0; i < entities.Length - 1; i++)
        {
            if (regex1.IsMatch(entities[i]) && regex2.IsMatch(entities[i]) && regex3.IsMatch(entities[i]) && regex4.IsMatch(entities[i]))
            {
                Console.WriteLine(entities[i] + ";");
                number += 1;
            }
        }
        Console.WriteLine("1th-year students who live in dormitory: " + number);
    }
    public static string[] RecreateFromDB(int index)
    {
        if (index > getSizeOfList() - 1)
        {
            throw new Exception("Index out of range!");
        }
        string entity = DBMethods.Reader();
        string[] entities = entity.Split(";\n");
        string[] elements = entities[index].Split("\n");
        string[] classRow = elements[0].Split(" ");
        string[] firstNameRow = elements[1].Split("'");
        string[] lastNameRow = elements[2].Split("'");
        string[] array = { classRow[1], firstNameRow[1], lastNameRow[1] };
        if (classRow[1] == "Student")
        {
            string[] genderRow = elements[3].Split("'");
            string[] courseNameRow = elements[4].Split("'");
            string[] studentCardRow = elements[5].Split("'");
            string[] dormitoryRow = elements[6].Split("'");
            string[] arrayS = { classRow[1], firstNameRow[1], lastNameRow[1], genderRow[1], courseNameRow[1], studentCardRow[1], dormitoryRow[1] };
            return arrayS;
        }
        else
        {
            return array;
        }
    }

}

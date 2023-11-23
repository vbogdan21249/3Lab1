using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DB;

public class DBMethods
{
    private static string path = AppDomain.CurrentDomain.BaseDirectory + "db.txt";
    public static string Reader()
    {
        using (StreamReader file = new StreamReader(path))
        {
            return file.ReadToEnd();
        }
    }
    public static void Cleaner()
    {
        File.WriteAllText(path, string.Empty);
    }
    public static void Writer(string text)
    {
        using (StreamWriter file = new StreamWriter(path, true))
        {
            file.Write(text);
        }
    }
}

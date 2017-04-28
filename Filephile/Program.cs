using System;
using System.IO;

namespace Filephile
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "DATA.DAT";
            string fullPath = Path.Combine(desktopPath, fileName);
            using (StreamWriter writer = File.CreateText(fullPath))
            {
                writer.WriteLine("PhoneNumber|FirstName|LastName");
            }

            string[][] linesOfStrings = new string[][]
            {
                new string[] { "123-123-1233", "Curtis", "Strange" },
                new string[] { "987-987-9877", "Patrick", "Warburton" },
                new string[] { "555-555-5555", "Dave", "Chapelle" }
            };

            //using (StreamWriter writer = File.AppendText(fullPath))
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                foreach (string[] data in linesOfStrings)
                {
                    writer.WriteLine(string.Join("|", data));
                }
            }

            // using (StreadReader reader = new StreamReader(fullPath))
            using (StreamReader reader = File.OpenText(fullPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    Console.WriteLine(string.Join("\t", parts));
                }
            }

            using (StreamReader reader = File.OpenText(fullPath))
            {
                string[] lines = reader.ReadToEnd().Split('\n');
            }

            File.Delete(fullPath);
        }
    }
}

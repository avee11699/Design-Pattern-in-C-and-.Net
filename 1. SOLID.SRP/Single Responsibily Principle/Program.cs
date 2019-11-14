using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace Single_Responsibily_Principle
{
    public class Journal
    {
        private readonly List<String> entries = new List<String>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

    public class Demo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I am hungry");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt"; //location where file will store and the name of the file
            p.SaveToFile(j, filename);
            Process.Start(filename);
        }
    }
}

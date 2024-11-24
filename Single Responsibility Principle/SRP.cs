using System;
using System.Text;

namespace Single_Responsibility_Principle
{

    /*
     * Because it called Single Responsibility, So it has single reason to change.
     * Don't put all the functions inside one class, 
     * We have to create classes that are doing simmilar functions togother inside the class and the not related functions inside another calss
     * see this sample below we create JournalFiles Class because it saves documents and need to deal with System.IO that the main class not deal with it
    */

    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    // handles the responsibility of persisting objects
    public class JournalFiles
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}

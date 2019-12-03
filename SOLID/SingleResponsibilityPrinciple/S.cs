using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID.SingleResponsibility
{
    //Single responsibility principle
    public class Journal
    {
        private List<string> _entries;
        private int _index = 0;

        public Journal()
        {
             _entries = new List<string>();
        }

        public Journal(string journalTextContent) 
        {
            _entries = new List<string>();
            _entries.AddRange(journalTextContent.Split(Environment.NewLine));

            _index = _entries.Count - 1;
        }

        public int AddEntry(string entry)
        {
            _entries.Add($"({_index++}): {entry}");
            return _index;
        }

        public void Remove (int index)
        {
            _entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }

    public class Persistance
    {
        public void SaveToFile(string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        public string LoadFromFile(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}

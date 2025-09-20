using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

     public void AddEntry(Entry newEntry)
    {
    _entries.Add(newEntry);
    }

    // Save as TXT with custom separator
    public void SaveToTxt(string filename, string sep = "|")
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileLine(sep));
            }
        }
    }

    public void LoadFromTxt(string filename, string sep = "|")
    {
        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            Entry e = Entry.FromFileLine(line, sep);
            if (e != null)
                _entries.Add(e);
        }
    }

    // Save as CSV 
    public void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToCsvLine());
            }
        }
    }

    public void LoadFromCsv(string filename)
    {
        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            Entry e = Entry.FromCsvLine(line);
            if (e != null)
                _entries.Add(e);
        }
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
}
// Now, I can save my file as either TXT or CSV
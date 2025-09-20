using System;



public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry:");
        Console.WriteLine(_entryText);
        // This addtional peice of code adds breaklines after a new prompt comes up
        Console.WriteLine(new string('-', 60));
    }

    // To convert a single line for saving,I am using Separator and replacing newline with \n 
    public string ToFileLine(string sep)
    {
        string safePrompt = _promptText?.Replace(sep, " ") ?? "";
        string safeText = _entryText?.Replace(sep, " ") ?? "";
        safePrompt = safePrompt.Replace("\r", "").Replace("\n", "\\n");
        safeText = safeText.Replace("\r", "").Replace("\n", "\\n");
        return $"{_date}{sep}{safePrompt}{sep}{safeText}";
    }
    // Now, I would turn the lines in the file back into an Entry
    public static Entry FromFileLine(string line, string sep)
    {
        var parts = line.Split(new string[] { sep }, StringSplitOptions.None);
        if (parts.Length < 3) return null;
        var e = new Entry
        {
            _date = parts[0],
            _promptText = parts[1].Replace("\\n", "\n"),
            _entryText = parts[2].Replace("\\n", "\n")

        };
        return e;
    }
    // Now I want it to be able to save as a CSV file
    public string ToCsvLine()
    {
        string Escape(string input)
        {
            if (input == null) return "";
            return "\"" + input.Replace("\"", "\"\"") + "\"";
        }

        return $"{_date},{Escape(_promptText)},{Escape(_entryText)}";
    }
    public static Entry FromCsvLine(string line)
{
    var parts = new List<string>();
    bool inQuotes = false;
    string current = "";

    foreach (char c in line)
    {
        if (c == '\"')
        {
            
            if (inQuotes && current.EndsWith("\""))
                current += "\""; 
            inQuotes = !inQuotes;
        }
        else if (c == ',' && !inQuotes)
        {
            parts.Add(current.Trim('\"'));
            current = "";
        }
        else
        {
            current += c;
        }
    }
    parts.Add(current.Trim('\"'));

    if (parts.Count < 3) return null;

    return new Entry
    {
        _date = parts[0],
        _promptText = parts[1],
        _entryText = parts[2]
    };
}


} 

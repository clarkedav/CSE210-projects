using System;

// I used a Seperator and was able to generate a TXT format file,
// I was also able to add a CSV format file, given two options to save using CSV or TXT.
// I added a breakline after a new prompt comes up in other to make it neatly arranged.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Your Journal");

        var journal = new Journal();
        var promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n Journal Menu ");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal as TXT");
            Console.WriteLine("4. Load journal as TXT");
            Console.WriteLine("3. Save journal as CSV");
            Console.WriteLine("4. Load journal as CSV");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.WriteLine("Write your entry. Press Enter on an empty line to finish.");

                    string line;
                    string entryText = "";
                    while (true)
                    {
                        line = Console.ReadLine();
                        if (string.IsNullOrEmpty(line)) break;
                        if (entryText.Length > 0) entryText += "\n";
                        entryText += line;
                    }

                    var entry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _promptText = prompt,
                        _entryText = entryText
                    };

                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added.");
                    break;

                case "2":
                    Console.WriteLine();
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g. myjournal.txt or myjournal.csv): ");
                    string saveFile = Console.ReadLine();
                    try
                    {
                        if (saveFile.EndsWith(".csv"))
                            journal.SaveToCsv(saveFile);
                        else
                            journal.SaveToTxt(saveFile);  // default to txt
                        Console.WriteLine("Journal saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving file: {ex.Message}");
                    }
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g. myjournal.txt or myjournal.csv): ");
                    string loadFile = Console.ReadLine();
                    try
                    {
                        if (loadFile.EndsWith(".csv"))
                            journal.LoadFromCsv(loadFile);
                        else
                            journal.LoadFromTxt(loadFile); // default to txt
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading file: {ex.Message}");
                    }
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice -- enter 1, 2, 3, 4 or 5.");
                    break;

            }
        }

        Console.WriteLine("Goodbye!");
    }
}
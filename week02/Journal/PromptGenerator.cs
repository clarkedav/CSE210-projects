using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What was the strongest emotion I felt today?",
        "What challenged me today?",
        "What did you achieve today?",
        "what is your greatest fear?",
        "What are you most grateful for?",
        "How did I see the hand of the Lord in my life today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What did you study in the Bible today?",
    };
    private Random _rand = new Random();
    public string GetRandomPrompt()
    {
        int a = _rand.Next(_prompts.Count);
        return _prompts[a];
    }
}
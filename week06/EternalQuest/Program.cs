/*CREATIVE REQUIREMENT
I added a new goal type called ProgressGoal, which tracks gradual progress toward a larger goal
I tried adding points bonuses and progress to make the experience similar to that in games
and it also saves and load usimg a text file*/




using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GoalManager();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("=== Eternal Quest ===");
                Console.WriteLine("1) Create a new goal");
                Console.WriteLine("2) List goals");
                Console.WriteLine("3) Record an event (complete a goal)");
                Console.WriteLine("4) Show score & badges");
                Console.WriteLine("5) Save");
                Console.WriteLine("6) Load");
                Console.WriteLine("7) Quit");
                Console.Write("Choose: ");
                var c = Console.ReadLine();
                Console.WriteLine();

                switch (c)
                {
                    case "1":
                        CreateGoalMenu(gm);
                        break;
                    case "2":
                        gm.ShowGoals();
                        break;
                    case "3":
                        gm.ShowGoals();
                        Console.Write("Enter goal number to record event: ");
                        if (int.TryParse(Console.ReadLine(), out int idx)) gm.RecordGoalEvent(idx - 1);
                        break;
                    case "4":
                        gm.ShowStatus();
                        break;
                    case "5":
                        gm.Save();
                        break;
                    case "6":
                        gm.Load();
                        break;
                    case "7":
                        gm.Save();
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Goodbye!");
        }

        static void CreateGoalMenu(GoalManager gm)
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1) Simple Goal");
            Console.WriteLine("2) Eternal Goal");
            Console.WriteLine("3) Checklist Goal");
            Console.WriteLine("4) Progress Goal (creative)");
            Console.Write("Choice: ");
            var t = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();

            switch (t)
            {
                case "1":
                    Console.Write("Points for completion: ");
                    int p1 = int.Parse(Console.ReadLine());
                    gm.AddGoal(new SimpleGoal(title, desc, p1));
                    break;
                case "2":
                    Console.Write("Points per occurrence: ");
                    int p2 = int.Parse(Console.ReadLine());
                    gm.AddGoal(new EternalGoal(title, desc, p2));
                    break;
                case "3":
                    Console.Write("Points per time: ");
                    int pp = int.Parse(Console.ReadLine());
                    Console.Write("Times required: ");
                    int tr = int.Parse(Console.ReadLine());
                    Console.Write("Bonus on completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    gm.AddGoal(new ChecklistGoal(title, desc, pp, tr, bonus));
                    break;
                case "4":
                    Console.Write("Points per unit: ");
                    int unitPts = int.Parse(Console.ReadLine());
                    Console.Write("Target units to complete: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Completion bonus (0 if none): ");
                    int compBonus = int.Parse(Console.ReadLine());
                    gm.AddGoal(new ProgressGoal(title, desc, unitPts, target, compBonus));
                    break;
                default:
                    Console.WriteLine("Unknown type");
                    break;
            }

            Console.WriteLine("Goal created.");
        }
    }
}

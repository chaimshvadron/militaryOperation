namespace Military_control_system
{
    class Menu
    {
        ControlSystem operations;

        public Menu(ControlSystem controlSystem)
        {
            operations = controlSystem;
        }

        bool running = true;

        public void MenuActivation()
        {
            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════╗");
                Console.WriteLine("║       SYSTEM MENU         ║");
                Console.WriteLine("╚═══════════════════════════╝");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  [1] Intelligence Analysis");
                Console.WriteLine("  [2] Attack Availability");
                Console.WriteLine("  [3] Target Prioritization");
                Console.WriteLine("  [4] Attack Execution");
                Console.WriteLine("  [5] Status Database");
                Console.WriteLine("  [6] Exit");
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Select an option (1-6): ");
                Console.ResetColor();

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(">>> Running Intelligence Analysis...");
                        Console.ResetColor();
                        operations.IntelligenceAnalysis();
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(">>> Checking Attack Availability...");
                        Console.ResetColor();
                        operations.AttackAvailability();
                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(">>> Prioritizing Targets...");
                        Console.ResetColor();
                        operations.TargetPrioritization();
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(">>> Executing Attack...");
                        Console.ResetColor();
                        operations.AttackExecution();
                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(">>> Displaying Status Database...");
                        Console.ResetColor();
                        operations.StatusDatabase();
                        break;

                    case "6":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(">>> Exiting the program...");
                        Console.ResetColor();
                        running = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!! Invalid selection. Please choose a number between 1 and 6.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}

namespace MilitaryControlSystem
{
    public class Menu(ControlSystem controlSystem)
    {
        bool running = true;

        public void MenuActivation()
        {
            while (running)
            {
                this.Print();
                
                string input = Console.ReadLine()!;
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        PrintModel.Print(">>> Running Intelligence Analysis...", "Blue");
                        controlSystem.IntelligenceAnalysis();
                        break;

                    case "2":
                        PrintModel.Print(">>> Checking Attack Availability...", "Blue");
                        controlSystem.AttackAvailability();
                        break;

                    case "3":
                        PrintModel.Print(">>>> Prioritizing Targets...", "Blue");
                        controlSystem.TargetPrioritization();
                        break;

                    case "4":
                        PrintModel.Print(">>> Executing Attack...", "Blue");
                        controlSystem.AttackExecution();
                        break;

                    case "5":
                        PrintModel.Print(">>> Displaying Status Database...", "Blue");
                        controlSystem.StatusDatabase(); 
                        break;

                    case "6":
                        PrintModel.Print(">>> Exiting the program...", "Red");
                        running = false;
                        break;

                    default:
                        PrintModel.Print(">>> !!! Invalid selection. Please choose a number between 1 and 6", "Red");
                        break;
                }

                PrintModel.Print("\nPress Enter to return to menu...", "Yellow");
                Console.ReadLine();
            }
        }
    }
}

namespace MilitaryControlSystem
{
    public static class PrintModel
    {
        public static void Pront(this Terrorist terrorist)
        {
            Console.WriteLine("        =====> Tourist Information <===== ");
            Console.WriteLine($"Name:               ==>> {terrorist.Name}");
            Console.WriteLine($"Organization:       ==>> {terrorist.Organization.Name}");
            Console.WriteLine($"num Weapons:        ==>> {terrorist.Weapons.Count}");
            Console.WriteLine($"IsAlive:            ==>> {terrorist.IsAlive}");
        }

        public static void Print(this Force force)
        {
            int Available = 0;
            foreach (AttackSystem attack in force.attackSystems)
            {
                Available += 1;
                attack.Print();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Organization: {force.Organization.Name}");
            Console.WriteLine($"The number of available weapon systems is: {Available} out of {force.attackSystems.Count}");
            Console.ResetColor();
        }

        public static void Print(this AttackSystem attackSystem)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"--- Strike Report for {attackSystem.Name} ---");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Fuel Available: {attackSystem.FuelSupply}");
            Console.WriteLine($"Ammunition Available: {attackSystem.AmmunitionCapacity}");

            foreach (var target_Weapon in attackSystem.TargetTypeAndWeapon)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($" - target: {target_Weapon.Key} - Weapon: {target_Weapon.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"==============================");
            Console.ResetColor();
        }

        public static void Print(this Organization organization)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n =====================>> {organization.Name} <<=====================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    The organization was created successfully.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    Date of establishment: {organization.EstablishmentDate}");
            Console.WriteLine($"    Current census: {organization.CurrentCommander}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" =============================================\n");
            Console.ResetColor();
        }

        public static void Print(this Menu menu)
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
        }

        public static void Print(string text, string color)
        {
            if (color == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
            else if (color == "Red") Console.ForegroundColor = ConsoleColor.Red;
            else if (color == "Gray") Console.ForegroundColor = ConsoleColor.Gray;
            else if (color == "Magenta") Console.ForegroundColor = ConsoleColor.Magenta;
            else if (color == "Yellow") Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintSuccessMessage(string target, DateTime time, Terrorist terrorist)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("     Attack successfully carried out"    );
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("time     : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(time);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Location           : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(target);

            terrorist.Pront();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");

            Console.ResetColor(); 
        }

    }
    
}
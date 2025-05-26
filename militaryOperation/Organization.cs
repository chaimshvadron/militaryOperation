namespace Military_control_system
{
    public class Organization
    {
        public string EstablishmentDate, CurrentCommander, Name; // Date of establishment of the organization and current commander
        public Organization(string name, string establishmentDate, string currentCommander)
        {
            EstablishmentDate = establishmentDate;
            CurrentCommander = currentCommander;
            Name = name;
            Print();
        }

        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n =====================>> {Name} <<=====================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    The organization was created successfully.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    Date of establishment: {EstablishmentDate}");
            Console.WriteLine($"    Current census: {CurrentCommander}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" =============================================\n");
            Console.ResetColor();
        }
    }
}
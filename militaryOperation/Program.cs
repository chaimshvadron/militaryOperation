namespace Military_control_system
{
    class Program
    {
        static void Main(string[] args)
        {
            Organization Hamas = new("Hamas", "1987.12.10", "Yahya Sinwar");
            Organization Idf = new("IDF", "1948.5.26", "Herzi Halevi");

            Console.WriteLine("Enter your name.");
            string officerName = Console.ReadLine();

            ControlSystem controlSystem = new(Idf,Hamas, officerName);
            new Menu(controlSystem).MenuActivation();
        }   
    }    
}

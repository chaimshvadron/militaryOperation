namespace militaryOperation.Aman
{
    class Aman
    {

        public void IntelligenceInformation()
        {
            Console.WriteLine("Intelligence information added to the database successfully!!");
        }
    }

    class IntelligenceInformation
    {
        public Terrorist Terrorist;
        public string LastLocation;
        public DateTime Timestamp = DateTime.UtcNow;
        public IntelligenceInformation(Terrorist terroristObject, string lastLocation)
        {
            Terrorist = terroristObject;
            LastLocation = lastLocation;
        }
    }

    class DatabaseAman
    {

    }
    

    internal class Terrorist
    {
    }
}
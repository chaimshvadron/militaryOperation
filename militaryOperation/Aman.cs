namespace militaryOperation.Aman
{
    public class Aman
    {
        DatabaseAman Database = new();
        public void IntelligenceInformation()
        {
            Console.WriteLine("Intelligence information added to the database successfully!!");
        }

        protected List<IntelligenceInformation> GetIntelligenceInformationList()
        {
            return Database.Get();
        }
    }

    public class IntelligenceInformation
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

    public class DatabaseAman
    {
        List<IntelligenceInformation> ListIntelligenceInformation { get; } = new();
        public List<IntelligenceInformation> Get()
        {
            return ListIntelligenceInformation;
        }

        
        // public void Add()
        // {
        //     return ListIntelligenceInformation;
        // }
        
    }

}
namespace MilitaryOperation.Models
{
    public class Aman
    {
        DatabaseAman Database = new();
        public void AddIntelligenceInformation(Terrorist terroristObject, string lastLocation)
        {
            IntelligenceInformation Information = new IntelligenceInformation(terroristObject, lastLocation);
            Database.AddToList(Information);
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

        public void AddToList(IntelligenceInformation Information)
        {
            ListIntelligenceInformation.Add(Information);
            Console.WriteLine("===== Ad information added successfully ======");
            Console.WriteLine($"Name: {Information.Terrorist.Name}");
            Console.WriteLine($"Date: {Information.Timestamp}");
        }
    }
}
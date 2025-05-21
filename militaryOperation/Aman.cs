using militaryOperation.Enemy;


namespace militaryOperation.Aman
{
    public class Aman
    {
        DatabaseAman Database = new();
        public void AddIntelligenceInformation(Terrorist terroristObject, string lastLocation)
        {
            Database.AddToList(terroristObject, lastLocation);
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

        public void AddToList(Terrorist terroristObject, string lastLocation)
        {
            IntelligenceInformation Information = new IntelligenceInformation(terroristObject, lastLocation);
            ListIntelligenceInformation.Add(Information);
        }

    }

}
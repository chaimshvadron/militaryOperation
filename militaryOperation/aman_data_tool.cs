
namespace MilitaryOperation.Models
{
    public class IntelInformation
    {
        public Terrorist Terrorist;
        public string LastLocation;
        public DateTime Timestamp = DateTime.UtcNow;
        public IntelInformation(Terrorist terroristObject, string lastLocation)
        {
            Terrorist = terroristObject;
            LastLocation = lastLocation;
        }
    }

    public class DatabaseAman
    {
        List<IntelInformation> ListIntelligenceInformation { get; } = new();
        public List<IntelInformation> Get()
        {
            return ListIntelligenceInformation;
        }

        public void AddToList(IntelInformation Information)
        {
            ListIntelligenceInformation.Add(Information);
            Console.WriteLine("===== Ad information added successfully ======");
            Console.WriteLine($"Name: {Information.Terrorist.Name}");
            Console.WriteLine($"Date: {Information.Timestamp}");
        }
    }

    public class IdentifyingTerrorists
    {
        // Hamas hamas;
        // public List<Terrorist> TerroristIist;

        // public IdentifyingTerrorists(Hamas hamasObject)
        // {
        //     hamas = hamasObject;
        //     TerroristIist = hamas.ListTerrorist;

        //     foreach (Terrorist terrorist in TerroristIist)
        //     {

        //     }
        // }        
    }

    public class CreatingAttack
    {
        DateTime Timestamp = DateTime.UtcNow;
        Terrorist target;
        string OfficerName;
        IntelInformation LatestIntelligence;
        // ???? AmmunitionUsed;

        public Dictionary<string, string> CancellationToken()
        {
            
            return new Dictionary<string, string>() { { "ss", "ss" } };
        }
    }
}
namespace MilitaryOperation.Models
{
    public class Aman
    {
        DatabaseAman Database = new();
        Hamas hamas;
        List<Terrorist> TerroristIist;

        public Aman(Hamas hamasObject)
        {
            hamas = hamasObject;
            TerroristIist = hamas.ListTerrorist;
        }

        public void AddIntelligenceInformation(Terrorist terroristObject, string lastLocation)
        {
            IntelInformation Information = new IntelInformation(terroristObject, lastLocation);
            Database.AddToList(Information);
        }

        public List<IntelInformation> GetIntelligenceInformationList()
        {
            return Database.Get();
        }

        public void GetTheLatestInformation()
        {

        }
    }
}
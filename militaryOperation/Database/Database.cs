namespace MilitaryControlSystem
{
    static class Database
    {
        static public Dictionary<int, Terrorist> databaseTerrorist = new(); // ID של מחבל 
        static public Dictionary<int, List<IntelInformation>> databaseIntelligence = new(); // ID של מחבל  ןמודיעין


        static public int AddTerrorist(Terrorist terrorist)
        {
            int id = databaseTerrorist.Count + 1;
            databaseTerrorist.Add(id, terrorist);
            return id;
        }

        static public void AddIntelligence(int id, IntelInformation intelInformation)
        {
            if (!databaseIntelligence.ContainsKey(id))
            {
                databaseIntelligence.Add(id, new List<IntelInformation>());
            }
            databaseIntelligence[id].Add(intelInformation);
        }

        static public Terrorist GetTerroristBiId(int id)
        {
            return databaseTerrorist[id];
        }

        static public IntelInformation LatestInformation(int id)
        {
            List<IntelInformation> ListIntelligence = databaseIntelligence[id];
            IntelInformation LatestInformation = ListIntelligence[0];
            foreach (IntelInformation information in ListIntelligence)
            {
                if (information.Timestamp > LatestInformation.Timestamp)
                {
                    LatestInformation = information;
                }
            }
            return LatestInformation;
        }
        
    }
    
}
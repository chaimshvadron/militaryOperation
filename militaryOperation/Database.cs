namespace Military_control_system
{
    class Database
    {
        public Dictionary<int, Terrorist> databaseTerrorist = new(); // ID של מחבל 
        public Dictionary<int, List<IntelInformation>> databaseIntelligence = new(); // ID של מחבל  ןמודיעין


        public int AddTerrorist(Terrorist terrorist)
        {
            int id = databaseTerrorist.Count + 1;
            databaseTerrorist.Add(id, terrorist);
            return id;
        }

        public void AddIntelligence(int id, IntelInformation intelInformation)
        {
            if (!databaseIntelligence.ContainsKey(id))
            {
                databaseIntelligence.Add(id, new List<IntelInformation>());
            }
            databaseIntelligence[id].Add(intelInformation);
        }

        public Terrorist GetTerroristBiId(int id)
        {
            return databaseTerrorist[id];
        }

        public IntelInformation LatestInformation(int id)
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
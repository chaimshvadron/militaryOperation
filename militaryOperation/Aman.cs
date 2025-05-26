namespace Military_control_system
{
    class Aman
    {
        public Database Database;
        public Aman(Database database)
        {
            Database = database;
        }

        public int mostDangerousTerrorist()
        {
            int Score = 0;
            int IdTerrorist = 0;
            for (int id = 1; id < Database.databaseTerrorist.Count; id++)
            {
                
                Terrorist terrorist = Database.databaseTerrorist[id];
                Console.WriteLine(terrorist.Name + " " +terrorist.QualityScore() + " " + terrorist.Rank);
                if (terrorist.IsAlive && terrorist.QualityScore() > Score)
                {
                    IdTerrorist = id;
                    Score = terrorist.QualityScore();
                    // Console.WriteLine($"terrorist name: {terrorist.Name}  ====== Quality Score: {terrorist.QualityScore()}");
                }
            }
            return IdTerrorist;
        }

        public int mostInformation()
        {
            int IdTerrorist = 1;
            for (int id = 1; id < Database.databaseIntelligence.Count; id++)
            {
                Terrorist terrorist = Database.databaseTerrorist[id];
                if (terrorist.IsAlive && Database.databaseIntelligence[id].Count > Database.databaseIntelligence[IdTerrorist].Count)
                {
                    IdTerrorist = id;
                    Console.WriteLine($"terrorist name: {terrorist.Name}  ====== Intelligence: {Database.databaseIntelligence[id].Count}");
                }
            }
            return IdTerrorist;
        }

    }
    
    class IntelInformation
    {
        public int Id;
        public string LastLocation;
        public DateTime Timestamp = DateTime.UtcNow;
        public IntelInformation(int IdTerrorist, string lastLocation)
        {
            Id = IdTerrorist;
            LastLocation = lastLocation;
        }
        
    }
    
}
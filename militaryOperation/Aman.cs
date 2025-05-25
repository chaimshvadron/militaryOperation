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
            int IdTerrorist = 1;
            for (int id = 1; id < Database.databaseIntelligence.Count; id++)
            {
                Terrorist terrorist = Database.databaseTerrorist[id];
                if (terrorist.IsAlive && terrorist.QualityScore() > Database.GetTerroristBiId(IdTerrorist).QualityScore())
                {
                    IdTerrorist = id;
                    Console.WriteLine($"terrorist name: {terrorist.Name}  ====== Quality Score: {terrorist.QualityScore()}");
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
    
}
namespace MilitaryControlSystem
{
    class Aman
    {
        public int mostDangerousTerrorist()
        {
            int Score = 0;
            int IdTerrorist = 0;
            for (int id = 1; id < Database.databaseTerrorist.Count; id++)
            {
                Terrorist terrorist = Database.databaseTerrorist[id];
                int scoreTerorrist = terrorist.QualityScore();

                if (terrorist.IsAlive && scoreTerorrist > Score)
                {
                    IdTerrorist = id;
                    Score = scoreTerorrist;
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
                    // Console.WriteLine($"terrorist name: {terrorist.Name}  ====== Intelligence: {Database.databaseIntelligence[id].Count}");
                }
            }
            return IdTerrorist;
        }

    }
    
}
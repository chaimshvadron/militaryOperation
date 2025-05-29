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

        public int MostInformation()
        {
            int IdTerrorist = -1;
            int mostInformation = 0;
            foreach (KeyValuePair<int, List<IntelInformation>> pair in Database.databaseIntelligence)
            {
                if (pair.Value.Count > mostInformation)
                {
                    IdTerrorist = pair.Key;
                    mostInformation = pair.Value.Count;
                }
            }
            return IdTerrorist;
        }

    }
    
}
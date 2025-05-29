
namespace MilitaryControlSystem
{
    class Attack_Management
    {
        string OfficerName;
        public Force Force;
        public Attack_Management( string officerName, Force force)
        {
            OfficerName = officerName;
            Force = force;
        }

        public void AttackExecution(int terroristId, int fuel, int ammunition)
        {
            DateTime time = DateTime.Now;
            Terrorist terrorist = Database.GetTerroristBiId(terroristId);
            IntelInformation LatestIntelligence = Database.LatestInformation(terroristId);
            string target = LatestIntelligence.LastLocation;

            foreach (AttackSystem attackSystem in Force.militaryAssets)
            {
                if (attackSystem.YaelAgainstTarget(target))
                {
                    bool attac = attackSystem.ExecuteStrike(target, fuel, ammunition);
                    if (attac)
                    {
                        terrorist.IsAlive = false;
                        PrintModel.PrintAttacsSuccessMessage(target, time, terrorist);
                        return;
                    }
                }
            }
            Console.WriteLine("No suitable weapon system found!! ");
        }

    }

}

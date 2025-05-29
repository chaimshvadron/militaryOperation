
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

        public void AttackExecution(int terroristId)
        {
            DateTime time = DateTime.Now;
            Random random = new();
            Terrorist terrorist = Database.GetTerroristBiId(terroristId);
            IntelInformation LatestIntelligence = Database.LatestInformation(terroristId);
            string target = LatestIntelligence.LastLocation;

            foreach (AttackSystem attackSystem in Force.militaryAssets)
            {
                if (attackSystem.TargetTypeAndWeapon.ContainsKey(target))
                {
                    bool attac = attackSystem.ExecuteStrike(target, random.Next(100,300), random.Next(1,5));
                    if (attac)
                    {
                        terrorist.IsAlive = false;
                        PrintModel.PrintSuccessMessage(target, time, terrorist);
                        return;
                    }
                }
            }
            Console.WriteLine("No suitable weapon system found!! ");
        }

    }

}


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

            foreach (AttackSystem attackSystem in Force.attackSystems)
            {
                if (attackSystem.TargetTypeAndWeapon.ContainsKey(target))
                {
                    bool attac = attackSystem.ExecuteStrike(target, random.Next(100,300), random.Next(1,5));
                    if (attac)
                    {
                        terrorist.IsAlive = false;
                        PrintSuccessMessage(target, time, terrorist);
                        return;
                    }
                }
            }
            Console.WriteLine("No suitable weapon system found!! ");
        }

        public void PrintSuccessMessage(string target, DateTime time, Terrorist terrorist)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");
            Console.WriteLine("     Attack successfully carried out"    );
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("time     : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(time);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Location           : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(target);

            terrorist.Print();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================================");

            Console.ResetColor(); 
        }

    }

}

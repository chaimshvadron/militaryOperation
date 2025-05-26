
namespace Military_control_system
{
    class Attack_Management
    {
        string OfficerName;
        public Database Database;
        public Force Force;
        public Attack_Management(Database database, string officerName, Force force)
        {
            OfficerName = officerName;
            Database = database;
            Force = force;

        }

        public void AttackExecution(int terroristId)
        {
            DateTime time = DateTime.Now;
            Terrorist terrorist = Database.GetTerroristBiId(terroristId);
            IntelInformation LatestIntelligence = Database.LatestInformation(terroristId);
            string target = LatestIntelligence.LastLocation;

            foreach (AttackSystem attackSystem in Force.attackSystems)
            {
                if (attackSystem.TargetTypeAndWeapon.ContainsKey(target))
                {
                    bool attac = attackSystem.ExecuteStrike(target);
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

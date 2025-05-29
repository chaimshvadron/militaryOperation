namespace MilitaryControlSystem
{
    public class ControlSystem
    {
        Aman aman;
        Force force;
        Attack_Management attack_Management;
        public ControlSystem(Organization organization, Organization organizationEnemy, string officerName)
        {
            initialization.InitializeDatabase(organizationEnemy);

            aman = new();
            force = new(organization, initialization.initializationAttackSystem());
            attack_Management = new(officerName, force);
        }

        public void IntelligenceAnalysis()
        {
            int IdTerrorist = aman.mostInformation();
            Terrorist terrorist = Database.GetTerroristBiId(IdTerrorist);

            Console.WriteLine(" ======= The terrorist with the most intelligence =======");
            terrorist.Print();

        }
        public void AttackAvailability()
        {

            force.Print();
        }

        public void TargetPrioritization()
        {
            int IdTerrorist = aman.mostDangerousTerrorist();
            if (IdTerrorist == 0)
            {
                Console.WriteLine(" ===== No dangerous terrorist found =====");
                return;
            }
            Terrorist terrorist = Database.GetTerroristBiId(IdTerrorist);

            Console.WriteLine(" ======= The most dangerous terrorist =======");
            terrorist.Print();

        }

        public void AttackExecution()
        {
            int IdTerrorist = aman.mostDangerousTerrorist();
            attack_Management.AttackExecution(IdTerrorist);

        }

        public void StatusDatabase()
        {
            Console.WriteLine();
            foreach (var item in Database.databaseTerrorist)
            {
                Console.WriteLine(item.Key);
                item.Value.Print();
                Console.WriteLine("====================");
                foreach (var item2 in Database.databaseIntelligence[item.Key])
                {

                    Console.WriteLine($"Last Location:{item2.LastLocation}   ====   Timestamp: {item2.Timestamp}");

                }
                Console.WriteLine("====================");
            }
        }

    }
    
}
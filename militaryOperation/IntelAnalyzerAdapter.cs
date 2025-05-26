// namespace Military_control_system
// {
//     // Adapter class to bridge between your system and your friend's code
//     class IntelAnalyzerAdapter
//     {
//         private Database _database;
//         private IntelAnalyzer _intelAnalyzer;

//         public IntelAnalyzerAdapter(Database database)
//         {
//             _database = database;
//             _intelAnalyzer = new IntelAnalyzer();
//         }

//         public int MostDangerousTerrorist()
//         {
//             // Convert your database format to what your friend's code expects
//             var allIntel = new List<IntelInformation>();
//             foreach (var kvp in _database.databaseIntelligence)
//             {
//                 allIntel.AddRange(kvp.Value);
//             }

//             // Use your friend's analysis
//             var result = _intelAnalyzer.MostDangerousTerrorist(allIntel);
            
//             // Find the matching ID in your system
//             foreach (var kvp in _database.databaseTerrorist)
//             {
//                 if (kvp.Value.Name == result.Terrorist.Name && 
//                     kvp.Value.Rank == result.Terrorist.Rank)
//                 {
//                     return kvp.Key;
//                 }
//             }
            
//             return -1; // fallback if not found
//         }

//         public int MostInformation()
//         {
//             // Convert your database format to what your friend's code expects
//             var allIntel = new List<IntelInformation>();
//             foreach (var kvp in _database.databaseIntelligence)
//             {
//                 allIntel.AddRange(kvp.Value);
//             }

//             // Use your friend's analysis
//             var result = _intelAnalyzer.GetMostReportedTerrorist(allIntel);
            
//             // Find the matching ID in your system
//             foreach (var kvp in _database.databaseTerrorist)
//             {
//                 if (kvp.Value.Name == result.Name && 
//                     kvp.Value.Rank == result.Rank)
//                 {
//                     return kvp.Key;
//                 }
//             }
            
//             return -1; // fallback if not found
//         }
//     }

//     // Modified IntelInformation to work with both systems
//     class IntelInformation
//     {
//         public int Id;
//         public string LastLocation;
//         public DateTime Timestamp = DateTime.UtcNow;
//         public Terrorist Terrorist => Database.GetTerroristById(Id); // New property

//         public IntelInformation(int IdTerrorist, string lastLocation)
//         {
//             Id = IdTerrorist;
//             LastLocation = lastLocation;
//         }
//     }

//     // Modified Terrorist class to work with both systems
//     public class Terrorist
//     {
//         public string Name;
//         public int Rank;
//         public bool IsAlive;
//         public List<string> Weapons;
//         public Organization Organization;
        
//         // Alias for compatibility with friend's code
//         public List<string> WeaponList => Weapons;

//         public Terrorist(string name, int rank, bool status, List<string> weaponList, Organization organization)
//         {
//             Name = name;
//             Rank = rank;
//             IsAlive = status;
//             Weapons = weaponList;
//             Organization = organization;
//         }

//         // ... rest of your existing Terrorist class ...
//     }
// }
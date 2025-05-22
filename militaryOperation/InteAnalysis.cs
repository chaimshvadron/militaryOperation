using militaryOperation.AmanManagement;
using militaryOperation.Enemy;

namespace militaryOperation.IntelligenceAnalysis
{
    public class IntelAnalyzer
    {
        public Dictionary<Terrorist, List<IntelligenceInformation>> GroupIntelligenceByTerrorist(List<IntelligenceInformation> intelligenceReports)
        {
            Dictionary<Terrorist, List<IntelligenceInformation>> groupedReports = new();

            foreach (IntelligenceInformation report in intelligenceReports)
            {
                if (!groupedReports.ContainsKey(report.Terrorist))
                {
                    groupedReports[report.Terrorist] = new List<IntelligenceInformation>();
                }
                groupedReports[report.Terrorist].Add(report);
            }

            return groupedReports;
        }


        public Terrorist GetMostReportedTerrorist(List<IntelligenceInformation> IntelligenceInformation)
        {
            int max = 0;
            Terrorist mostReported = null ;

            foreach (KeyValuePair<Terrorist, List<IntelligenceInformation>> group in GroupIntelligenceByTerrorist(IntelligenceInformation))
            {
                if (group.Value.Count > max)
                {
                    max = group.Value.Count;
                    mostReported = group.Key;
                }
            }

            return mostReported;
        }
    }
}
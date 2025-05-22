

namespace MilitaryOperation.Models
{
    public class IntelAnalyzer
    {
        public Dictionary<Terrorist, List<IntelInformation>> GroupIntelligenceByTerrorist(List<IntelInformation> intelligenceReports)
        {
            Dictionary<Terrorist, List<IntelInformation>> groupedReports = new();

            foreach (IntelInformation report in intelligenceReports)
            {
                if (!groupedReports.ContainsKey(report.Terrorist))
                {
                    groupedReports[report.Terrorist] = new List<IntelInformation>();
                }
                groupedReports[report.Terrorist].Add(report);
            }

            return groupedReports;
        }


        public Terrorist GetMostReportedTerrorist(List<IntelInformation> IntelInformation)
        {
            int max = 0;
            Terrorist mostReported = null ;

            foreach (KeyValuePair<Terrorist, List<IntelInformation>> group in GroupIntelligenceByTerrorist(IntelInformation))
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
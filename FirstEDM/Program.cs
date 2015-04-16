using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using System.Data.Entity.Infrastructure;

namespace FirstEDM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var opleidingenEntities = new OpleidingenEntities())
            {
                var query = from bestBetaaldeDocentPerCampus in opleidingenEntities.BestBetaaldeDocentenPerCampus
                            orderby bestBetaaldeDocentPerCampus.CampusNr,
                            bestBetaaldeDocentPerCampus.Voornaam,
                            bestBetaaldeDocentPerCampus.Familienaam
                            select bestBetaaldeDocentPerCampus;
                var vorigCampusNr = 0;
                foreach (var bestbetaaldeDocentPerCampus in query)
                {
                    if (bestbetaaldeDocentPerCampus.CampusNr != vorigCampusNr)
                    {
                        Console.WriteLine("{0} {1} Grootste wedde:",
                        bestbetaaldeDocentPerCampus.Naam, bestbetaaldeDocentPerCampus.GrootsteWedde);
                        vorigCampusNr = bestbetaaldeDocentPerCampus.CampusNr;
                    }
                    Console.WriteLine("\t{0} {1}",
                    bestbetaaldeDocentPerCampus.Voornaam, bestbetaaldeDocentPerCampus.Familienaam);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var bankEntities = new BankEntities())
            //{
            //    var query = from klant in bankEntities.Klanten
            //                orderby klant.Voornaam
            //                select klant;
            //    foreach (var klant in query)
            //    {
            //        Console.WriteLine("{0}: {1}", klant.KlantNr, klant.Voornaam);
            //    }
            //    try
            //    {
            //        Console.Write("KlantNr:");
            //        var klantNr = int.Parse(Console.ReadLine());
            //        var klant = bankEntities.Klanten.Find(klantNr);
            //        if (klant == null)
            //        {
            //            Console.WriteLine("Klant niet gevonden");
            //        }
            //        else
            //        {
            //            Console.Write("RekeningNr:");
            //            var rekeningNr = Console.ReadLine();
            //            var rekening = new Rekening { RekeningNr = rekeningNr, Soort = "Z" };
            //            klant.Rekeningen.Add(rekening);
            //            bankEntities.SaveChanges();
            //        }
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Tik een getal");
            //    }
            //}

            //using (var bankEntities = new BankEntities())
            //{
            //    var query = from rekening in bankEntities.Rekeningen
            //                where rekening is Zichtrekening
            //                select rekening;
            //    foreach (var zichtrekening in query)
            //    {
            //        Console.WriteLine("{0}: \t {1} \t\t {2}",
            //        zichtrekening.RekeningNr, zichtrekening.Saldo, zichtrekening.GetType().Name);
            //    }
            //}


            using (var bankEntities = new BankEntities())
            {
                var query = from totaleSaldoPerKlant in bankEntities.TotaleSaldoPerKlant
                            orderby totaleSaldoPerKlant.Voornaam
                            select totaleSaldoPerKlant;
                foreach (var totaleSaldoPerKlant in query)
                    if (totaleSaldoPerKlant.TotaleSaldo != null)
                        Console.WriteLine("{0}: \t {1}", totaleSaldoPerKlant.Voornaam,
                        totaleSaldoPerKlant.TotaleSaldo);
            }


            //Console.WriteLine("Personeelslijst");
            //Console.WriteLine("---------------");
            //new Program().PersoneelsHyrarchie();

        }

        //using (var opleidingenEntities = new OpleidingenEntities())
        //    {
        //        var query = from mentor in opleidingenEntities.Cursisten.Include("Beschermelingen")
        //        where mentor.Beschermelingen.Count != 0
        //        orderby mentor.Voornaam, mentor.Familienaam
        //        select mentor;
        //        foreach (var mentor in query)
        //        {
        //            Console.WriteLine("{0} {1}", mentor.Voornaam, mentor.Familienaam);
        //            foreach (var beschermeling in mentor.Beschermelingen)
        //            {
        //                Console.WriteLine("\t{0} {1}", beschermeling.Voornaam,
        //                beschermeling.Familienaam);
        //            }
        //        }
        //}

        //void PersoneelsHyrarchie()
        //{
        //    using (var bankEntities = new BankEntities())
        //    {
        //        var hoogstenInHierarchie = (from personeelslid in bankEntities.Personeel
        //                                    where personeelslid.Manager == null
        //                                    select personeelslid).ToList();
        //        new Program().Afbeelden(hoogstenInHierarchie, 0);
        //    }
        //}

        //void Afbeelden(List<Personeelslid> personeel, int insprong)
        //{
        //    foreach (var personeelslid in personeel)
        //    {
        //        Console.Write(new String('\t', insprong));
        //        Console.WriteLine(personeelslid.Voornaam);
        //        if (personeelslid.Ondergeschikten.Count != 0)
        //        {
        //            Afbeelden(personeelslid.Ondergeschikten.ToList(), insprong + 1);
        //        }
        //    }
        //}



        //void klantWijzigen(int klantNr)
        //{
        //    using (var bankEntities = new BankEntities())
        //    {
        //        var klant = (from zoekKlant in bankEntities.Klanten
        //                     where zoekKlant.KlantNr == klantNr
        //                     select zoekKlant).FirstOrDefault();
        //        if (klant != null)
        //        {
        //            Console.WriteLine("Klanten naam is nu : {0}", klant.Voornaam);
        //            Console.Write(" Geef de nieuwe klanten naam");
        //            var klantNaam = Console.ReadLine();
        //            klant.Voornaam = klantNaam;
        //            try
        //            {
        //                Console.WriteLine("Nu kan je de klant nog wijzigen in een andere applicatie");
        //                Console.ReadLine();
        //                bankEntities.SaveChanges();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                Console.WriteLine("Klant werd door andere applicatie aangepast.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Klant niet gevonden");
        //        }
        //    }
        //}

        //void overschrijvingTransfer(string vanNr, string naarNr, decimal bedrag)
        //{
        //    var transactionOptions = new TransactionOptions
        //       {
        //           IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
        //       };
        //    using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
        //    {
        //        using (var bankEntities = new BankEntities())
        //        {
        //            var vanRekening = bankEntities.Rekeningen.Find(vanNr);
        //            if (vanRekening != null)//kijken of de van rekening bestaat
        //            {
        //                if (vanRekening.Saldo >= bedrag)//kijken  of er genoeg geld op de rekening staat
        //                {
        //                    vanRekening.Saldo -= bedrag;
        //                    var naarRekening = bankEntities.Rekeningen.Find(naarNr);
        //                    if (naarRekening != null)//kijken of de naar rekening bestaat
        //                    {
        //                        naarRekening.Saldo += bedrag;
        //                        bankEntities.SaveChanges();
        //                        transactionScope.Complete();
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Kan Geen overschrijving uit voer naar gekozen rekening want die bestaat niet");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Saldo ontoereikbaar");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("De gekozen rekening waar u geld van wil overschrijven bestaat niet");
        //            }
        //        }
        //    }
        //}

        //try
        //{

        //    using (var bankEntities = new BankEntities())
        //    {
        //        var klant = bankEntities.Klanten.Find(klantNr);
        //        if (klant != null)
        //        {
        //            if (klant.Rekeningen.Count() == 0)
        //            {
        //                bankEntities.Klanten.Remove(klant);
        //                bankEntities.SaveChanges();
        //            }
        //            else
        //            {
        //                Console.WriteLine("Klant heeft nog rekeningen");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Klant niet gevonden");
        //        }
        //    }
        //}
        //catch (FormatException)
        //{
        //    Console.WriteLine("tik een getal");
        //}



    }
}

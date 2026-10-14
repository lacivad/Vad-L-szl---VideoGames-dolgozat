using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vad_László_VideoGames_dolgozat
{
    internal class Program
    {
        static List<Game> games = new List<Game>();
        static void Main(string[] args)
        {
            DataLoad();
            //DataWrite();
            Console.WriteLine("Feladat 1.");
            games.Where(x => x.Ertekeles > 9).ToList().ForEach(y => Console.WriteLine(y.Nev));
            Console.WriteLine();
            Console.WriteLine("Feladat 2.");
            games.Where(x => x.Platform == "Nintendo Switch" && x.Kiadas_Eve > 2015 && x.Ertekeles >= 8).ToList().ForEach(y => Console.WriteLine(y.Nev));
            Console.WriteLine();
            Console.WriteLine("Feladat 3.");
            games.OrderByDescending(x => x.Kiadas_Eve).ToList().ForEach(y => Console.WriteLine(y.Nev));
            Console.WriteLine();
            Console.WriteLine("Feladat 4.");
            games.OrderByDescending(x => x.Ertekeles).Take(10).ToList().ForEach(y => Console.WriteLine($"{y.Nev}, {y.Ertekeles}"));
            Console.WriteLine();
            Console.WriteLine("Feladat 5.");
            games.GroupBy(x => x.Platform).Select(x => $"{x.Key} - {x.Count()}").ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 6.");
            games.GroupBy(x => x.Tipus).OrderBy(x => (x.Count())).Take(1).ToList().ForEach(y => Console.WriteLine(y.Key));
            Console.WriteLine();
            Console.WriteLine("Feladat 7.");
            Console.WriteLine(games.Average(x => x.Ertekeles));
            Console.WriteLine();
            Console.WriteLine("Feladat 8.");
            games.OrderBy(d => d.Ertekeles).GroupBy(x => x.Platform).Select(x => $"{x.Key} - {x.Average(z => z.Ertekeles)}").Take(1).ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 9.");
            games.Where(x => x.Ertekeles == games.Max(y => y.Ertekeles)).ToList().ForEach(z => Console.WriteLine($"{z.Nev}, {z.Ertekeles}"));
            games.Where(x => x.Ertekeles == games.Min(y => y.Ertekeles)).ToList().ForEach(z => Console.WriteLine($"{z.Nev}, {z.Ertekeles}"));
            Console.WriteLine();
            Console.WriteLine("Feladat 10.");
            games.Select(x => x.Tipus).Distinct().ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 11.");
            games.Select(x => $"{x.Nev} - {x.Kiadas_Eve}").ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 12.");
            games.Where(x => x.Tipus == "Action").OrderByDescending(z => z.Ertekeles).Select(l => $"{l.Nev}, {l.Kiadas_Eve}, {l.Ertekeles}").ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 13.");
            games.GroupBy(x => x.Tipus).Select(x => $"{x.Key} - {x.Average(t => t.Ertekeles)}").ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 14.");
            games.Where(x => x.Kiadas_Eve < 2005).Select(f => $"{f.Nev}, {f.Platform}").ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
            Console.WriteLine("Feladat 15.");
            games.OrderByDescending(h => h.Ertekeles).GroupBy(x => x.Platform).Select(x => $"{x.Key} - {x}").ToList().ForEach(y => Console.WriteLine(y));
            Console.WriteLine();
        }

        private static void DataWrite()
        {
            games.ForEach(i => Console.WriteLine($"{i.Nev}, {i.Tipus}, {i.Platform}, {i.Kiadas_Eve}, {i.Ertekeles}"));
        }

        private static void DataLoad()
        {
            games = File.ReadAllLines("László Vad - games_dataset.csv")
                .Skip(1)
                .Select(sor => sor.Split(';'))
                .Select(adat => new Game(adat[0], adat[1], adat[2], int.Parse(adat[3]), double.Parse(adat[4]))).ToList();
        }
    }
}

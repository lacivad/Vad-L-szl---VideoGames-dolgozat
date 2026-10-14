using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vad_László_VideoGames_dolgozat
{
    public class Game
    {
        public Game(string name, string tipus, string platform, int kiadas_Eve, double ertekeles)
        {
            Nev = name;
            Tipus = tipus;
            Platform = platform;
            Kiadas_Eve = kiadas_Eve;
            Ertekeles = ertekeles;
        }

        public string Nev { get; set; }
        public string Tipus { get; set; }
        public string Platform { get; set; }
        public int Kiadas_Eve { get; set; }
        public double Ertekeles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuggohidak
{
    class Fuggohid
    {
        public string Helyezes { get; set; }
        public string Nev { get; set; }
        public string Hely { get; set; }
        public int Hossz { get; set; }
        public int Ev { get; set; }

        public Fuggohid(string sor)
        {
            var temp = sor.Split('\t');
            Helyezes = temp[0];
            Nev = temp[1];
            Hely = temp[2];
            Hossz = int.Parse(temp[3]);
            Ev = int.Parse(temp[4]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGyakorlos.Models
{
    public class Orszag
    {

        public int Id { get; set; }

        public string Nev { get; set; }

        public string Fovaros { get; set; }

        public int Nepesseg { get; set; }

        public override string ToString()
        {
            return $"Ország id: {Id}, Név: {Nev}, Főváros: {Fovaros}, Népesség: {Nepesseg}";
        }
    }
}

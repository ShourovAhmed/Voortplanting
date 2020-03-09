using System;
using System.Collections.Generic;
using System.Text;

namespace Voortplanting
{
    enum Geslacht { Man, Vrouw}
    enum Oogkleur { Blauw, Bruin, Groen, Rood}
    class Mens
    {
        public Geslacht Geslacht { get; set; }
        public Oogkleur Oogkleur { get; set; }

        private double maxLengte;

        public double MaxLengte
        {
            get { return maxLengte; }
            set { maxLengte = value; }
        }





    }
}

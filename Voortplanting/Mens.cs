﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Voortplanting
{
    enum Geslacht { Man, Vrouw }
    enum Oogkleur { Blauw, Bruin, Groen, Rood }
    class Mens
    {
        static Random r = new Random();
        //Default constructor
        public Mens()
        {
            if (r.Next(0, 2) == 0)
            { Geslacht = Geslacht.Vrouw; }

            else
            { Geslacht = Geslacht.Man; }

            Oogkleur = (Oogkleur)r.Next(0, 4);//is een enum dus evenveel kans

            int percentlengte = r.Next(0, 100);
            if (percentlengte < 5)
            {
                MaxLengte = r.Next(40, 151);
            }
            else if (percentlengte >= 95)
            {
                MaxLengte = r.Next(151, 210);
            }
            else
            {
                MaxLengte = r.Next(151, 210);
            }
        }

        //Overloaded constructor
        public Mens(Oogkleur oogin, Geslacht geslin, double maxLengtein)
        {
            Oogkleur = oogin;
            Geslacht = geslin;
            MaxLengte = maxLengtein;
        }

        public Mens(Geslacht geslin) : this()//zo wordt de default const aangeroepen, eerst overschreven, dan gaat het verder (moet je niet alles van de default overtypen)
        {
            Geslacht = geslin;
        }

        //Eigenschappen
        public Geslacht Geslacht { get; private set; }//private set omdat je niet opeens je mens andere oogkleur of geslacht kan geven (voorlopig)
        public Oogkleur Oogkleur { get; private set; }

        private double maxLengte;
        private Geslacht vrouw;

        public double MaxLengte
        {
            get { return maxLengte; }
            private set { if (value >= 30) maxLengte = value; }
        }


        //Methoden
        public void ToonMens()
        {
            switch(Oogkleur)
            {
                case Oogkleur.Blauw:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case Oogkleur.Bruin:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Oogkleur.Groen:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case Oogkleur.Rood:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{MaxLengte/100.0: 0.00} m, {Geslacht}");
            Console.ResetColor();
        }

        public Mens Plantvoort(Mens man)
        {
            if (Geslacht == Geslacht.Vrouw && man.Geslacht == Geslacht.Man)//enkel vrouwen kunnen babys hebben en man parameter moet ook een man zijn
            {
                double lengtekind = (man.MaxLengte + this.MaxLengte) / 2;//this betekent het object waarin we nu zitten
                Oogkleur oogkind = this.Oogkleur;
                if (r.Next(0,2) == 0)
                {
                    oogkind = man.Oogkleur;//50% kans op kleur ogen van vader
                }
                Geslacht g = Geslacht.Man;
                if (r.Next(0,2) == 0)
                {
                    g = Geslacht.Vrouw;//50% kans op vrouw
                }

               return new Mens(oogkind, g, lengtekind);
            }
            else
                return null;//als het een man is, kunnen geen kinderen baren
        }




    }
}

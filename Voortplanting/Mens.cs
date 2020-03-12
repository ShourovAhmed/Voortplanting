﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Voortplanting
{
    enum Geslacht { Man, Vrouw }
    enum Oogkleur { Blauw, Bruin, Groen, Rood, Geel }
    class Mens
    {
        static Random r = new Random();

        //Default constructor
        public Mens()
        {
            Generatie = 0;

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
        public Mens(Oogkleur oogin, Geslacht geslin, double maxLengtein, int genin)
        {
            Oogkleur = oogin;
            Geslacht = geslin;
            MaxLengte = maxLengtein;
            Generatie = genin;
        }

        public Mens(Geslacht geslin) : this()//zo wordt de default const aangeroepen, eerst overschreven, dan gaat het verder (moet je niet alles van de default overtypen)
        {
            Geslacht = geslin;
        }

        //Eigenschappen/Propertiess

        public int Generatie { get; private set; }// private set omdat het onmogelijk is om persoon naar een andere generatie toe te schrijven
        public Geslacht Geslacht { get; private set; }//private set omdat je niet opeens je mens andere oogkleur of geslacht kan geven (voorlopig)
        public Oogkleur Oogkleur { get; private set; }

        private double maxLengte;

        public double MaxLengte
        {
            get { return maxLengte; }
            private set { if (value >= 30) maxLengte = value; }
        }


        //Methoden
        public void ToonMens()
        {
            switch (Oogkleur)
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
                case Oogkleur.Geel:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{MaxLengte / 100.0: 0.00} m, {Geslacht} ({Generatie})");
            Console.ResetColor();
        }

        public Mens Plantvoort(Mens man)
        {
            if (Geslacht == Geslacht.Vrouw && man.Geslacht == Geslacht.Man && this.Generatie == man.Generatie)//enkel vrouwen kunnen babys hebben en man parameter moet ook een man zijn
                                                                                                              //this hoeft er niet bij, je kan ook gewoon Generatie schrijven
            {
                double lengtekind = (man.MaxLengte + this.MaxLengte) / 2;//this betekent het object waarin we nu zitten
                Oogkleur oogkind = this.Oogkleur;
                if (r.Next(0, 2) == 0)
                {
                    oogkind = man.Oogkleur;//50% kans op kleur ogen van vader
                }

                if (r.Next(0, 101) == 0)
                {
                    oogkind = Oogkleur.Geel;
                }

                Geslacht g = Geslacht.Man;
                if (r.Next(0, 2) == 0)
                {
                    g = Geslacht.Vrouw;//50% kans op vrouw
                }

                return new Mens(oogkind, g, lengtekind, Generatie + 1);
            }
            else
                return null;//als het een man is, kunnen geen kinderen baren
        }

        public static void Simuleer(List<Mens> testlijst, int gentest = 5)
        {
            for (int i = 0; i < gentest; i++)
            {
                List<Mens> deKribbe = new List<Mens>();
                foreach (var mens in testlijst)
                {
                    int partner = r.Next(0, testlijst.Count);
                    Mens babynew = mens.Plantvoort(testlijst[partner]);
                    if (babynew != null)
                    {
                        deKribbe.Add(babynew);
                    }

                }



                testlijst.AddRange(deKribbe);//nadat alle babys zijn gemaakt en in deKribbe lijst zijn geplaats -> deze lijst aan de bestaande toevoegen
            }

            //Statistieken verkrijgen
            GenereerStats(testlijst, gentest);

            //effe in commentaar om niet iedereen te tonen

            //foreach (var mens in testlijst)
            //{
            //    mens.ToonMens();
            //}

        }

        private static void GenereerStats(List<Mens> deKribbe, int aantalgens)
        {
            for (int i = 0; i < aantalgens; i++)
            {
                int aantalVrouwen = 0;
                double gemiddeldeLengte = 0.0;
                int aantalinGen = 0;
                int aantalGeel = 0;

                foreach (var mens in deKribbe)
                {
                    if (mens.Generatie == i)
                    {
                        if (mens.Oogkleur == Oogkleur.Geel)
                        {
                            aantalGeel++;
                        }
                        if (mens.Geslacht == Geslacht.Vrouw)
                        {
                            aantalVrouwen++;
                        }

                    }
                    gemiddeldeLengte += mens.MaxLengte;
                    aantalinGen++;


                }
                gemiddeldeLengte = gemiddeldeLengte / aantalinGen;

                Console.WriteLine($"Generatie {i}");
                Console.WriteLine($"\tGemiddelde lengte = {gemiddeldeLengte}");
                Console.WriteLine($"\tAantal vrouwen: {aantalVrouwen}/{aantalinGen}");
                Console.WriteLine($"\tMensen met gele ogen: {aantalGeel}");
            }



        }
    }
}

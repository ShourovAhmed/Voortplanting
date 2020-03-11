using System;
using System.Collections.Generic;

namespace Voortplanting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mens> mensen = new List<Mens>();

            for (int i = 0; i < 6; i++)
            {
                mensen.Add(new Mens(Geslacht.Vrouw));
            }

            for (int i = 0; i < 6; i++)
            {
                mensen.Add(new Mens(Geslacht.Man));
            }

            foreach (var mens in mensen)
            {
                mens.ToonMens();
            }

            Mens baby;
            baby = mensen[0].Plantvoort(mensen[11]);//kind van 1ste vrouw met laatste man

            Console.WriteLine("\n");
            Console.Write("Baby: "); baby.ToonMens();





        }
    }
}


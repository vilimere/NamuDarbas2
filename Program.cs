using System;
using System.Collections.Generic;
using System.Linq;

namespace Mokomes_namie
{


    class Program
    {
        static void Main()
        {

            int skPirmas = 100000;

            while (skPirmas < 1000000)
            {
                if (Tinkamas(skPirmas) == true)
                {
                    break;
                }
                else
                {
                    skPirmas++;
                }
            }
        }

        static bool Tinkamas(int pirmasSkaicius)
        {
            int[] pirmoSkaiciausMasyvas = Pervertimas(pirmasSkaicius);

            if (PirmoSkaiciausPatikra(pirmasSkaicius) == false)
            {
                return false;
            }
            else
            {
                if (SkaiciausPatikra(pirmasSkaicius, 2, pirmoSkaiciausMasyvas) == false)
                    return false;

                if (SkaiciausPatikra(pirmasSkaicius, 3, pirmoSkaiciausMasyvas) == false)
                    return false;

                if (SkaiciausPatikra(pirmasSkaicius, 4, pirmoSkaiciausMasyvas) == false)
                    return false;

                if (SkaiciausPatikra(pirmasSkaicius, 5, pirmoSkaiciausMasyvas) == false)
                    return false;

                if (SkaiciausPatikra(pirmasSkaicius, 6, pirmoSkaiciausMasyvas) == false)
                    return false;

                Console.WriteLine("Stebuklingas skaicius yra surastas!!!");
                Console.WriteLine($"Pirmas sk: {pirmasSkaicius}");
                Console.WriteLine($"Antras sk: {pirmasSkaicius * 2}");
                Console.WriteLine($"Trecias sk: {pirmasSkaicius * 3}");
                Console.WriteLine($"Ketvirtas sk: {pirmasSkaicius * 4}");
                Console.WriteLine($"Penktas sk: {pirmasSkaicius * 5}");
                Console.WriteLine($"Sestas sk: {pirmasSkaicius * 6}");
                return true;
            }
        }

        static bool SkaiciausPatikra(int skaicius, int daugiklis, int[] pirmoSkaiciausMasyvas)
        {
            //Pirmas skaicius padaugintas is daugiklio
            skaicius = skaicius * daugiklis;
            //is pirminio skaiciaus padarom masyva 
            int[] tempRezultatas = new int[6];
            tempRezultatas = Pervertimas(skaicius);


            if (AllDiff(tempRezultatas) == false)
            {
                //tikrinam ar masyvo sk nesikartoja
                return false;

            }
            else if (MasyvuCheck(pirmoSkaiciausMasyvas, tempRezultatas) == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        static bool PirmoSkaiciausPatikra(int skaicius)
        {
            //is pirminio skaiciaus padarom masyva 
            int[] tempRezultatas = new int[6];
            tempRezultatas = Pervertimas(skaicius);


            if (AllDiff(tempRezultatas) == false)
            {
                //tikrinam ar masyvo sk nesikartoja
                return false;

            }
            else
            {
                return true;
            }

        }

         static int[] Pervertimas(int skaicius)
        {
            List<int> rezultatas = new List<int>();

            while (skaicius != 0)
            {
                rezultatas.Insert(0, skaicius % 10);
                skaicius /= 10;
            }
            return rezultatas.ToArray();
        }


        static bool AllDiff(int[] tempMasyvas)
        {
            bool statusas = true;
            int stabdymas = 0;

            do
            {
                for (int i = 0; i < tempMasyvas.Length; i++)
                {
                    int tinkrinimasSk = tempMasyvas[i];

                    for (int j = i + 1; j < tempMasyvas.Length; j++)
                    {
                        
                        if (tempMasyvas[i] == tempMasyvas[j])
                        {
                            statusas = false;
                        }
                        else
                        {
                            stabdymas++;
                        }
                    }
                }
            } while (statusas == true && stabdymas < 6);

            return statusas;
        }

        static bool MasyvuCheck(int[] tempMasyvas1, int[] TempMasyvas2)
        {
            for (int i = 0; i < tempMasyvas1.Length; i++)
            {
                if (TempMasyvas2.Contains(tempMasyvas1[i]) && TempMasyvas2[i] != tempMasyvas1[i])
                    continue;

                return false;
            }

            return true;
        }

    }
}

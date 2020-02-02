using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szamsorozat
{
    class Program
    {
        static List<int> szamok = new List<int>();
        static void Main(string[] args)
        {
            ForrastBeolvas();
            Console.WriteLine($"\n2. Feladat: Elemek száma a sorozatban: {szamok.Count} db");
            
            Console.WriteLine($"\n3. Feladat: Páratlan számok:");
            Console.WriteLine($"\tÖsszege: {szamok.Where(a => a%2 != 0).Sum()}");
            Console.WriteLine($"\tDarabszáma: {szamok.Where(a => a%2 != 0).Count()}");
            Console.WriteLine($"\tÁtlaga: {szamok.Where(a => a%2 != 0).Average()}");

            Console.WriteLine("\n5. Feladat");
            Console.Write("\tKérem az állomány nevét: ");
            string fajlnev = Console.ReadLine().Trim();
            Console.Write("\tKérem a kezdő indexet: ");
            int kezd = int.Parse(Console.ReadLine().Trim());
            Console.Write("\tKérem a részsorozat hosszát: ");
            int hossz = int.Parse(Console.ReadLine().Trim());
            Alprogram(fajlnev,ref szamok, kezd, hossz);

            Console.WriteLine("6. Feladat: Első leghosszabb szigorúan monoton növekvő sorozat:");
            kezd = 0;
            hossz = 0;
            int max = hossz;
            for (int i = 0; i < szamok.Count-1; i++)
            {
                if (szamok[i] < szamok[i+1])
                {
                    hossz++;
                }
                else
                {
                    if (hossz>max)
                    {
                        max = hossz;
                        kezd = i - hossz + 1;
                    }
                    hossz = 1;
                }
            }
            Console.WriteLine($"\tHossza: {max}");
            Console.WriteLine($"\tKezdő indexe: {kezd}");
            Alprogram("leghosszabb.txt", ref szamok, kezd, max);

            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        static void ForrastBeolvas()
        {
            string forras = @"..\..\sorozat.txt";
            using (StreamReader sr = new StreamReader(forras))
            {
                while (!sr.EndOfStream)
                {
                    szamok.Add(int.Parse(sr.ReadLine()));
                }
            }
        }
        /// <summary>
        /// 4. Készítsen alprogramot, ami egy szöveges fájlban egy számsorozat részét tárolja el
        ///    soronként! Az alprogram paraméterei a következők legyenek!
        /// </summary>
        /// <param name="fajl"> Az állomány neve.</param>
        /// <param name="szamok"> A számsorozatot tároló adatszerkezet neve.</param>
        /// <param name="kezd"> A sorozat kezdetének indexe, ahonnan meg kell kezdeni a fájlba írást.</param>
        /// <param name="hossz"> A fájlba írandó részsorozat hossza.</param>
        static void Alprogram(string fajl,ref List<int> szamok, int kezd, int hossz)
        {
            //Console.WriteLine("4. Feladat:");
            using (StreamWriter sw = new StreamWriter(fajl))
            {
                int utolso = kezd + hossz > szamok.Count ? szamok.Count : kezd + hossz;
                for (int i = kezd; i < utolso; i++)
                {
                    sw.WriteLine(szamok[i]);
                }
            }
        }
    }
}

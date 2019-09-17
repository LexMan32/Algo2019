using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplTable
{
    class Program
    {
        static void Main(string[] args)
        {
            TableDichotomie test = new TableDichotomie();
            test.afficherTable();

            Console.WriteLine();
            Console.ReadKey();

            int a = test.rechercherValeur(10);
            Console.WriteLine("La valeur 10 se trouve à l'index " + a );
            a = test.rechercherValeur(20);
            Console.WriteLine("La valeur 20 se trouve à l'index " + a);
             a = test.rechercherValeur(30);
            Console.WriteLine("La valeur 30 se trouve à l'index " + a);
             a = test.rechercherValeur(40);
            Console.WriteLine("La valeur 40 se trouve à l'index " + a);
             a = test.rechercherValeur(50);
            Console.WriteLine("La valeur 50 se trouve à l'index " + a);
             a = test.rechercherValeur(60);
            Console.WriteLine("La valeur 60 se trouve à l'index " + a);
             a = test.rechercherValeur(70);
            Console.WriteLine("La valeur 70 se trouve à l'index " + a);
            a = test.rechercherValeur(80);
            Console.WriteLine("La valeur 80 se trouve à l'index " + a);
            a = test.rechercherValeur(90);
            Console.WriteLine("La valeur 90 se trouve à l'index " + a);

            Console.ReadKey();

        }
    }
}

using System;

namespace TestImplList
{
    class Program
    {
        static void Main(string[] args)
        {
            PileFiFo lst = new PileFiFo();

            lst.ajouterValeur(10);
            lst.ajouterValeur(15);
            lst.ajouterValeur(20);
            lst.ajouterValeur(25);
            lst.ajouterValeur(30);
            lst.ajouterValeur(35);

            lst.afficher();

            Console.WriteLine();

            lst.supprimerValeur();
            lst.supprimerValeur();
            lst.supprimerValeur();

            lst.afficher();

            Console.WriteLine();

            lst.ajouterValeur(50);
            lst.ajouterValeur(55);
            lst.ajouterValeur(60);

            lst.afficher();

            Console.WriteLine();

            lst.supprimerToutesLesValeurs();

            lst.afficher();

            Console.ReadKey();

        }
    }
}

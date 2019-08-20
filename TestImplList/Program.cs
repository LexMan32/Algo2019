using System;

namespace TestImplList
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(5);

            queue.deposerValeur(10);
            queue.deposerValeur(15);
            queue.deposerValeur(20);
            queue.deposerValeur(25);

            queue.afficher();

            Console.WriteLine();

            queue.preleverValeur();
            queue.preleverValeur();
            queue.preleverValeur();

            queue.afficher();

            Console.WriteLine();

            queue.deposerValeur(50);
            queue.deposerValeur(55);
            queue.deposerValeur(60);
            queue.deposerValeur(65);

            queue.afficher();

            Console.WriteLine();

            Console.ReadKey();

        }
    }
}

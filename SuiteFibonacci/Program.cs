using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteFibonacci
{
    class Program
    {
        static bool quitter;

        static int nbrTour = 0;

        static void Main(string[] args)
        {
            Console.Title = "Utilitaire nombre de Fibonacci";

            do
            {
                AfficherMenu();

                GestionChoix(SaisieChoixMenu());

            } while (!quitter);
        }

        static void AfficherMenu()
        {
            AfficherEnTete("MENU");

            Console.WriteLine();
            Console.WriteLine(" 1. Récupérer le nombre de F. d'après son index");
            Console.WriteLine(" 2. ...");
            Console.WriteLine(" 3. Quitter");
            Console.WriteLine();
        }

        static int SaisieChoixMenu()
        {
            bool saisieIncorrect = false;

            int choix = 0;

            do
            {
                try
                {
                    Console.Write("Votre choix : ");
                    choix = int.Parse(Console.ReadLine());
                    saisieIncorrect = false;
                }
                catch (FormatException)
                {
                    saisieIncorrect = true;
                }

                if (choix == 0 | choix > 3) { saisieIncorrect = true; }

                if (saisieIncorrect) { AfficherErreur("Saisie incorrect !"); }

            } while (saisieIncorrect);

            return choix;
        }

        static void GestionChoix(int choix)
        {
            // Sélection du l'étape suivante
            switch (choix)
            {
                case 1:
                    CalculerNbrFibonacci();
                    quitter = false;
                    break;
                case 2:
                    quitter = false;
                    break;
                case 3:
                    quitter = true;
                    break;
            }
        }

        static void AfficherEnTete(string titre)
        {
            Console.Clear();    // Nettoie la console

            // Affiche l'en-tête
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*   Morel Alexandre             ExFibonacci                 Version 1   *");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine();

            // Affiche le titre de la page
            StringBuilder sb = new StringBuilder();
            sb.Append(' ', ((73 - titre.Length) / 2));
            sb.Append(titre);
            Console.WriteLine(sb.ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// Affiche un message d'erreur
        /// </summary>
        /// <param name="message">Message d'erreur à afficher</param>
        static void AfficherErreur(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; // Change la couleur en rouge
            Console.WriteLine(message); // Affiche le message
            Console.ResetColor();   // Reset la couleur de la console
        }

        /// <summary>
        /// Affiche un message "Appuyer sur une touche pour continuer .." et attend l'appuis 
        /// sur une touche du clavier.
        /// </summary>
        static void AfficherAppuyerContinuer()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Appuyer sur une touche pour continuer ... ");
            Console.ReadKey();
        }

        static void CalculerNbrFibonacci()
        {
            AfficherEnTete("Calculer le nombre de Fibonacci");

            Console.Write("Entrer le terme de Finonacci désiré : ");
            Console.WriteLine(" Le terme est le suivant : {0}", Fibonacci(int.Parse(Console.ReadLine()) - 1));
            Console.WriteLine(" Nombre d'appel de la méthode : {0}", nbrTour);

            AfficherAppuyerContinuer();
        }

        static int Fibonacci(int term)
        {
            nbrTour ++;

            if (term <= 0)
            {
                return 0;
            } else if (term == 1){
                return 1;
            } else {
                return Fibonacci(term - 2) + Fibonacci(term - 1);
            }
        }
    }
}

/*
 * ECOLE SUPERIEURE TECHNIQUE PORRENTRUY
 * Département informatique
 * 
 * Description  : Exercices BaseTab.
 * Auteur       : A.Morel
 * Email        : alexandre.morel@divtec.ch
 */

using BaseTab.Trie;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTab
{
    class Program
    {
        // Variables pour la configuration par défaut
        static int quantiteValeur = 100;
        static int maximumValeur = 100;
        static int colonneValeur = 10;

        // Booléen de sortie du programme
        static bool quitter;

        // Initilisation de la liste des valeurs
        static List<int> listValeurs = new List<int>();

        // Générateur pour les nombres aléatoires
        static Random genNbr = new Random();

        /// <summary>
        /// Point d'entrée du programme.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "BaseTab - Morel Alexandre";

            do
            {
                AfficherMenu();

                GestionChoix(SaisirChoixMenu());

            } while (!quitter);
        }

        /// <summary>
        /// Affiche le menu du programme avec en paramètres les valeurs actuelles.
        /// </summary>
        /// <param name="quantiteValeur">Quantité de valeurs</param>
        /// <param name="maximumValeur">Quantité maximum de valeurs</param>
        /// <param name="colonneAffichage">Nombre de colonne pour l'affichage</param>
        static void AfficherMenu()
        {
            AfficherEnTete("MENU");

            Console.WriteLine(" 1. Modifier la quantité de valeur à générer (Valeur actuelle : {0})", quantiteValeur);
            Console.WriteLine(" 2. Modifier la valeur maximum (Valeur actuelle : {0})", maximumValeur);
            Console.WriteLine(" 3. Modifier le nombre de colonne de l'affichage (Valeur actuelle : {0})", colonneValeur);
            Console.WriteLine();
            Console.WriteLine(" 4. Générer les nombres aléatoires");
            Console.WriteLine(" 5. Afficher le tableaux des valeurs");
            Console.WriteLine(" 6. Quitter");
            Console.WriteLine();
            Console.WriteLine(" 10. Trier les valeurs avec un trie à bulles");
            Console.WriteLine(" 11. Trier les valeurs avec un trie par insertion");
            Console.WriteLine(" 12. Trier les valeurs avec un trie par sélection");
            Console.WriteLine(" 13. Trier les valeurs avec un trie rapide (QuickSort)");
            Console.WriteLine(" 14. Trier les valeurs avec un trie en n (bin sort)");
            Console.WriteLine(" 20. Chronomètre des différents tries");
            Console.WriteLine();
        }

        /// <summary>
        /// Saisie du choix dans le menu pour l'utilisateur.
        /// </summary>
        /// <returns>Choix de l'utilisateur</returns>
        static int SaisirChoixMenu()
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

            } while (saisieIncorrect);

            return choix;
        }

        /// <summary>
        /// Gère la sélection du menu d'après le choix de l'utilisateur.
        /// </summary>
        /// <param name="choix">Valeur du choix</param>
        static void GestionChoix(int choix)
        {
            switch (choix)
            {
                default:
                    quitter = false;
                    break;
                case 1:
                    quantiteValeur = SaisieValeur();
                    quitter = false;
                    break;
                case 2:
                    maximumValeur = SaisieValeur();
                    quitter = false;
                    break;
                case 3:
                    colonneValeur = SaisieValeur();
                    quitter = false;
                    break;
                case 4:
                    GenererNombre();
                    quitter = false;
                    break;
                case 5:
                    AfficherNombre();
                    quitter = false;
                    break;
                case 6:
                    quitter = true;
                    break;
                case 10:
                    TrierBulle();
                    quitter = false;
                    break;
                case 11:
                    TrierInsertion();
                    quitter = false;
                    break;
                case 12:
                    TrierSelection();
                    quitter = false;
                    break;
                case 13:
                    TrierQuickShort();
                    quitter = false;
                    break;
                case 14:
                    TrierBinSort();
                    quitter = false;
                    break;
                case 20:
                    TrierChrono();
                    quitter = false;
                    break;
            }
        }

        /// <summary>
        /// Saisie d'une valeur par l'utilisateur pour les paramètres.
        /// </summary>
        /// <returns>La valeur saisie</returns>
        static int SaisieValeur()
        {
            AfficherEnTete("CHANGEMENT DE VALEUR");

            int valeurEntree;

            do
            {
                try
                {
                    Console.Write("Entrez la nouvelle valeur : ");

                    valeurEntree = int.Parse(Console.ReadLine());

                    if (valeurEntree <= 0) { AfficherErreur("Saisie incorrect !"); }
                }
                catch (Exception)
                {
                    AfficherErreur("Saisie incorrect !");
                    valeurEntree = 0;
                }
            }
            while (valeurEntree <= 0);

            return valeurEntree;
        }

        /// <summary>
        /// Génère les nombres d'après les paramètres.
        /// </summary>
        static void GenererNombre()
        {
            AfficherEnTete("GENERATION DES VALEURS");

            listValeurs.Clear();

            int comptVal = quantiteValeur;
            while (comptVal != 0)
            {
                listValeurs.Add(genNbr.Next(0, maximumValeur));
                comptVal--;
            }

            Console.WriteLine("Les nombres ont été générés !");

            AfficherAppuyerContinuer();
        }

        static void TrierBulle()
        {
            AfficherEnTete("TRIE DES VALEURS");

            BubbleSort.Trier(listValeurs);

            Console.WriteLine("Trie à bulles terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierInsertion()
        {
            AfficherEnTete("TRIE DES VALEURS");

            InsertionSort.Trier(listValeurs);

            Console.WriteLine("Trie par insertion terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierSelection()
        {
            AfficherEnTete("TRIE DES VALEURS");

            SelectionSort.Trier(listValeurs);

            Console.WriteLine("Trie par selection terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierQuickShort()
        {
            AfficherEnTete("TRIE DES VALEURS");

            QuickSort.Trier(listValeurs);

            Console.WriteLine("Trie QuickSort terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierBinSort()
        {
            AfficherEnTete("TRIE DES VALEURS");

            BinSort.Trier(listValeurs, maximumValeur);

            Console.WriteLine("Trie BinSort terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierChrono()
        {
            AfficherEnTete("CHRONOMETRE DES TRIS");

            List<int> bulles = new List<int>(listValeurs);
            List<int> insertion = new List<int>(listValeurs);
            List<int> selection = new List<int>(listValeurs);
            List<int> quicksort = new List<int>(listValeurs);
            List<int> binsort = new List<int>(listValeurs);

            System.Diagnostics.Stopwatch stopwatch = StartTimer();
            BubbleSort.Trier(bulles);
            String resultatBulle = StopTimer(stopwatch);

            stopwatch = StartTimer();
            InsertionSort.Trier(insertion);
            String resultatInsertion = StopTimer(stopwatch);

            stopwatch = StartTimer();
            SelectionSort.Trier(selection);
            String resultatSelection = StopTimer(stopwatch);

            stopwatch = StartTimer();
            QuickSort.Trier(quicksort);
            String resultatQuicksort = StopTimer(stopwatch);

            stopwatch = StartTimer();
            QuickSort.Trier(binsort);
            String resultatBinsort = StopTimer(stopwatch);

            Console.WriteLine("Trie à bulles terminé ! Tps : " + resultatBulle);
            Console.WriteLine("Trie par insertion terminé ! Tps : " + resultatInsertion);
            Console.WriteLine("Trie par sélection terminé ! Tps : " + resultatSelection);
            Console.WriteLine("Trie QuickSort terminé ! Tps : " + resultatQuicksort);
            Console.WriteLine("Trie BinSort terminé ! Tps : " + resultatBinsort);

            AfficherAppuyerContinuer();
        }

        static System.Diagnostics.Stopwatch StartTimer()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            return stopwatch;
        }

        static string StopTimer(System.Diagnostics.Stopwatch stopwatch)
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
        }

        /// <summary>
        /// Affiche le tableau des valeurs généré.
        /// </summary>
        static void AfficherNombre()
        {
            AfficherEnTete("AFFICHAGE DES VALEURS");

            bool premVal = true;
            int tempColonne = colonneValeur;

            foreach (int valeur in listValeurs)
            {
                if (premVal) { Console.Write(" {0}", valeur); } else { Console.Write("\t {0}", valeur); }

                premVal = false;
                tempColonne--;

                if (tempColonne == 0)
                {
                    tempColonne = colonneValeur;
                    Console.WriteLine();
                    premVal = true;
                }
            }

            AfficherAppuyerContinuer();
        }

        /// <summary>
        /// Nettoie la console est ré-affiche l'en-tête
        /// </summary>
        static void AfficherEnTete(string titre)
        {
            Console.Clear();

            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*   Morel Alexandre               ExBaseTab               Version 1.1   *");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine();

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
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
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
    }
}

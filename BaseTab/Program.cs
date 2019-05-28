/*
 * ECOLE SUPERIEURE TECHNIQUE PORRENTRUY
 * Département informatique
 * 
 * Description  : Exercices BaseTab.
 * Auteur       : A.Morel
 * Email        : alexandre.morel@divtec.ch
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTab
{
    class Program
    {
        // Nombre de possibilté du menu
        static int nbrPosMenu = 20;

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

                if (choix <= 0 | choix > nbrPosMenu) { saisieIncorrect = true; }

                if (saisieIncorrect) { AfficherErreur("Saisie incorrect !"); }

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
                    // TrierChrono();
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

            BubbleSort.TrierBulle(listValeurs);

            Console.WriteLine("Tri à bulles terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierInsertion()
        {
            TrierInsertion(listValeurs);

            Console.WriteLine("Tri terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierInsertion(List<int> ar)
        {
            AfficherEnTete("TRI DES VALEURS");

            int a, j, i;

            for (i = 1; i < ar.Count; i ++)
            {

                a = ar[i];

                for (j = i; j >= 0; j--)
                {
                    if (j == 0 || ar[j-1] < a)
                    {
                        ar[j] = a;
                        break;
                    } else if (ar[j- 1] > a)
                    {
                        ar[j] = ar[j - 1];
                    }
                }
            }
        }

        static void TrierSelection()
        {
            TrierSelection(listValeurs);

            Console.WriteLine("Tri terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierSelection(List<int> ar)
        {
            AfficherEnTete("TRI DES VALEURS");

            int i, min, j, x;

            for (i = 0; i < ar.Count - 1; i++)
            {
                min = i;

                for (j = i + 1; j < ar.Count; j ++)
                {
                    if (ar[j] < ar[min] )
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    x = ar[i];
                    ar[i] = ar[min];
                    ar[min] = x;
                } 
            }
        }

        static void TrierQuickShort()
        {
            TrierQuickShort(listValeurs, 0, listValeurs.Count - 1);

            Console.WriteLine("Tri terminé !");

            AfficherAppuyerContinuer();
        }

        static void TrierQuickShort(List<int> arr, int gauche, int droite)
        {
            List<int> pivot;

            if (gauche < droite)
            {
                pivot = Partition(arr, gauche, droite);

                if (pivot[1] > gauche)
                {
                    TrierQuickShort(arr, gauche, pivot[1]);
                }
                if (pivot[0] < droite)
                {
                    TrierQuickShort(arr, pivot[0], droite);
                }
            }
        }

        private static List<int> Partition(List<int> arr, int gauche, int droite)
        {
            int pivot = arr[(gauche + droite) / 2];
            do
            {
                while (arr[gauche] < pivot && gauche <= droite)
                {
                    gauche++;
                }

                while (arr[droite] > pivot && gauche <= droite)
                {
                    droite--;
                }

                if (gauche <= droite)
                {
                    int temp = arr[droite];
                    arr[droite] = arr[gauche];
                    arr[gauche] = temp;

                    gauche++;
                    droite--;
                }
                    
            } while (gauche <= droite);

            List<int> tmp = new List<int>();
            tmp.Add(gauche);
            tmp.Add(droite);

            return tmp;
        }

        static void TrierBinSort()
        {
            AfficherEnTete("TRI DES VALEURS");

            TrierBinSort(listValeurs);

            AfficherAppuyerContinuer();
        }

        static void TrierBinSort(List<int> ar)
        {
            List<int>[] arTrier = new List<int>[maximumValeur];

            foreach (int valeur in ar)
            {
                List<int> arTmp = arTrier[valeur];

                if (arTmp == null)
                {
                    arTmp = new List<int>();
                    arTmp.Add(valeur);
                    arTrier[valeur] = arTmp;
                } else
                {
                    arTrier[valeur].Add(valeur);
                }
            }

            ar.Clear();

            foreach (List<int> lst in arTrier)
            {
                if (lst != null)
                {
                    foreach (int valeur in lst)
                    {
                        ar.Add(valeur);
                    }
                }
            }

            Console.WriteLine("Tri terminé !");
        }

        /* static void TrierChrono()
        {
            AfficherEnTete("CHRONOMETRE DES TRIS");

            List<int> bulles = new List<int>(listValeurs);
            List<int> insertion = new List<int>(listValeurs);
            List<int> selection = new List<int>(listValeurs);
            List<int> quicksort = new List<int>(listValeurs);

            System.Diagnostics.Stopwatch stopwatch = StartTimer();
            TrierBulle(bulles);
            String resultatBulle = StopTimer(stopwatch);

            stopwatch = StartTimer();
            TrierInsertion(insertion);
            String resultatInsertion = StopTimer(stopwatch);

            stopwatch = StartTimer();
            TrierSelection(selection);
            String resultatSelection = StopTimer(stopwatch);

            stopwatch = StartTimer();
            TrierQuickShort(quicksort, 0, listValeurs.Count - 1);
            String resultatQuicksort = StopTimer(stopwatch);

            Console.WriteLine("Tri à bulles terminé ! Tps : " + resultatBulle);
            Console.WriteLine("Tri par insertion terminé ! Tps : " + resultatInsertion);
            Console.WriteLine("Tri par sélection terminé ! Tps : " + resultatSelection);
            Console.WriteLine("Tri quicksort terminé ! Tps : " + resultatQuicksort);

            AfficherAppuyerContinuer();
        } */

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
            AfficherEnTete("AFFICHAGE DES VALEURS");   // Affiche l'en-tête

            bool premVal = true;    // Variable pour l'affichage de la première valeur.
            int tempColonne = colonneValeur; // Nombre de colonne

            // Boucle pour l'affichage des valeurs
            foreach (int valeur in listValeurs)
            {
                // Si c'est la première valeur, pas le mêmes affichage
                if (premVal) { Console.Write(" {0}", valeur); } else { Console.Write("\t {0}", valeur); }

                premVal = false;
                tempColonne--;

                // Si c'est la dernière colonne et que les valeurs ne sont pas terminer,
                // réinitilise la variable des colonnes et joute une ligne
                if (tempColonne == 0)
                {
                    tempColonne = colonneValeur;
                    Console.WriteLine();
                    premVal = true;
                }
            }

            AfficherAppuyerContinuer(); // Demande l'appuie d'une touche pour continuer
        }

        /// <summary>
        /// Nettoie la console est ré-affiche l'en-tête
        /// </summary>
        static void AfficherEnTete(string titre)
        {
            Console.Clear();    // Nettoie la console

            // Affiche l'en-tête
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("*   Morel Alexandre               ExBaseTab               Version 1.1   *");
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
    }
}

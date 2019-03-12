/*
 * ECOLE SUPERIEURE TECHNIQUE PORRENTRUY
 * Département informatique
 * 
 * Description  : Exercices BaseTab.
 * Auteur       : A.Morel
 * Email        : alexandre.morel@divtec.ch
 * Date         : 13.09.2017
 * Version      : 1.0 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTab
{
    class Program
    {
        // Variable des valeurs (Initialisé avec les valeurs par défaut)
        static int quantiteValeur = 10;
        static int maximumValeur = 20;
        static int colonneValeur = 1;

        // Booléen de sortie du programme
        static bool quitter;

        // Initilisation de la liste des valeurs
        static List<int> listValeurs = new List<int>();

        // Générateur de nombres aléatoires
        static Random genNbr = new Random();

        /// <summary>
        /// Point d'entrée du programme.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "Tableau de valeurs";   // Applique un titre à la console


            do  // Boucle pour la répétition du programme
            {
                AfficherMenu();  // Affiche le menu avec les valeurs

                GestionChoix(SaisieChoix());    // Gestion du choix d'après la saisie

            } while (!quitter);

            // Fin du programme
        }

        /// <summary>
        /// Affiche le menu du programme avec en paramètres les valeurs actuelles.
        /// </summary>
        /// <param name="quantiteValeur">Quantité de valeurs</param>
        /// <param name="maximumValeur">Quantité maximum de valeurs</param>
        /// <param name="colonneAffichage">Nombre de colonne pour l'affichage</param>
        static void AfficherMenu()
        {
            AfficherEnTete("MENU");   // Affiche l'en-tête

            // Affichage le menu
            Console.WriteLine(" 1. Modifier la quantité de valeur à générer (Valeur actuelle : {0})", quantiteValeur);
            Console.WriteLine(" 2. Modifier la valeur maximum (Valeur actuelle : {0})", maximumValeur);
            Console.WriteLine(" 3. Modifier le nombre de colonne de l'affichage (Valeur actuelle : {0})", colonneValeur);
            Console.WriteLine(" 4. Générer les nombres aléatoires");
            Console.WriteLine(" 5. Trier les valeurs avec un trie à bulles");
            Console.WriteLine(" 6. Afficher le tableaux des valeurs");
            Console.WriteLine(" 7. Quitter");
            Console.WriteLine();
        }

        /// <summary>
        /// Saisie du choix dans le menu pour l'utilisateur.
        /// </summary>
        /// <returns>Choix de l'utilisateur</returns>
        static int SaisieChoix()
        {
            bool saisieIncorrect = false;   // Booleen de saisie incorrect

            int choix = 0;  // Choix saisie

            do  // Boucle de répétition pour une saisie valide
            {
                // Try / Catch pour vérifier la valeur saisie
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

                // Test si la valeur saisie entre dans le menu
                if (choix == 0 | choix > 7) { saisieIncorrect = true; }

                // Affiche un message d'erreur si besoin
                if (saisieIncorrect) { AfficherErreur("Saisie incorrect !"); }

            } while (saisieIncorrect);

            return choix;   // Retourne la valeur choisie
        }

        /// <summary>
        /// Gère la sélection du menu d'après le choix de l'utilisateur.
        /// </summary>
        /// <param name="choix">Valeur du choix</param>
        static void GestionChoix(int choix)
        {
            // Sélection du l'étape suivante
            switch (choix)
            {
                case 1: // Saisie de la valeur "Quantité"
                    quantiteValeur = SaisieValeur();
                    quitter = false;
                    break;
                case 2: // Saisie de la valeur "Maximum"
                    maximumValeur = SaisieValeur();
                    quitter = false;
                    break;
                case 3: // Saisie de la valeur "Colonne"
                    colonneValeur = SaisieValeur();
                    quitter = false;
                    break;
                case 4: // Génération des valeurs dans la liste
                    GenererNombre();
                    quitter = false;
                    break;
                case 5: // Trie de la liste
                    TrierInsertion();
                    quitter = false;
                    break;
                case 6: // Affichage de la liste de valeurs
                    AfficherNombre();
                    quitter = false;
                    break;
                case 7: // Quitter le programme
                    quitter = true;
                    break;
            }
        }

        /// <summary>
        /// Saisie d'une valeur par l'utilisateur pour les paramètres.
        /// </summary>
        /// <returns>La valeur saisie</returns>
        static int SaisieValeur()
        {
            AfficherEnTete("CHANGEMENT DE VALEUR"); // Affiche l'en-tête

            int valeurEntree;   // valeur entrée par l'utilisateur

            do // Boucle tant que la valeur est inférieure ou égale à zéro
            {
                try     // Try / Catch pour la valeur entrée
                {
                    // Invitation à saisir une valeur
                    Console.Write("Entrez la nouvelle valeur : ");

                    // Chargement de la valeur
                    valeurEntree = int.Parse(Console.ReadLine());

                    // Test si la valeur est non recevable <0
                    if (valeurEntree <= 0) { AfficherErreur("Saisie incorrect !"); }
                }
                catch (Exception)
                {
                    // Message d'erreur
                    AfficherErreur("Saisie incorrect !");
                    valeurEntree = 0;
                }
            }
            while (valeurEntree <= 0);

            return valeurEntree; // Retourne la valeur si elle est correct
        }

        /// <summary>
        /// Génère les nombres d'après les paramètres.
        /// </summary>
        static void GenererNombre()
        {
            AfficherEnTete("GENERATION DES VALEURS");   // Affiche l'en-tête

            // Vide la liste de valeurs
            listValeurs.Clear();

            // Boucle pour le chargement des valeurs d'après la quantité paramétré.
            int comptVal = quantiteValeur;
            while (comptVal != 0)
            {
                // Ajoute un nombre aléatoire a la liste
                listValeurs.Add(genNbr.Next(0, maximumValeur));
                comptVal--;
            }

            Console.WriteLine("Les nombres ont été générés !");

            AfficherAppuyerContinuer(); // Demande l'appuie d'une touche pour continuer
        }

        /// <summary>
        /// Trie la liste des valeurs avec un trie à bulle (BubbleSort).
        /// </summary>
        static void TrierBulle()
        {
            AfficherEnTete("TRIE DES VALEURS");   // Affiche l'en-tête

            bool valeurEchange; // Variable d'un échange

            do
            {
                valeurEchange = false; // On réinitialise la variable pour savoir un changement

                // Pour chacun des éléments de la liste de valeur
                for (int index = 0; index < listValeurs.Count - 1; index++)
                {
                    // Si la valeur suivante est plus grande
                    if (listValeurs[index] > listValeurs[index + 1])
                    {
                        // On inverse les valeurs
                        PermuterNombre(index, index + 1);

                        // On change la variable d'un changement
                        valeurEchange = true;
                    }
                }
            } while (valeurEchange == true); // Tant qu'une valeur a été changé, on recommence

            // Message de fin du trie
            Console.WriteLine("Trie terminé !");

            AfficherAppuyerContinuer(); // Demande l'appuie d'une touche pour continuer
        }

        /// <summary>
        /// Trie la liste des valeurs avec un trie à insertion (InsertSort).
        /// </summary>
        static void TrierInsertion()
        {
            AfficherEnTete("TRIE DES VALEURS");   // Affiche l'en-tête

            for (int index = 1; index < listValeurs.Count; index ++)
            {

                int nbrAInserer = listValeurs[index];
                int posRecherche = index;

                while (nbrAInserer < listValeurs[index - 1] && posRecherche - 1 >= 1)
                {
                    listValeurs[posRecherche] = listValeurs[posRecherche - 1];
                    posRecherche = posRecherche - 1;



                }

                listValeurs[posRecherche] = nbrAInserer;
            }

            // Message de fin du trie
            Console.WriteLine("Trie terminé !");

            AfficherAppuyerContinuer(); // Demande l'appuie d'une touche pour continuer
        }

        /// <summary>
        /// Trie la liste des valeurs avec un trie par sélection.
        /// </summary>
        static void TrierSelection()
        {
            AfficherEnTete("TRIE DES VALEURS");   // Affiche l'en-tête

            for (int index = 0; index < listValeurs.Count; index++)
            {
                int indexEchange = index;

                for (int indexScan = index + 1; indexScan < listValeurs.Count; indexScan ++)
                {
                    if (listValeurs[indexEchange] > listValeurs[indexScan] )
                    {
                        indexEchange = indexScan;
                    }

                }

                PermuterNombre(index, indexEchange);
            }

            // Message de fin du trie
            Console.WriteLine("Trie terminé !");

            AfficherAppuyerContinuer(); // Demande l'appuie d'une touche pour continuer
        }

        /// <summary>
        /// Permute les nombres contenu dans la liste entre l'index 1 et l'index 2.
        /// </summary>
        /// <param name="indexNombre1">Index du premier nombre</param>
        /// <param name="indexNombre2">Index du second nombre</param>
        static void PermuterNombre(int indexNombre1, int indexNombre2)
        {
            int valeurTmp = listValeurs[indexNombre1];
            listValeurs[indexNombre1] = listValeurs[indexNombre2];
            listValeurs[indexNombre2] = valeurTmp;
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

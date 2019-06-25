using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplList
{

    public class PileFiFo
    {

        private int[] valeurs;
        private int dernier;
        private int valeurMax = 20;

        public PileFiFo()
        {
            valeurs = new int[valeurMax];

            dernier = 0;
        }

        public void ajouterValeur(int nombre)
        {
            if (dernier + 1 != valeurMax)
            {
                valeurs[dernier] = nombre;
                dernier++;
            }
        }

        public void supprimerValeur()
        {
            if (dernier != 0)
            {
                valeurs[dernier - 1] = 0;
                dernier--;
            }
        }

        public void supprimerToutesLesValeurs()
        {
            valeurs = new int[valeurMax];
            dernier = 0;
        }

        public void afficher()
        {
            for (int i = 0; i < dernier; i++)
            {
                Console.WriteLine("Index {0} -> {1}", i, valeurs[i]);
            }
        }
    }
}

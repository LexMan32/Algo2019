using System;
using System.Linq;

namespace TestImplList
{
    class Liste
    {
        private int[] valeurs;
        private int dernier;
        private int LongMax = 20;

        public Liste()
        {
            valeurs = new int[LongMax];
            dernier = -1;
        }

        public void ajouterDebut(int valeur)
        {
            if (dernier == -1) {
                valeurs[0] = valeur;
            } else {
                for (int index = dernier; index >= 0; index++)
                {
                    valeurs[index + 1] = valeurs[index];
                    valeurs[0] = valeur;
                }
            }
            dernier++;
        }

        public bool estVide()
        {
            if (dernier == -1)
            {
                return true;
            }

            return false;
        }

        public int compterElement()
        {
            return this.valeurs.Count();
        }

        public void afficher()
        {
            for (int i = 0; i < dernier; i++)
            {
                Console.WriteLine("Index {0} -> {1}", i, valeurs[i]);
            }
        }

        public int getPremiereValeur()
        {
            return this.valeurs[0];
        }
    }
}
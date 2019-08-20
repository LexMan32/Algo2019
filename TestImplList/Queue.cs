using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplList
{
    public class Queue
    {
        private int[] valeurs;
        private int maxTaille;
        private int inPos;
        private int outPos;
        private int nbrVal;

        public Queue(int maxTaille)
        {
            this.maxTaille = maxTaille;
            valeurs = new int[this.maxTaille];

            inPos = 0;
            outPos = 0;
            nbrVal = 0;
        }

        public void deposerValeur(int valeur)
        {
            if (nbrVal == maxTaille)
            {
                throw new TooManyValuesException();
            }

            valeurs[inPos] = valeur;

            inPos ++;
            nbrVal ++;

            if (inPos == maxTaille)
            {
                inPos = 0;
            }
        }

        public int preleverValeur()
        {
            if (nbrVal == 0)
            {
                throw new NotEnoughValuesException();
            }

            int tmp = valeurs[outPos];

            outPos ++;
            nbrVal --;

            if (outPos == maxTaille)
            {
                outPos = 0;
            }

            return tmp;
        }

        public void effacerValeurs()
        {
            if (nbrVal == 0)
            {
                throw new NotEnoughValuesException();
            }

            inPos = 0;
            outPos = 0;
            nbrVal = 0;
        }

        public bool estVide()
        {
            return nbrVal == 0;
        }

        public int obtenirLongueur()
        {
            return nbrVal;
        }

        public void afficher()
        {
            Console.WriteLine();

            Console.WriteLine("NbrValeur = " + nbrVal + " / InPos = " + inPos + " / OutPos = " + outPos);

            for (int i = 0; i < maxTaille; i++ )
            {
                Console.WriteLine("Index " + i +" : " + valeurs[i]);
            }
            
            Console.WriteLine();
        }
    }
}

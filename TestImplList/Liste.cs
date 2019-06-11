using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestImplList
{
    class Liste
    {
        private int[] valeurs;
        private int dernier;
        private int LongMax = 20;

        public Liste()
        {
            valeurs = new int[0];
        }

        public void ajouterDebut(int valeur)
        {
            Array.Resize<int>(ref valeurs, valeurs.Count());
        }

        public 

        public bool estListeVide()
        {
            if (this.valeurs.Count() == 0)
            {
                return true;
            }

            return false;
        }

        public int compterElement()
        {
            return this.valeurs.Count();
        }

        public int getPremiereValeur()
        {
            return this.valeurs[0];
        }
    }
}
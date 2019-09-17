using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplTable
{
    class TableDichotomie
    {
        private int[] table;
        private int nbrValeurTable;

        public TableDichotomie()
        {
            nbrValeurTable = 50;
            chargerTable();
            trierTable();
        }

        private void chargerTable()
        {
            table = new int[nbrValeurTable];

            Random random = new Random();

            for (int i = 0; i != nbrValeurTable; i++)
            {
                table[i] = random.Next(100);
            }
        }

        private void trierTable()
        {
            Array.Sort(table);
        }

        public int rechercherValeur(int recherche)
        {
            return dichotomie(0, nbrValeurTable - 1, recherche);
        }

        public int dichotomie(int indexDebut, int indexFin, int recherche)
        {
            int pivot = indexFin / 2;

            if (recherche == table[pivot])
            {
                return pivot;
            } else if (recherche > table[pivot])
            {
                return dichotomie(pivot, indexFin, recherche);
            }
            else if (recherche < table[pivot])
            {
                return dichotomie(indexDebut, pivot, recherche);
            }

            return -1;
        }

        public void afficherTable()
        {
            for (int i = 0; i != nbrValeurTable; i++)
            {
                Console.WriteLine("index : " + i + " valeur : " + table[i]);
            }
        }
    }
}

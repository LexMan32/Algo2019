using System.Collections.Generic;

namespace BaseTab.Trie
{
    class BinSort
    {
        public static void Trier(List<int> valeurs, int maximumValeur)
        {
            List<int>[] arTrier = new List<int>[maximumValeur];

            foreach (int valeur in valeurs)
            {
                List<int> arTmp = arTrier[valeur];

                if (arTmp == null)
                {
                    arTmp = new List<int>();
                    arTmp.Add(valeur);
                    arTrier[valeur] = arTmp;
                }
                else
                {
                    arTrier[valeur].Add(valeur);
                }
            }

            valeurs.Clear();

            foreach (List<int> lst in arTrier)
            {
                if (lst != null)
                {
                    foreach (int valeur in lst)
                    {
                        valeurs.Add(valeur);
                    }
                }
            }
        }

    }
}

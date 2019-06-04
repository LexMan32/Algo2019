using System.Collections.Generic;

namespace BaseTab.Trie
{
    class SelectionSort
    {
        public static void Trier(List<int> valeurs)
        {
            int i, min, j, x;

            for (i = 0; i < valeurs.Count - 1; i++)
            {
                min = i;

                for (j = i + 1; j < valeurs.Count; j++)
                {
                    if (valeurs[j] < valeurs[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    x = valeurs[i];
                    valeurs[i] = valeurs[min];
                    valeurs[min] = x;
                }
            }
        }
    }
}
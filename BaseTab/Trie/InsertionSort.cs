using System.Collections.Generic;

namespace BaseTab.Trie
{
    class InsertionSort
    {
        public static void Trier(List<int> valeurs)
        {
            int a, j, i;

            for (i = 1; i < valeurs.Count; i++)
            {

                a = valeurs[i];

                for (j = i; j >= 0; j--)
                {
                    if (j == 0 || valeurs[j - 1] < a)
                    {
                        valeurs[j] = a;
                        break;
                    }
                    else if (valeurs[j - 1] > a)
                    {
                        valeurs[j] = valeurs[j - 1];
                    }
                }
            }
        }
    }
}
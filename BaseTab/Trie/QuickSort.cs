using System.Collections.Generic;

namespace BaseTab.Trie
{
    class QuickSort
    {
        public static void Trier(List<int> valeurs)
        {
            StartQuickSort(valeurs, 0, valeurs.Count - 1);
        }

        private static void StartQuickSort(List<int> valeurs, int gauche, int droite)
        {
            List<int> pivot;

            if (gauche < droite)
            {
                pivot = Partition(valeurs, gauche, droite);

                if (pivot[1] > gauche)
                {
                    StartQuickSort(valeurs, gauche, pivot[1]);
                }
                if (pivot[0] < droite)
                {
                    StartQuickSort(valeurs, pivot[0], droite);
                }
            }
        }

        private static List<int> Partition(List<int> valeurs, int gauche, int droite)
        {
            int pivot = valeurs[(gauche + droite) / 2];
            do
            {
                while (valeurs[gauche] < pivot && gauche <= droite)
                {
                    gauche++;
                }

                while (valeurs[droite] > pivot && gauche <= droite)
                {
                    droite--;
                }

                if (gauche <= droite)
                {
                    int temp = valeurs[droite];
                    valeurs[droite] = valeurs[gauche];
                    valeurs[gauche] = temp;

                    gauche++;
                    droite--;
                }

            } while (gauche <= droite);

            List<int> tmp = new List<int>();
            tmp.Add(gauche);
            tmp.Add(droite);

            return tmp;
        }
    }
}

using System.Collections.Generic;

namespace BaseTab.Trie
{
    public class BubbleSort
    {
        public static void Trier(List<int> valeurs)
        {
            bool valeurEchange;

            do
            {
                valeurEchange = false;

                for (int index = 0; index < valeurs.Count - 1; index++)
                {
                    if (valeurs[index] > valeurs[index + 1])
                    {
                        PermuterNombre(valeurs, index, index + 1);

                        valeurEchange = true;
                    }
                }
            } while (valeurEchange == true);
        }

        private static void PermuterNombre(List<int> valeurs, int indexNombre1, int indexNombre2)
        {
            int valeurTmp = valeurs[indexNombre1];
            valeurs[indexNombre1] = valeurs[indexNombre2];
            valeurs[indexNombre2] = valeurTmp;
        }

    }
}
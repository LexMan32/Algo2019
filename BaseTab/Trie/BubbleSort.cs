using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTab
{
    public class BubbleSort
    {
 
        public static void TrierBulle(List<int> listValeurs)
        {
            bool valeurEchange;

            do
            {
                valeurEchange = false;

                for (int index = 0; index < listValeurs.Count - 1; index++)
                {
                    if (listValeurs[index] > listValeurs[index + 1])
                    {
                        PermuterNombre(listValeurs, index, index + 1);

                        valeurEchange = true;
                    }
                }
            } while (valeurEchange == true);
        }

        private static void PermuterNombre(List<int> listValeurs, int indexNombre1, int indexNombre2)
        {
            int valeurTmp = listValeurs[indexNombre1];
            listValeurs[indexNombre1] = listValeurs[indexNombre2];
            listValeurs[indexNombre2] = valeurTmp;
        }

    }
}

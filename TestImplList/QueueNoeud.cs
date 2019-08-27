using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplList
{
    class QueueNoeud
    {
        private Noeud debut;
        private Noeud fin;

        public QueueNoeud()
        {

        }

        public bool estVide()
        {
            return debut == null;
        }

        public int length()
        {
            int qteElement = 0;
            Noeud noeudActuel = this.debut;

            while (noeudActuel != null)
            {
                qteElement++;
                noeudActuel = noeudActuel.getSuivant();
            }

            return qteElement;
        }

        public void deposer(int info)
        {
            Noeud nouveau = new Noeud(info, null);

            if (estVide())
            {
                debut = nouveau;
            } else
            {
                fin.setSuivant(nouveau);
            }

            fin = nouveau;
        }

        public int prelever()
        {
            int infoAPrelever = 0;
            if (!estVide())
            {
                infoAPrelever = debut.getInfo();

                debut = debut.getSuivant();

                if (estVide()) fin = null;
            }

            return infoAPrelever;
        }
    }
}

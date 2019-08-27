using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplList
{
    class Noeud
    {
        private int info;
        private Noeud suivant;

        public Noeud(int info, Noeud suivant)
        {
            this.info = info;
            this.suivant = suivant;
        }

        public int getInfo()
        {
            return info;
        }

        public void setInfo(int info)
        {
            this.info = info;
        }

        public Noeud getSuivant()
        {
            return suivant;
        }

        public void setSuivant(Noeud suivant)
        {
            this.suivant = suivant;
        }

    }
}

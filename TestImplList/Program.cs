﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImplList
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste lst = new Liste();

            lst.ajouterDebut(15);

            lst.afficher();

            Console.ReadKey();

        }
    }
}

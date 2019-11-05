using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labyrinthe
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int QUARE_SIZE = 25;

        List<Case> listCase;

        public MainWindow()
        {
            InitializeComponent();

            GenerateGrid();

            DrawLabyrinth();

            BuildLabyrinth();
        }

        private void GenerateGrid()
        {
            int nbrCase = (int)GameArea.Width / QUARE_SIZE;
            nbrCase = nbrCase * nbrCase;

            for (int i = 0; i == nbrCase; i++)
            {
                listCase.Add(new Case());
            }
        }

        private void BuildLabyrinth()
        {

        }

        private void DrawLabyrinth()
        {
            int indexX = 0;
            int indexY = 0;

            foreach (Case iCase in listCase)
            {

            }
        }
    }
}

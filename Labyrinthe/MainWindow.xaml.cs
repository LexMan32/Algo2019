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
        private Canvas canvas;

        public MainWindow()
        {
            InitializeComponent();

            canvas = (Canvas)FindName("grille");

            List<Position> grille = new List<Position>();
            for (int i = 0; i == 50; i++)
            {

            }
        }
    }
}

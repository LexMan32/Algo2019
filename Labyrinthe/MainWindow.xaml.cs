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
        const int QUARE_SIZE = 50;
        const int BORDER_THIN = 5;

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
            listCase = new List<Case>();

            for (int i = 0; i != nbrCase; i++)
            {
                listCase.Add(new Case());
            }
        }

        private void BuildLabyrinth()
        {
            int nbrCase = (int)GameArea.Width / QUARE_SIZE;

            int indexX = 0;
            int indexY = 0;


        }

        private void DrawLabyrinth()
        {
            int nbrCase = (int)GameArea.Width / QUARE_SIZE;

            int indexX = 0;
            int indexY = 0;

            foreach (Case iCase in listCase)
            {
                if (indexX == nbrCase)
                {
                    indexY++;
                    indexX = 0;
                }

                foreach (Wall wall in iCase.ListWalls)
                {
                    Rectangle rect = new Rectangle();
                    rect.Stroke = new SolidColorBrush(Colors.Black);
                    rect.Fill = new SolidColorBrush(Colors.Black);

                    switch (wall)
                    {
                        case Wall.DOWN:
                            rect.Width = QUARE_SIZE;
                            rect.Height = BORDER_THIN;
                            Canvas.SetLeft(rect, (indexX * QUARE_SIZE));
                            Canvas.SetTop(rect, (indexY * QUARE_SIZE) + (QUARE_SIZE - BORDER_THIN));
                            break;

                        case Wall.UP:
                            rect.Width = QUARE_SIZE;
                            rect.Height = BORDER_THIN;
                            Canvas.SetLeft(rect, (indexX * QUARE_SIZE));
                            Canvas.SetTop(rect, (indexY * QUARE_SIZE));
                            break;

                        case Wall.LEFT:
                            rect.Width = BORDER_THIN;
                            rect.Height = QUARE_SIZE;
                            Canvas.SetLeft(rect, (indexX * QUARE_SIZE));
                            Canvas.SetTop(rect, (indexY * QUARE_SIZE));
                            break;

                        case Wall.RIGHT:
                            rect.Width = BORDER_THIN;
                            rect.Height = QUARE_SIZE;
                            Canvas.SetLeft(rect, (indexX * QUARE_SIZE) + (QUARE_SIZE - BORDER_THIN));
                            Canvas.SetTop(rect, (indexY * QUARE_SIZE));
                            break;
                    }

                    GameArea.Children.Add(rect);
                } 

                indexX++;
            }
        }
    }
}

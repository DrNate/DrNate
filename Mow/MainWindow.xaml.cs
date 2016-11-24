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

namespace Mow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            Vache paquet = new Vache();
            Random rng = new Random();

            List<Vache> Deck = paquet.creerdeck();
            
            // ##############################################################################

            // Create Image Element
            Image myImage = new Image();
            myImage.Width = 200;

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Water fourmi.jpeg");

            // To save significant application memory, set the DecodePixelWidth or  
            // DecodePixelHeight of the BitmapImage value of the image source to the desired 
            // height or width of the rendered image. If you don't do this, the application will 
            // cache the image as though it were rendered as its normal size rather then just 
            // the size that is displayed.
            // Note: In order to preserve aspect ratio, set DecodePixelWidth
            // or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            myImage.Source = myBitmapImage;
                             

            // ##############################################################################

            int r = rng.Next(Deck.Count);

            label.Content = (Deck[r].Categorie.ToString()) +
                            ("\n") +
                            ("Valeur : ") + (Deck[r].Valeur.ToString()) +
                            ("\n") +
                            ("Nb mouche(s) : ") + (Deck[r].nb_mouches.ToString());

            //Le programme marche avec cette ligne merci 
            
            Console.ReadLine();


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Vache paquet = new Vache();
            Random rng = new Random();

            List<Vache> Deck = paquet.creerdeck();

            


            int r = rng.Next(Deck.Count);

            label.Content = (Deck[r].Categorie.ToString()) +
                            ("\n") +
                            ("Valeur : ") + (Deck[r].Valeur.ToString()) +
                            ("\n") +
                            ("Nb mouche(s) : ") + (Deck[r].nb_mouches.ToString());
            

            
        }
    }
}

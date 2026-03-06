using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgAsincrona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random random = new Random();
        List<char> lettere = new List<char>();
        private async void btnGeneraLettere_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                int numero = random.Next(0, 26);
                char lettera = (char)('A' + numero);
                lblLettereCasuali.Content = lettera.ToString();
                lettere.Add(lettera);
                await Task.Delay(200);
            }
        }

        private void btnStampaLettere_Click(object sender, RoutedEventArgs e)
        {
            char letteraDaStampare = lettere[lettere.Count - 1];
            //lblStampaLettere.Content = letteraDaStampare.ToString(); se faccio così ogni volta che si clicca la lettera viene sovrascritta
            lblStampaLettere.Content += letteraDaStampare.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ProgAsincrona
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random random = new Random();
        List<char> lettere = new List<char>(); 
        string parolaCorrente = ""; 

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
            //prendo lunghezza dalla textbox
            int lunghezza;
            if (int.TryParse(txtLunghezza.Text, out lunghezza))
            {
                //la lunghezza non può essere minre o uguale a 0 quindi fa vedere la message box
                if(lunghezza <= 0)
                {
                    MessageBox.Show("Inserisci un numero valido");
                    return;
                }

                //sorteggio la lettera dalla lista
                char letteraSorteggiata = lettere[lettere.Count - 1];

                parolaCorrente += letteraSorteggiata;
                lblStampaLettere.Content = parolaCorrente;

                if (parolaCorrente.Length >= lunghezza)
                {
                    listboxParole.Items.Add(parolaCorrente);

                    parolaCorrente = "";
                    lblStampaLettere.Content = ""; 
                }
            }
            else
            {
                MessageBox.Show("Inserisci un numero valido");
            }
        }
    }
}
using Ambrogiani.Filippo._4i.Rubrica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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

namespace Ambrogiani.Filippo._4i.RubricaUnoAMolti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int Max = 100;
        public MainWindow()
        {
            InitializeComponent();
        }
        Persona[] persone = new Persona[Max];
        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { /* //penso non funzioni perchè è stato scritto a mano
            Persona p = e.AddedItems[0] as Persona;
            //statusBar.Text = $"{p.Cognome}";

            List<Contatto> contattiFiltrati = new List<Contatto>();
            foreach (var item in Contatti)
            {
                if (item.idPersona == p.idPersona)
                {
                    contattiFiltrati.Add(item);
                }
                dgContatti.ItemSource = contattiFiltrati;
            }

        */
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //leggi persone
                StreamReader fin = new StreamReader("Persone.csv");
                fin.ReadLine();

                List<Persona> persona = new List<Persona>();
                while (!fin.EndOfStream)
                {
                    //semplifica in persone.Add(new Contatto(fin.ReadLine()));
                    string riga = fin.ReadLine();
                    Persona p = new Persona(riga);
                    persona.Add(p);
                }
                //dgPersone.ItemsSource = Persone
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

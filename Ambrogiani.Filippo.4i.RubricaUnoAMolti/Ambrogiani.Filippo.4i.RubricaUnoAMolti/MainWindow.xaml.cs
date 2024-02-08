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
    /// 
    public partial class MainWindow : Window
    {
        List<Contatto> Contatti;
        List<Persona> Persone;
        List<Contatto> ListaVuota = new List<Contatto>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Persona p = e.AddedItems[0] as Persona; //salva le informazioni della tabella selezionata
            if (p != null)
            {
                statusBar.Text = $"Cognome: {p.Cognome}";
                
                        List<Contatto> contattiFiltrati = new List<Contatto>();
                        foreach (var item in Contatti)
                        {
                            if (item.idPersona == p.idPersona)
                            {
                                contattiFiltrati.Add(item);
                            }

                          
                        }
                    dgContatti.ItemsSource = contattiFiltrati; //se selezionato una persona mostro tutti i contatti con lo stesso ID
                    
            }
            else { 
                statusBar.Text = "Cognome: ...";
                dgContatti.ItemsSource = ListaVuota; //svuoto la lista se niente è selezionato
            }
                

            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //leggi persone
                StreamReader fin = new StreamReader("Persone.csv");
                fin.ReadLine();

                Persone = new List<Persona>();
                while (!fin.EndOfStream)
                {
                    //semplifica in persone.Add(new Persona(fin.ReadLine()));
                    string riga = fin.ReadLine();
                    Persona p = new Persona(riga);
                    Persone.Add(p);
                }

                dgPersone.ItemsSource = Persone;
                fin.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //leggi contatti
                StreamReader fin = new StreamReader("Contatti.csv");
                fin.ReadLine();

                Contatti = new List<Contatto>();
                while (!fin.EndOfStream)
                {
                    //semplifica in Contatti.Add(new Contatto(fin.ReadLine()));
                    string riga = fin.ReadLine();
                    Contatto c = new Contatto(riga);
                    Contatti.Add(c);
                }

                //dgContatti.ItemsSource = Contatti; //commenta questa parte per far sparire i contatti
                fin.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

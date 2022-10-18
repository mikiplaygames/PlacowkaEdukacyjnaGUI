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

namespace dziki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListaSzkol obecnaListaSzkol;
        private Szkola obecnieWybranaSzkola;
        private Klasa obecnieWybranaKlasa;
        private Uczen obecnieWybranyUczen;
        private void Szkola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            guiKlasaLista.ItemsSource = null;
            guiKlasaLista.Items.Clear();
            obecnieWybranaKlasa = null;
            foreach (var item in obecnaListaSzkol.listaSzkol[guiSzkolaLista.SelectedItem.ToString()].szkola)
            {
                guiKlasaLista.Items.Add(item.Key);
            }
            obecnieWybranaSzkola = obecnaListaSzkol.listaSzkol[guiSzkolaLista.SelectedItem.ToString()];
            guiOpisSzkola.Text = $"Statystyki szkoly:\n{obecnieWybranaSzkola.SredniaSzkolyInteligencja()} iq\n{obecnieWybranaSzkola.SredniaSzkolyZwinnosc()} zwinnosc\n{obecnieWybranaSzkola.SredniaSzkolyZachowanie()}pkt zachowanie";
        }

        private void Klasa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            guiUczenLista.ItemsSource = null;
            guiUczenLista.Items.Clear();
            obecnieWybranyUczen = null;
            foreach (var item in obecnieWybranaSzkola.szkola[guiKlasaLista.SelectedItem.ToString()].klasa)
            {
                guiUczenLista.Items.Add(item.Key + $" {item.Value.imie} {item.Value.nazwisko}");
            }
            obecnieWybranaKlasa = obecnieWybranaSzkola.szkola[guiKlasaLista.SelectedItem.ToString()];
            guiOpisKlasa.Text = $"Statystyki klasy:\n{obecnieWybranaKlasa.ObliczSredniaInteligencja()} iq\n{obecnieWybranaKlasa.ObliczSredniaZwinnosc()} zwinnosc\n{obecnieWybranaKlasa.ObliczSredniaPkt()} pkt zachowania";
        }

        private void Uczen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                obecnieWybranyUczen = obecnieWybranaKlasa.klasa[int.Parse(guiUczenLista.SelectedItem.ToString().Split()[0])];
            }
            catch (NullReferenceException)
            {
                guiOpisUczen.Text = "";
            }

            guiOpisUczen.Text = $"Statystyki ucznia:\n{obecnieWybranyUczen.imie} {obecnieWybranyUczen.nazwisko}\n{obecnieWybranyUczen.inteligencja}iq\n{obecnieWybranyUczen.punktyZachowania}pkt zachowania";
        }
        public MainWindow()
        {
            InitializeComponent();
            ShowSchools(ImportData());













            void ShowSchools(ListaSzkol szkoly)
            {
                int sql = 0;
                obecnaListaSzkol = szkoly;
                foreach (var szkola in szkoly.listaSzkol.Values)
                {
                    guiSzkolaLista.Items.Add(szkoly.listaSzkol.Keys.ToArray()[sql]);
                    sql++;
                }
            }

            static ListaSzkol ImportData()
            {
                ListaSzkol szkoly = new();

                Szkola zsl = new();

                Klasa klasa1 = new();
                Klasa klasa2 = new();
                Klasa klasa3 = new();


                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "jan", "dps", 2, 3, 1);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "ada", "iiiddsadaps", 3, 23, 91);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "rop", "ooooodps", 5, 3, 11);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "syzm", "jjjjjdps", 22, 333, 17);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "fuk", "ggggdps", 323, 73, 16);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "luc", "nnnndps", 612, 13, 71);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "krzs", "cccdps", 212, 33, 11);
                klasa1.AddStudent(new UczenID { szkola = "zsl", klasa = "1s" }, "woj", "aaaadps", 12, 23, 15);


                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "dps", "jan", 2, 3, 1);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "iiiddsadaps", "ada", 3, 23, 91);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "ooooodps", "rop", 5, 3, 11);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "jjjjjdps", "syzm", 22, 333, 17);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "ggggdps", "fuk", 32, 73, 16);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "nnnndps", "luc", 62, 13, 71);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "cccdps", "krzs", 212, 33, 11);
                klasa2.AddStudent(new UczenID { szkola = "zsl", klasa = "2g" }, "aaaadps", "woj", 12, 23, 15);


                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "jan", "snus", 2, 3, 1);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "nb", "sadek", 3, 23, 91);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "cowboy", "bepbop", 5, 3, 11);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "ss", "ayzm", 2, 333, 17);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "ps", "sfuk", 44444442, 73, 16);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "rober", "lewandoski", 62, 213, 71);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "ishow", "sped", 2, 33, 11);
                klasa3.AddStudent(new UczenID { szkola = "zsl", klasa = "4h" }, "swea", "daj", 1, 23, 15);

                zsl.AddClass("1s", klasa1);
                zsl.AddClass("2g", klasa2);
                zsl.AddClass("4h", klasa3);

                szkoly.AddSchool("zsl", zsl);
                return szkoly;
            }
        }
    }
}
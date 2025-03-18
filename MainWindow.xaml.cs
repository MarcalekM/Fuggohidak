using System.IO;
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

namespace Fuggohidak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuggohid> hidak = new();
        public MainWindow()
        {
            InitializeComponent();

            using StreamReader sr = new(
                path: @"..\..\..\src\fuggohidak.csv",
                encoding: Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) hidak.Add(new(sr.ReadLine()));
            
            foreach(var hid in hidak) HidNevek.Items.Add(hid.Nev);
            HidNevek.SelectedIndex = 0;
        }

        private void HidNevek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var hid = hidak.Where(h => h.Nev.Equals(HidNevek.SelectedItem.ToString())).First();
            KijeloltHely.Text = hid.Hely;
            KijeloltOrszag.Text = hid.Orszag;
            KijeloltHossz.Text = hid.Hossz.ToString();
            KijeloltEv.Text = hid.Ev.ToString();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            Darab.Content = hidak.Where(h => h.Ev < 2000).Count().ToString() + " darab";
        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            Darab.Content = hidak.Where(h => h.Ev >= 2000).Count().ToString() + " darab";
        }
    }
}
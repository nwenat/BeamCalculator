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

namespace WpfApp1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CrossSectionCahracteristics przkroj1 = new CrossSectionCahracteristics();

        public MainWindow()
        {
            InitializeComponent();

            przkroj1.h = 0;
            przkroj1.b = 0;
            refreshField(przkroj1.a);
        }

        private void refreshField(Double wynik)
        {
            this.field.Text = wynik.ToString();
        }

        private void resultBtn_Click(object sender, RoutedEventArgs e)
        {
            Double hight_h = Double.Parse(hight.Text.Replace('.', ','));
            przkroj1.h = hight_h;
            Double width_b = Double.Parse(width.Text.Replace('.', ','));
            przkroj1.b = width_b;

            refreshField(przkroj1.a);
        }
    }
}

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
using System.Windows.Shapes;

namespace NewCurtains
{
    /// <summary>
    /// Логика взаимодействия для WindowPosh.xaml
    /// </summary>
    public partial class WindowPosh : Window
    {
        double Cost;
        double WW;
        string TT;
        double HH;
        public WindowPosh(double W_Widht, double HHeight, string Type)
        {
            InitializeComponent();
            WW = W_Widht;
            TT = Type;
            HH = HHeight;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox_NizP.Visibility = Visibility.Hidden;
            comboBox_NizT.Visibility = Visibility.Hidden;
            label4.Content = "Текущая штора - " + Convert.ToString(TT) + " шириной " + Convert.ToString(WW + 0.2) + " метров по карнизу (+20см).";
            if (TT == "тюль")
            {
                comboBox_NizT.Visibility = Visibility.Visible;
                comboBox_NizP.Visibility = Visibility.Hidden;
            }
            if (TT == "портьера")
            {
                comboBox_NizT.Visibility = Visibility.Hidden;
                comboBox_NizP.Visibility = Visibility.Visible;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            if ((TT == "тюль") && (Item_7.IsSelected == true) && (Item_SL.IsSelected == true)) Cost = 2652;
            if ((TT == "тюль") && (Item_7.IsSelected == true) && (Item_RS.IsSelected == true)) Cost = 3179;
            if ((TT == "тюль") && (Item_Ton.IsSelected == true) && (Item_RS.IsSelected == true)) Cost = 3179;
            if ((TT == "тюль") && (Item_Ton.IsSelected == true) && (Item_SL.IsSelected == true))
            {
                MessageBox.Show("Недопустимое сочетание!");
                Cost = 0;
            }
            if ((TT == "тюль") && (Item_A.IsSelected == true) && (Item_RS.IsSelected == true)) Cost = 4752;
            if ((TT == "тюль") && (Item_A.IsSelected == true) && (Item_SL.IsSelected == true))
            {
                MessageBox.Show("Недопустимое сочетание!");
                Cost = 0;
            }
            if ((TT == "портьера") && (Item_Bez.IsSelected == true) && (Item_SL.IsSelected == true)) Cost = 3500;
            if ((TT == "портьера") && (Item_Na.IsSelected == true) && (Item_SL.IsSelected == true)) Cost = 5500;
            if ((TT == "портьера") && (Item_Na.IsSelected == true) && (Item_RS.IsSelected == true)) Cost = 6306;
            if ((TT == "портьера") && (Item_Bez.IsSelected == true) && (Item_RS.IsSelected == true)) Cost = 4200;
            
            
            label_main.Content = Convert.ToString(Cost);
            if (HH < 3.6)
            {
                label5.Content = Convert.ToString(Cost * (WW + 0.2));
            }
            else
            {
                label5.Content = Convert.ToString(Cost * (WW + 0.2) * 1.3) + " (надбавка 30%)";
            }
        }
    }
}

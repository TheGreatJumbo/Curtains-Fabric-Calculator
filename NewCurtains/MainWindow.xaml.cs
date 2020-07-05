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

namespace NewCurtains
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double W_Widht = 0;
        double HHeight = 0;
        double SUM = 0;
        double SUMP = 0;
        double SUMT = 0;
        double PoshP = 0;
        double PoshT = 0;
        double Texture = 0;
        double TextureT = 0;
        double K = 1.5;
        double KT = 1.5;
        double Cost = 0;
        double CostT = 0;
        double METERS = 0;
        double METERST = 0;
        double Raport = 0;
        

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBox_Window_width.Text == "") || (TextBox_Height.Text == "") || (TextBox_ShT.Text == ""))
                MessageBox.Show("Не все поля заполнены");
            if (TextBox_Window_width.Text != "") W_Widht = Convert.ToDouble(TextBox_Window_width.Text);
            if (TextBox_Height.Text != "") HHeight = Convert.ToDouble(TextBox_Height.Text);
            

            //Портера
            if (TextBox_ShT.Text != "") Texture = Convert.ToDouble(TextBox_ShT.Text);
            //
            if (Item_15.IsSelected == true) K = 1.5;
            if (Item_18.IsSelected == true) K = 1.8;
            if (Item_20.IsSelected == true) K = 2.0;
            if (Item_25.IsSelected == true) K = 2.5;
            //
            if (TextBox_Cost.Text != "") Cost = Convert.ToDouble(TextBox_Cost.Text);
            
            if (textBox_Raport.Text != "") Raport = Convert.ToDouble(textBox_Raport.Text);

            if (checkBox_Raport.IsChecked == false)
            {
                if (Texture > HHeight + 0.3) METERS = HHeight * K;
                else METERS = CalcPort() * (HHeight + 0.3);
            }
            else
            {
                double OKR = (HHeight / Raport) % 10;
                if ((HHeight / Raport) % 10 == 0)
                    METERS = CalcPort() * (((Math.Ceiling((HHeight + 0.3) / Raport) + 1) * Raport));
                else
                    METERS = CalcPort() * ((Math.Ceiling((HHeight + 0.3) / Raport) * Raport));
            }

            
            
            PoshP = Math.Round(METERS * Cost, 2);
            SUM = PoshP + PoshT;
            Label_PoshP.Content = PoshP;
            Label_Sum.Content = SUM.ToString();
            METERS = Math.Round(METERS, 2);
            
            Label_Porter.Content = METERS.ToString() + " метров";
            button_PoshP.IsEnabled = true;
            
        }

        private void buttonT_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBox_Window_width.Text == "") || (TextBox_Height.Text == "") || (TextBox_ShT1.Text == ""))
                MessageBox.Show("Не все поля заполнены");
            if (TextBox_Window_width.Text != "") W_Widht = Convert.ToDouble(TextBox_Window_width.Text);
            if (TextBox_Height.Text != "") HHeight = Convert.ToDouble(TextBox_Height.Text);
            //Тюль
            if (TextBox_ShT1.Text != "") TextureT = Convert.ToDouble(TextBox_ShT1.Text);
            //
            if (Item_1.IsSelected == true) KT = 1.5;
            if (Item_2.IsSelected == true) KT = 1.8;
            if (Item_3.IsSelected == true) KT = 2.0;
            if (Item_4.IsSelected == true) KT = 2.5;
            //
            if (TextBox_Cost1.Text != "") CostT = Convert.ToDouble(TextBox_Cost1.Text);

            if (TextureT > HHeight + 0.3) METERST = HHeight * KT;
            else METERST = CalcTul() * (HHeight + 0.3);

            PoshT = Math.Round(METERST * CostT, 2);
            SUM = PoshP + PoshT;
            Label_PoshT.Content = PoshT;
            METERST = Math.Round(METERST, 2);
            Label_Tul.Content = METERST.ToString() + " метров";
            button_PoshT.IsEnabled = true;
            Label_Sum.Content = SUM.ToString();
        }

        public double CalcPort()
        {
            //double result;
            double num = W_Widht * K / Texture;
            double okr = 0;
            double cel = Math.Truncate(num);
            double drob = num - cel;
            if (drob <= 0.1)
                okr = cel;
            if (drob > 0.1)
                okr = cel + 1;
            //result = okr * HHeight * Cost;
            return okr;
        }
        public double CalcTul()
        {
            double result;
            double num = W_Widht * KT / TextureT;
            double okr = 0;
            double cel = Math.Truncate(num);
            double drob = num - cel;
            if (drob <= 0.1)
                okr = cel;
            if (drob > 0.1)
                okr = cel + 1;
            result = okr * HHeight * CostT;
            return okr;
        }
        private void TextBox_Window_width_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,".IndexOf(e.Text) < 0;
        }

        private void TextBox_Height_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            textBox_Raport.IsEnabled = true;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowPosh A = new WindowPosh(W_Widht, HHeight, "портьера");
            A.Show();
        }

        private void TextBox_Window_width_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowPosh A = new WindowPosh(W_Widht, HHeight, "тюль");
            A.Show();
        }

        
    }
}

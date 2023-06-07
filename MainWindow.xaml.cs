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

namespace Calculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string option;
        public string num_1;
        public bool num_2;
        public MainWindow()
        {
            num_2 = true;
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (num_2)
            {
                num_2 = false;
                txtDisplay.Text = "0";
            }
            Button button = (Button)sender;
            if (txtDisplay.Text == "0")
                txtDisplay.Text = button.Content.ToString();
            else
                txtDisplay.Text += button.Content;


        }
       
        private void operationsClick(object sender, RoutedEventArgs e)
        {
          

            if (option == "+" || option == "-" || option == "X" || option == "/")
            {
                equal_ButtonClick(sender, e);
            }

            Button button = (Button)sender;
            if (button.Content is Image img)
            {
                option = "/";
            }
            else
            {
                option = button.Content.ToString();
            }
            num_1 = txtDisplay.Text;
            num_2 = true;
        }

        private void equal_ButtonClick(object sender, RoutedEventArgs e)
        {
            double dnum_1, dnum_2, result;
            result = 0;
            dnum_1=Convert.ToDouble(num_1);
            dnum_2=Convert.ToDouble(txtDisplay.Text);
            if (option == "+")
            {
                result = dnum_1 + dnum_2;
            }
            if (option == "-")
            {
                result = dnum_1 - dnum_2;
            }
            if (option == "X")
            {
                result = dnum_1 * dnum_2;
            }
            if (option == "/")
            {
                result = dnum_1 / dnum_2;
                
            }
            if (option == "%")
            {
                result = (dnum_1 / 100) * dnum_2;
            }
            option = "=";
            num_2 = true;
            txtDisplay.Text = result.ToString();
        }

       

        private void clear_ButtonClick(object sender, RoutedEventArgs e)
        {
            txtDisplay.Clear();
            num_1 = "";
        }

        private void delete_ButtonClick(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
        }

        private void point_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains(","))
                txtDisplay.Text += ",";
        }
    }
}

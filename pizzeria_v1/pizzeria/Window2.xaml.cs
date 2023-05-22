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

namespace pizzeria
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private string result;
        public Window2(double r)
        {
            InitializeComponent();
            result = Convert.ToString(r);
            ResultBox();
        }

        private void ResultBox()
        {
            resultbox.Content = "Your pizza is " + result + " from 100!\n Thanks!";
        }
    }
}

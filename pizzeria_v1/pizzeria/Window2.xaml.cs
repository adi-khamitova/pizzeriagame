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
        private int count;
        public Window2(int c)
        {
            InitializeComponent();
            count = c;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (count >= 3)
            {
                this.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("C:\\аделя\\pizzeria\\pizzeria\\backgroudwithpastaandcheese.jpg", UriKind.RelativeOrAbsolute)) };
            }
            else
            {
                this.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("C:\\аделя\\pizzeria\\pizzeria\\backgroundwithpasta.jpg", UriKind.RelativeOrAbsolute)) };
            }
        }
    }
}

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
using System.Windows.Threading;

namespace pizzeria
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Vector relativeMousePos;
        FrameworkElement draggedObject;
        private int tomato = 0, cheese = 0;
        private int[,] coordinates = new int[12, 2];
        private double currx, curry;

        int count = 0;
        public Window1()
        {
            InitializeComponent();
        }

        void StartDrag(object sender, MouseButtonEventArgs e)
        {
            draggedObject = (FrameworkElement)sender;
            var point = e.GetPosition(DragArena);
            var newPos = point - relativeMousePos;
            currx = newPos.X;
            curry = newPos.Y;
            if ((currx - 858)*(currx - 858) + (curry - 472)*(curry - 472) <= 150*150) {
                count--;
            }
            relativeMousePos = e.GetPosition(draggedObject) - new Point();
            draggedObject.MouseMove += OnDragMove;
            draggedObject.LostMouseCapture += OnLostCapture;
            draggedObject.MouseUp += OnMouseUp;
            Mouse.Capture(draggedObject);
        }
        void OnDragMove(object sender, MouseEventArgs e)
        {
            UpdatePosition(e);
        }
        Point UpdatePosition(MouseEventArgs e)
        {
            var point = e.GetPosition(DragArena);
            var newPos = point - relativeMousePos;
            Canvas.SetLeft(draggedObject, newPos.X);
            Canvas.SetTop(draggedObject, newPos.Y);
            return newPos;
        }
        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            FinishDrag(sender, e);
            Mouse.Capture(null);
        }

        void OnLostCapture(object sender, MouseEventArgs e)
        {
            FinishDrag(sender, e);
        }
        void FinishDrag(object sender, MouseEventArgs e)
        {
            draggedObject.MouseMove -= OnDragMove;
            draggedObject.LostMouseCapture -= OnLostCapture;
            draggedObject.MouseUp -= OnMouseUp;
            Point newPos = UpdatePosition(e);
            currx = newPos.X;
            curry = newPos.Y;
            if ((currx - 858) * (currx - 858) + (curry - 472) * (curry - 472) <= 150*150)
            {
                count++;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3(count, increment);
            window3.Show();
            l = 0;
            this.Close();
        }

        private void NextWindow()
        {
            Window3 window3 = new Window3(count, increment);
            window3.Show();
            this.Close();
        }

        private void cheesebutton_Click(object sender, RoutedEventArgs e)
        {
            if (tomato == 0)
            {
                this.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("C:\\аделя\\pizzeria\\pizzeria\\backgroungwithcheese.jpg", UriKind.RelativeOrAbsolute)) };
            }
            else
            {
                this.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("C:\\аделя\\pizzeria\\pizzeria\\backgroudwithpastaandcheese.jpg", UriKind.RelativeOrAbsolute)) };
            }
            cheese = 1;
        }

        private void tomatobutton_Click(object sender, RoutedEventArgs e)
        {
            if (cheese == 0)
            {
                this.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("C:\\аделя\\pizzeria\\pizzeria\\backgroundwithpasta.jpg", UriKind.RelativeOrAbsolute)) };
            }
            else
            {
                this.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri("C:\\аделя\\pizzeria\\pizzeria\\backgroudwithpastaandcheese.jpg", UriKind.RelativeOrAbsolute)) };
            }
            tomato = 1;
        }
        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private int increment = 60;
        int l = 1;
        private void dtTicker(object? sender, EventArgs e)
        {
            if (l == 1)
            {
                increment--;

                TimerLabel.Content = increment.ToString();
                if (increment == 0)
                {
                    NextWindow();
                    l = 0;
                }
            }
        }
    }
}

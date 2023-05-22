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
    public partial class Window3 : Window
    {
        private int count, increment;
        Vector relativeMousePos;
        FrameworkElement draggedObject;
        double starty = 0;
        double result;
        public Window3(int c, int i)
        {
            InitializeComponent();
            count = c;
            increment = i;
        }
        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            firegif.Position = TimeSpan.FromMilliseconds(1);
        }

        double k;
        private void Result()
        {
            if (increment >= 30)
            {
                k = 1;
            }
            else
            {
                k = Convert.ToDouble(increment) / 60 + 0.5;
            }
            result = Math.Truncate(count * 100 / 15 * k);
        }
        void StartDrag(object sender, MouseButtonEventArgs e)
        {
            draggedObject = (FrameworkElement)sender;
            var point = e.GetPosition(DragArena);
            var newPos = point - relativeMousePos;
            starty = 394;
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
            if (newPos.X <= 724 && newPos.X >= 250)
                Canvas.SetLeft(draggedObject, newPos.X);
            else if (newPos.X > 724)
            {
                Canvas.SetLeft(draggedObject, 724);
            }
            else
            {
                Canvas.SetLeft(draggedObject, 250);
            }
            Canvas.SetTop(draggedObject, starty);
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
            if ((newPos.X >= 250) && (newPos.X <= 330)) {
                NextWindow();
            }
        }

        private void NextWindow()
        {
            Result();
            Window2 window2 = new Window2(result);
            window2.Show();
            this.Close();
        }
    }
}

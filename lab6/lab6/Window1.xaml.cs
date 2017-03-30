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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab6
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(string text)
        {
            InitializeComponent();
            label.Content = text;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var count=new Random().Next(0,100);
            var tg=new TransformGroup();
            var trans = new TranslateTransform();
            var rot=new RotateTransform();
            var sc=new ScaleTransform();
            ColorAnimation CA = new ColorAnimation();
            switch (count%3)
            {
                case 0:
                {
                        DoubleAnimation da=new DoubleAnimation(10,250,TimeSpan.FromSeconds(new Random().Next(2,10)));
                        DoubleAnimation db = new DoubleAnimation(0.3, 1.7, TimeSpan.FromSeconds(new Random().Next(5,15)));
                        da.AutoReverse = true;
                        db.AutoReverse = true;
                        da.RepeatBehavior = RepeatBehavior.Forever;
                        db.RepeatBehavior = RepeatBehavior.Forever;
                        trans.BeginAnimation(TranslateTransform.XProperty, da);
                        sc.BeginAnimation(ScaleTransform.ScaleXProperty, db);
                        sc.BeginAnimation(ScaleTransform.ScaleYProperty, db);
                        tg.Children.Add(trans);
                        tg.Children.Add(sc);
                        label.RenderTransform = tg;
                        break;
                }
                case 1:
                {
                        DoubleAnimation da = new DoubleAnimation(10, 250, TimeSpan.FromSeconds(new Random().Next(5,15)));
                        DoubleAnimation db = new DoubleAnimation(0.3, 1.7, TimeSpan.FromSeconds(new Random().Next(5,15)));
                        da.AutoReverse = true;
                        db.AutoReverse = true;
                        da.RepeatBehavior = RepeatBehavior.Forever;
                        db.RepeatBehavior = RepeatBehavior.Forever;
                        trans.BeginAnimation(TranslateTransform.YProperty, da);
                        sc.BeginAnimation(ScaleTransform.ScaleXProperty, db);
                        sc.BeginAnimation(ScaleTransform.ScaleYProperty, db);
                        tg.Children.Add(trans);
                        tg.Children.Add(sc);
                        label.RenderTransform = tg;
                        Color rgbColorFrom = Color.FromRgb(255, 255, 0); ;
                        Color rgbColorTo = Color.FromRgb(0, 0, 255);
                        SolidColorBrush myBrush = new SolidColorBrush();
                        myBrush.Color = Colors.Blue;
                        CA.From = rgbColorFrom;
                        CA.To = rgbColorTo;
                        CA.Duration = new Duration(TimeSpan.FromSeconds(new Random().Next(5,15)));
                        CA.AutoReverse = true;
                        CA.RepeatBehavior = RepeatBehavior.Forever;
                        myBrush.BeginAnimation(SolidColorBrush.ColorProperty, CA);
                        // end animation
                        label.Background = myBrush;
                        break;
                    }
                case 2:
                {
                    DoubleAnimation dx = new DoubleAnimation(10, 250,
                        TimeSpan.FromSeconds(new Random().Next(5,15)));
                    DoubleAnimation dsc = new DoubleAnimation(0.3, 3, TimeSpan.FromSeconds(new Random().Next(5,15)));
                    DoubleAnimation dy = new DoubleAnimation(10, 250,
                        TimeSpan.FromSeconds(new Random().Next(5,15)));
                    DoubleAnimation dr = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(new Random().Next(5,15)));
                    dx.AutoReverse = true;
                    dy.AutoReverse = true;
                    dr.AutoReverse = true;
                    dsc.AutoReverse = true;
                    dx.RepeatBehavior = RepeatBehavior.Forever;
                    dy.RepeatBehavior = RepeatBehavior.Forever;
                    dr.RepeatBehavior = RepeatBehavior.Forever;
                    dsc.RepeatBehavior = RepeatBehavior.Forever;
                    trans.BeginAnimation(TranslateTransform.XProperty, dx);
                    trans.BeginAnimation(TranslateTransform.YProperty, dy);
                    sc.BeginAnimation(ScaleTransform.ScaleXProperty, dsc);
                    sc.BeginAnimation(ScaleTransform.ScaleYProperty, dsc);
                    rot.BeginAnimation(RotateTransform.AngleProperty, dr);

                    tg.Children.Add(rot);
                    tg.Children.Add(sc);
                    tg.Children.Add(trans);
                    label.RenderTransform = tg;
                    break;
                }
                    
            }
        }

        private void label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

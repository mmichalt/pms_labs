using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int btncounter = 0,listcounter=0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private Random heightRandom, widthRandom;

        private void ClickHandler(object sender, MouseButtonEventArgs e)
        {
            if ((e.Source as Control).Name.Contains("LB"))
            {
                Window1 w1=new Window1("LISTBOX");
                w1.ShowDialog();
            }
            if ((e.Source as Control).Name.Contains("BTN"))
            {
                Window1 w1 = new Window1("BUTTON");
                w1.ShowDialog();
            }
        }
        private void listbtn_Click(object sender, RoutedEventArgs e)
        {
            if (listcounter > 5)
            {
                listbtn.IsEnabled = false;
            }
            else
            {
                heightRandom = new Random();
                widthRandom = new Random();
                ListBox lstb = new ListBox();
                lstb.Name = $"LB{listcounter}";
                lstb.MouseDoubleClick += ClickHandler;
                lstb.Items.Add("СПИСОК");
                Canvas.SetLeft(lstb, widthRandom.NextDouble() * 500);
                Canvas.SetTop(lstb, heightRandom.NextDouble() * 300);
                lstb.Width = widthRandom.Next(75, 150);
                lstb.Height = heightRandom.Next(75, 90);
                TranslateTransform trans = new TranslateTransform();
                var top = Canvas.GetTop(lstb);
                var left = Canvas.GetLeft(lstb);
                lstb.RenderTransformOrigin = new Point(0.5, 0.5);
                switch (listcounter % 3)
                {
                    case 0:
                        {
                            DoubleAnimation anim1 = new DoubleAnimation(0, Canvass.Width - top - lstb.Width, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            DoubleAnimation anim2 = new DoubleAnimation(0, Canvass.Height - left - lstb.Height, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim2.AutoReverse = true;
                            anim1.AutoReverse = true;
                            anim2.RepeatBehavior = RepeatBehavior.Forever;
                            anim1.RepeatBehavior = RepeatBehavior.Forever;
                            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
                            trans.BeginAnimation(TranslateTransform.YProperty, anim2);
                            lstb.RenderTransform = trans;
                            Color rgbColorFrom = Color.FromRgb(0, 0, 0); ;
                            Color rgbColorTo = Color.FromRgb(255, 255, 0);

                            SolidColorBrush myBrush = new SolidColorBrush();
                            myBrush.Color = Colors.Blue;
                            // ColorAnimation cl = new ColorAnimation(rgbColorFrom, rgbColorTo, Duration.Forever);
                            ColorAnimation myColorAnimation = new ColorAnimation();
                            myColorAnimation.From = rgbColorFrom;
                            myColorAnimation.To = rgbColorTo;
                            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(new Random().Next(5,15)));
                            myColorAnimation.AutoReverse = true;
                            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
                            // end animation
                            lstb.Background = myBrush;
                            Canvass.Children.Add(lstb);
                            listcounter++;
                            break;
                        }
                    case 1:
                        {
                            var transformGroup = new TransformGroup();
                            //////////
                            DoubleAnimation anim1 = new DoubleAnimation(0, Canvass.Height - top - lstb.Height, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim1.AutoReverse = true;
                            anim1.RepeatBehavior = RepeatBehavior.Forever;
                            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
                            //////////
                            var rotateTransform = new RotateTransform();
                            DoubleAnimation anim2 = new DoubleAnimation(360, 0, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim2.AutoReverse = true;
                            anim2.RepeatBehavior = RepeatBehavior.Forever;
                            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, anim2);
                            transformGroup.Children.Add(trans);
                            transformGroup.Children.Add(rotateTransform);
                            lstb.RenderTransform = transformGroup;
                            Color rgbColorFrom = Color.FromRgb(255, 255, 0); ;
                            Color rgbColorTo = Color.FromRgb(0, 255, 255);

                            SolidColorBrush myBrush = new SolidColorBrush();
                            myBrush.Color = Colors.Blue;
                            ColorAnimation myColorAnimation = new ColorAnimation();
                            myColorAnimation.From = rgbColorFrom;
                            myColorAnimation.To = rgbColorTo;
                            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(new Random().Next(5,15)));
                            myColorAnimation.AutoReverse = true;
                            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
                            // end animation
                            lstb.Background = myBrush;
                            Canvass.Children.Add(lstb);
                            listcounter++;
                            break;
                        }
                    case 2:
                        {
                            Color rgbColorFrom, rgbColorTo;
                            var transformGroup = new TransformGroup();
                            //////////
                            DoubleAnimation anim1 = new DoubleAnimation(0, Canvass.Height - top - lstb.Height * 1.5, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim1.AutoReverse = true;
                            anim1.RepeatBehavior = RepeatBehavior.Forever;
                            if (Canvass.Children.Count > 4)
                            {
                                trans.BeginAnimation(TranslateTransform.YProperty, anim1);
                                rgbColorFrom = Color.FromRgb(0, 255, 255);
                                rgbColorTo = Color.FromRgb(255, 0, 255);
                            }
                            else
                            {
                                trans.BeginAnimation(TranslateTransform.XProperty, anim1);
                                rgbColorFrom = Color.FromRgb(255, 255, 255);
                                rgbColorTo = Color.FromRgb(0, 0, 0);
                            }
                            //////////
                            var scaleTransform = new ScaleTransform();
                            DoubleAnimation anim2 = new DoubleAnimation(0.3, 1.7, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim2.AutoReverse = true;
                            anim2.RepeatBehavior = RepeatBehavior.Forever;
                            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, anim2);
                            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, anim2);
                            transformGroup.Children.Add(trans);
                            transformGroup.Children.Add(scaleTransform);
                            lstb.RenderTransform = transformGroup;


                            SolidColorBrush myBrush = new SolidColorBrush();
                            myBrush.Color = Colors.Blue;
                            // ColorAnimation cl = new ColorAnimation(rgbColorFrom, rgbColorTo, Duration.Forever);
                            ColorAnimation myColorAnimation = new ColorAnimation();
                            myColorAnimation.From = rgbColorFrom;
                            myColorAnimation.To = rgbColorTo;
                            myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(new Random().Next(5,15)));
                            myColorAnimation.AutoReverse = true;
                            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
                            // end animation
                            lstb.Background = myBrush;
                            Canvass.Children.Add(lstb);
                            listcounter++;
                            break;
                        }
                }

            }
        
    }

        private void btnbtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (btncounter > 5)
            {
                btnbtn.IsEnabled = false;
            }
                else
            {

                heightRandom=new Random();
                widthRandom=new Random();
                Button btn = new Button();
                btn.Name = $"BTN{btncounter}";
                btn.MouseDoubleClick += ClickHandler;
                btn.Content = "КНОПКА";
                Canvas.SetLeft(btn, widthRandom.NextDouble()*500);
                Canvas.SetTop(btn, heightRandom.NextDouble() * 300);
                btn.Width = widthRandom.Next(10,50);
                btn.Height = heightRandom.Next(20,40);
                TranslateTransform trans = new TranslateTransform();
                var top = Canvas.GetTop(btn);
                var left = Canvas.GetLeft(btn);
                btn.RenderTransformOrigin = new Point(0.5, 0.5);
                switch (btncounter%3)
                {
                    case 0:
                    {
                            DoubleAnimation anim1 = new DoubleAnimation(0, Canvass.Width - top - btn.Width, TimeSpan.FromSeconds(2));
                            DoubleAnimation anim2 = new DoubleAnimation(0, Canvass.Height - left - btn.Height, TimeSpan.FromSeconds(2));
                            anim2.AutoReverse = true;
                            anim1.AutoReverse = true;
                            anim2.RepeatBehavior = RepeatBehavior.Forever;
                            anim1.RepeatBehavior = RepeatBehavior.Forever;
                            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
                            trans.BeginAnimation(TranslateTransform.YProperty, anim2);
                            btn.RenderTransform = trans;
                            Color rgbColorFrom = Color.FromRgb(0, 0, 0); ;
                            Color rgbColorTo = Color.FromRgb(255, 0, 0);

                            SolidColorBrush myBrush = new SolidColorBrush();
                            myBrush.Color = Colors.Blue;
                            // ColorAnimation cl = new ColorAnimation(rgbColorFrom, rgbColorTo, Duration.Forever);
                            ColorAnimation myColorAnimation = new ColorAnimation();
                            myColorAnimation.From = rgbColorFrom;
                            myColorAnimation.To = rgbColorTo;
                            myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(2000));
                            myColorAnimation.AutoReverse = true;
                            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
                            // end animation
                            btn.Background = myBrush;
                            Canvass.Children.Add(btn);
                            btncounter++;
                            break;
                        }
                    case 1:
                    {
                            var transformGroup = new TransformGroup();
                            //////////
                            DoubleAnimation anim1 = new DoubleAnimation(0, Canvass.Height - top - btn.Height, TimeSpan.FromSeconds(2));
                            anim1.AutoReverse = true;
                            anim1.RepeatBehavior = RepeatBehavior.Forever;
                            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
                            //////////
                            var rotateTransform = new RotateTransform();
                            DoubleAnimation anim2 = new DoubleAnimation(0,360, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim2.AutoReverse = true;
                            anim2.RepeatBehavior = RepeatBehavior.Forever;
                            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, anim2);
                            transformGroup.Children.Add(trans);
                            transformGroup.Children.Add(rotateTransform);
                            btn.RenderTransform = transformGroup;
                            Color rgbColorFrom = Color.FromRgb(255, 0, 0); ;
                            Color rgbColorTo = Color.FromRgb(0, 255, 0);

                            SolidColorBrush myBrush = new SolidColorBrush();
                            myBrush.Color = Colors.Blue;
                            ColorAnimation myColorAnimation = new ColorAnimation();
                            myColorAnimation.From = rgbColorFrom;
                            myColorAnimation.To = rgbColorTo;
                            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(new Random().Next(5,15)));
                            myColorAnimation.AutoReverse = true;
                            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
                            // end animation
                            btn.Background = myBrush;
                            Canvass.Children.Add(btn);
                            btncounter++;
                            break;
                        }
                    case 2:
                    {
                            Color rgbColorFrom,rgbColorTo;
                            var transformGroup = new TransformGroup();
                            //////////
                            DoubleAnimation anim1 = new DoubleAnimation(0, Canvass.Height - top - btn.Height*1.5, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim1.AutoReverse = true;
                            anim1.RepeatBehavior = RepeatBehavior.Forever;
                        if (Canvass.Children.Count > 4)
                        {
                            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
                            rgbColorFrom = Color.FromRgb(0, 255, 0);
                            rgbColorTo = Color.FromRgb(0, 0, 255);
                        }
                        else
                        {
                            trans.BeginAnimation(TranslateTransform.XProperty, anim1);
                                rgbColorFrom = Color.FromRgb(0, 0, 255);
                                rgbColorTo = Color.FromRgb(255, 255, 255);
                            }
                            //////////
                            var scaleTransform = new ScaleTransform();
                            DoubleAnimation anim2 = new DoubleAnimation(0.5, 1.5, TimeSpan.FromSeconds(new Random().Next(5,15)));
                            anim2.AutoReverse = true;
                            anim2.RepeatBehavior = RepeatBehavior.Forever;
                            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, anim2);
                            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, anim2);
                            transformGroup.Children.Add(trans);
                            transformGroup.Children.Add(scaleTransform);
                            btn.RenderTransform = transformGroup;
                            

                            SolidColorBrush myBrush = new SolidColorBrush();
                            myBrush.Color = Colors.Blue;
                            // ColorAnimation cl = new ColorAnimation(rgbColorFrom, rgbColorTo, Duration.Forever);
                            ColorAnimation myColorAnimation = new ColorAnimation();
                            myColorAnimation.From = rgbColorFrom;
                            myColorAnimation.To = rgbColorTo;
                            myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(new Random().Next(5,15)));
                            myColorAnimation.AutoReverse = true;
                            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
                            // end animation
                            btn.Background = myBrush;
                            Canvass.Children.Add(btn);
                        btncounter++;
                            break;
                        }
                }
                
            }
        }
    }
}

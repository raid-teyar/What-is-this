using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using NAudio.Wave;

namespace TheQuize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Helpers helpers = new Helpers();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.WindowState = WindowState.Minimized;
                Close();
            }
        }

        private void splashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation sizeAnimation = new DoubleAnimation(60, 80, TimeSpan.FromMilliseconds(1000))
            {
                EasingFunction = new QuadraticEase()
            };
            DoubleAnimation opacityAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(1000));
            Storyboard.SetTargetProperty(sizeAnimation, new PropertyPath(FontSizeProperty));
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(OpacityProperty));

            Storyboard s = new Storyboard();
            opacityAnimation.Completed += OpacityAnimation_Completed1;

            s.Children.Add(sizeAnimation);
            s.Children.Add(opacityAnimation);
            splashScreen.BeginStoryboard(s);
        }

        private void OpacityAnimation_Completed1(object sender, EventArgs e)
        {
            DoubleAnimation stayAnimation = new DoubleAnimation(1, 1, TimeSpan.FromMilliseconds(2000));
            stayAnimation.Completed += StayAnimation_Completed;
            splashScreen.BeginAnimation(OpacityProperty ,stayAnimation);
        }

        private void StayAnimation_Completed(object sender, EventArgs e)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            opacityAnimation.Completed += OpacityAnimation_Completed;
            splashScreen.BeginAnimation(OpacityProperty, opacityAnimation);
        }


        private void OpacityAnimation_Completed(object sender, EventArgs e)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(1000));
            mainGrid.BeginAnimation(OpacityProperty, opacityAnimation);
            helpers.PlayMusic("src/light-step-8021.mp3", .1f, true);
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            helpers.PlayMusic("src/hover.wav", .8f);
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBox = (TextBlock)sender;
            if (textBox.Text != "Quit")
            {
                pageFrame.Navigate(new Uri($"pages/{textBox.Text}.xaml", UriKind.Relative));
            }
        }
    }
}

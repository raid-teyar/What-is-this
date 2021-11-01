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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TheQuize.pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Helpers helpers = new Helpers();
        
        public Home()
        {
            InitializeComponent();
        }

        public void OpacityAnimation_Completed(object sender, EventArgs e)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(1000));
            mainGrid.BeginAnimation(OpacityProperty, opacityAnimation);
            helpers.PlayMusic("src/light-step-8021.mp3", .1f, true);
        }


        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBox = (TextBlock)sender;
            if (textBox.Text != "Quit")
            {
                NavigationService.Navigate(new Uri($"pages/{textBox.Text}.xaml", UriKind.Relative));
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            helpers.PlayMusic("src/hover.wav", .8f);
        }
    }
}

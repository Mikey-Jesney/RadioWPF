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
using System.IO;
using System.Media;
using Microsoft.Win32;


namespace RadioWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Radio radio = new Radio();

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(@"C:\Users\TECH-W024-BIRM\Desktop\lyrics\radiostate3.json"))
            {
                radio.Channel = radio.Read();

            } 
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            radio.TurnOn();
            radio.Songs(radio.Channel);
            On_Off_Text.Text = radio.Play();
            Volume_Text.Text = radio.VolPlay();

        }

        private void chan_1(object sender, RoutedEventArgs e)
        {
            radio.Channel = 1;
            On_Off_Text.Text = radio.Play();
            radio.Songs(1);



        }

        private void chan_2(object sender, RoutedEventArgs e)
        {
            radio.Channel = 2;
            On_Off_Text.Text = radio.Play();
            radio.Songs(2);
        }

        private void chan_3(object sender, RoutedEventArgs e)
        {
            radio.Channel = 3;
            On_Off_Text.Text = radio.Play();
            radio.Songs(3);
        }

        private void chan_4(object sender, RoutedEventArgs e)
        {
            radio.Channel = 4;
            On_Off_Text.Text = radio.Play();
            radio.Songs(4);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            radio.Write();
        }

        private void Vol_up(object sender, RoutedEventArgs e)
        {
                radio.Volume++;
                Volume_Text.Text = radio.VolPlay();
        }

        private void Vol_down(object sender, RoutedEventArgs e)
        {
                radio.Volume--;
                Volume_Text.Text = radio.VolPlay();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WorldOfWool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Displays Sheep emotion
            txtbHappiness.Text = happiness.ToString();
            //begins story board for sheep blinking
            sbSheep.Begin();
        }

        private void btnPlay_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Play));
        }


        int happiness = 0;
        private void btnLove_click (object sender, RoutedEventArgs e)
        {
            //when happiness is less than 100, increases as you click
            if (happiness < 100)
                {
                    happiness++; //increments
                    txtbHappiness.Text = happiness.ToString(); //displays textbox
                }
            else if (happiness == 100) //when happiness is equal to 100
                {
                sbSheep.Stop(); //stop storyboard with the bored sheep
                sbSmile.Begin(); //begin the storyboard with the smiling sheep
                }
            else
                {
                    happiness--; //stop after 100
                }
        }

    }

}
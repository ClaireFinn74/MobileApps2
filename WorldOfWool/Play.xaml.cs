using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WorldOfWool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Play : Page
    {
        public Play()
        {
            this.InitializeComponent();
            sbFallingItems.Begin();
        }

        //timer variables
        DispatcherTimer dispatch;
        DateTimeOffset start;
        DateTimeOffset lastTime;
        DateTimeOffset stop;
        int ticks = 0;
        int timesToTick = 2930;

        public void dispatcher()
        {
            //set up timer
            dispatch = new DispatcherTimer();
            //setup tick event
            dispatch.Tick += dispatch_Tick;
            // (0,0,0,0) starts as soon as page loads
            dispatch.Interval = new TimeSpan(0, 0, 0, 0);
            // starts the timer at the current time
            start = DateTimeOffset.Now;
            //getting to know the amount of time you've been on the game
            lastTime = start;
            // Starts the timer
            dispatch.Start();
        }

        //Setting tick event up
        private async void dispatch_Tick(object sender, object e)
        {
            //Starts off at the current time
            DateTimeOffset time = DateTimeOffset.Now;
            //lastTime is = start time,getting to know the amount of time the user has been on the game and updating the timer
            TimeSpan span = time - lastTime;
            //Setting the timer to write to the textblock
            txtbTimer.Text = "\t" + span.ToString();
            //Increments the time
            ticks++;

            //Stopping the timer and displaying a message
            if (ticks > timesToTick)
            {
                time = stop;
                dispatch.Stop();
                span = stop - start;
                txtbTimer.Text = "Time's up!! " + "\n";
                var dialog = new MessageDialog("Oooh! Time is up! If you want to go to your highscores, press the highscores button!");
                await dialog.ShowAsync();
            }
        }

        //Back to the sheep
        private void btnBack_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        //Pop-up box for the instructions, loads asynchronously
        private async void btnInstructions_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Try to avoid all of the falling sheep dogs coming to round you up using the Left, Right and Centre buttons to move around! \n Good Luck!!");
            await dialog.ShowAsync();
        }

        //Starting the timer when the page has loaded
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcher();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            sbBtnLeft.Begin();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            sbBtnRight.Begin();
        }

       private void btnCentre_Click(object sender, RoutedEventArgs e)
        {
            sbBtnCentre.Begin();
        }

      
    }
}

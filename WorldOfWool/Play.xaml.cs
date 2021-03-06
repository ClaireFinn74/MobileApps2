﻿using System;
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
        int timesToTick = 500;

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
                Globalclass.energy += 20;
                txtbEnergy.Text = Globalclass.energy.ToString() + " " + " " + "I've got tonnes of Energy now!! "; //displays textbox
                var dialog = new MessageDialog("All fed! Now I can play!");
                await dialog.ShowAsync();
                //Go back to Mainpage when timer is up
                Frame.Navigate(typeof(MainPage));
            }
        }

        //Starting the timer when the page has loaded
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcher();
        }

        //Pop-up box for the instructions, loads asynchronously
        private async void btnInstructions_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Sit back and let it rain grass so I have enough energy to play!" + "\n" + "Please click the Energy button when you're finished to check my energy levels!");
            await dialog.ShowAsync();
        }

    }
}

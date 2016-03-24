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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WorldOfWool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        public Game()
        {
            this.InitializeComponent();
        }

        //Back to the sheep
        private void btnBack_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        //Pop-up box for the instructions, loads asynchronously
        private async void btnInstructions_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Move your sheep left, right or centre to try to find friends to play with, once a dog appears though you better get running!!"
                                            + "\n" + "After you've finished the game, Please check your friend count!");
            await dialog.ShowAsync();
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
                var dialog = new MessageDialog("Ooh time up!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }

        private async void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            //Starts the sheep moving left storyboard
            sbBtnLeft.Begin();
            //Starts a random variable
            Random random = new Random();
            //Starts an array of images so the user can get a random image generated
            Image[] ImageArray = { Boxer, imgSleep, imgSheep, imgSmile, imgSleepSmile, imgTappedLeft, imgSheep2, imgSmile2, imgTappedLeft2, BorderCollie };
            //Randomizes the array
            Image RandomImage = ImageArray[random.Next(0, ImageArray.Length)];
            //If the image is the Boxer, boxer image becomes visible, Message box appears which ends the game                 
            if (RandomImage == Boxer)
            {
                Boxer.Visibility = Visibility.Visible;
                Globalclass.energy = 0;
                var dialog = new MessageDialog("Ooh the Boxer chased you out! Hard Luck!" + "\n" +
                                                "Check your friend count to see have you made any pals!");
                await dialog.ShowAsync();
                //When you press Close on the message box it navigates back to the Main Page
                Frame.Navigate(typeof(MainPage));
            }
            else if (RandomImage == imgSleep)
            {
                imgSleep.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgSheep)
            {
                imgSheep.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgSmile)
            {
                imgSmile.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgSleepSmile)
            {
                imgSleepSmile.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgTappedLeft)
            {
                imgTappedLeft.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgSheep2)
            {
                imgSheep2.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgSmile2)
            {
                imgSmile2.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == imgTappedLeft2)
            {
                imgTappedLeft2.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == BorderCollie)
            {
                BorderCollie.Visibility = Visibility.Visible;
                Globalclass.energy = 0;
                var dialog = new MessageDialog("Ooh the Border Collie chased you out! Hard Luck" + "\n" +
                                                "Check your friend count to see have you made any pals!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }

        private async void btnRight_Click(object sender, RoutedEventArgs e)
        {
            sbBtnRight.Begin();
            Random random = new Random();
            Image[] ImageArray = { Collie, RightSleep, RightSheep, RightSmile, RightSleepSmile, RightTappedLeft, RightSheep2, RightSmile2, RightTapped2, BassettHound };
            Image RandomImage = ImageArray[random.Next(0, ImageArray.Length)];
            if (RandomImage == BassettHound)
            {
                BassettHound.Visibility = Visibility.Visible;
                Globalclass.energy = 0;
                var dialog = new MessageDialog("Ooh the Basset Hound chased you out! Hard Luck" + "\n" +
                                                "Check your friend count to see have you made any pals!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
            else if (RandomImage == RightSleep)
            {
                RightSleep.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightSheep)
            {
                RightSheep.Visibility = Visibility.Visible;
                txtbRight.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightSmile)
            {
                RightSmile.Visibility = Visibility.Visible;
                txtbRight2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightSleepSmile)
            {
                RightSleepSmile.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightTappedLeft)
            {
                RightTappedLeft.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightSheep2)
            {
                RightSheep2.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightSmile2)
            {
                RightSmile2.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == RightTapped2)
            {
                RightTapped2.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            if (RandomImage == Collie)
            {
                Collie.Visibility = Visibility.Visible;
                Globalclass.energy = 0;
                var dialog = new MessageDialog("Ooh the Collie chased you out! Hard Luck" + "\n" +
                                                "Check your friend count to see have you made any pals!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }

        private async void btnCentre_Click(object sender, RoutedEventArgs e)
        {
            sbBtnCentre.Begin();
            Random random = new Random();
            Image[] ImageArray = { StBernard, Sleep, Sheep, Smile, SleepSmile, Tapped, Sheep2, Smile2, Tapped2, Dalmation };
            Image RandomImage = ImageArray[random.Next(0, ImageArray.Length)];
            if (RandomImage == StBernard)
            {
                StBernard.Visibility = Visibility.Visible;
                Globalclass.energy = 0;
                var dialog = new MessageDialog("Ooh the St Bernard chased you out! Hard Luck" + "\n" +
                                                "Check your friend count to see have you made any pals!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
            else if (RandomImage == imgSleep)
            {
                imgSleep.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Sheep)
            {
                Sheep.Visibility = Visibility.Visible;
                txtbCenter.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Smile)
            {
                Smile.Visibility = Visibility.Visible;
                txtbCenter2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == SleepSmile)
            {
                SleepSmile.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Tapped)
            {
                RightTappedLeft.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Sheep2)
            {
                RightSheep2.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Smile2)
            {
                RightSmile2.Visibility = Visibility.Visible;
                txtbLeft2.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Tapped2)
            {
                RightTapped2.Visibility = Visibility.Visible;
                txtbLeft.Text = "You got a new friend for the herd!! " + "\n";
                Globalclass.friends = Globalclass.friends + 1;
                txtbFriends.Text = Globalclass.friends.ToString();
            }
            else if (RandomImage == Dalmation)
            {
                Dalmation.Visibility = Visibility.Visible;
                Globalclass.energy = 0;
                var dialog = new MessageDialog("Ooh the Dalmation chased you out! Hard Luck" + "\n" +
                                                "Check your friend count to see have you made any pals!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(MainPage));
            }
        }

        //Starting the timer when the page has loaded
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcher();
        }

         
        
        }
}

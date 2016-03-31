using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using System;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WorldOfWool
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Displays Sheep emotion
            txtbHappiness.Text = Globalclass.happiness.ToString();
            //begins story board for imgsheep blinking
            sbSheep.Begin();

     //Energy and Happiness are globally available to allow saving of scores across pages
            //Play button is only enabled when energy is 20
            if (Globalclass.energy <= 20)
            {
                btnPlay.Opacity = 0;
                btnPlay.IsEnabled = false;
            }

            if (Globalclass.happiness == 0)
            {
                sbSheep.Stop(); //stop storyboard with the bored sheep
                sbSleep.Begin(); //begin the storyboard with the smiling sheep
            }

            if (Globalclass.happiness == 2)
            {
                sbSleep.Stop(); //stop storyboard with the bored sheep
                sbSheep.Begin(); //begin the storyboard with the smiling sheep
            }

            if (Globalclass.happiness >= 20)
            {
                sbSheep.Stop(); //stop storyboard with the bored sheep
                sbSmile.Begin(); //begin the storyboard with the smiling sheep
                // FeedMe button is visible
                btnFeedMe.Opacity = 100;
                btnFeedMe.IsEnabled = true;
            }

        }

        private void btnFeedMe_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Play));
        }

        private void btnPlay_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private async void btnLove_click(object sender, RoutedEventArgs e)
        {
            if (Globalclass.happiness == 1)
            {
                var dialog = new MessageDialog("Hey, I'm asleep!! Please wake me up!" + "\n" +
                                               "Press the ~Gimmie Love~ button to wake me up!" + "\n" +
                           "Trick is though; you have to keep pressing it to get my happiness to 20 first, Im not very happy without my daily dose of affection!!" + "\n" +
                           "When I'm happy enough, go to the field to feed me so I have enough energy to play with you!" + "\n" +
                           "If you've given me Energy make sure to press the Energy button to Ensure I have the energy to play, this activates the play button." + "\n" +
                           "Now that's the pleasentaries finished, go give me affection..and also, I'm hungry!");
                await dialog.ShowAsync();
            }
            //when happiness is less than 1000, increases as you click
            if (Globalclass.happiness < 1000)
            {
                Globalclass.happiness++; //increments
                txtbHappiness.Text = Globalclass.happiness.ToString(); //displays textbox
                if (Globalclass.happiness == 0)
                {
                    sbSheep.Stop(); //stop storyboard with the bored sheep
                    sbSleep.Begin(); //begin the storyboard with the smiling sheep
                }
                if (Globalclass.happiness == 2)
                {
                    sbSleep.Stop(); //stop storyboard with the bored sheep
                    sbSheep.Begin(); //begin the storyboard with the smiling sheep
                }
                if (Globalclass.happiness >= 20)
                    {
                        sbSheep.Stop(); //stop storyboard with the bored sheep
                        sbSmile.Begin(); //begin the storyboard with the smiling sheep
                       // FeedMe button is visible
                        btnFeedMe.Opacity = 100;
                        btnFeedMe.IsEnabled = true;
                }
            }
            else
            {
                Globalclass.happiness--; //stop after 1000
            }
        }
       

        private void imgSheep1_Tapped(object sender, TappedRoutedEventArgs e)
        {
           //sbTapped.Begin();
        }

        private void FriendsCount_Click(object sender, RoutedEventArgs e)
        {
            //display the text
            txtbFriends.Text = "You now have " + Globalclass.friends.ToString();
        }

        private void btnEnergy_Click(object sender, RoutedEventArgs e)
        {
            //display the text
            txtbEnergy.Text = "You now have " + Globalclass.energy.ToString();
            //If Energy is 20, Play button becomes visible
            if (Globalclass.energy >= 20)
            {
                btnPlay.Opacity = 100;
                btnPlay.IsEnabled = true;
            }
        }
   
         //Camera functionality
        private async void btnScreenshot_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Want to add your picture to the wall? It might brighten the place up!");
            await dialog.ShowAsync();
            //new instance of the CameraCapture User Interface
            CameraCaptureUI captureUI = new CameraCaptureUI();
        //Using settings to change format to JPEG
        captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
        //Using settings to allow the user to be able to crop captured photo
        captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
        StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

        if (photo == null)
        {
            // User cancelled photo capture
            return;
        }

            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

            //Convert to the correct format
            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Premultiplied);

            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);
            //Binds photo to an Image control to display on screen
            imageControl.Source = bitmapSource;
        }
    }
}
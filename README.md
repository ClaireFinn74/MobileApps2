# MobileApps2
# World Of Wool, a "Tamagotchi-style" app created using Microsoft Visual Studio 2015 and Blend

##Overview

This is a universal windows 10 app which implements the following:

1. Storyboards

2. Global Variables

3. Localization Settings

4. Camera functionality

5. Attempt at reading from a JSON file

6. Dispatch Timer

7. Navigation between pages

8. Async/Await message dialogue boxes

9. Random Arrays

##Summary of what the app does
1. This app allows the user to click a button in order to give the "Tamagotchi-style" Sheep "Happiness" (an int that increments all the way to 1000)

2. Once you get the Sheep to +20 "Happiness" you will unlock the "To the Field to feed me" button which navigates you to a page where there is a dispatch timer running and a storyboard playing. The storyboard is basically grass falling which gives the sheep enough energy (+20, basically an int that adds 20 everytime you go to that page) to unlock the "Play button". When this timer runs out a dialogue box appears and you're brought back to the main page and you must press the "Energy" button to check the sheeps "Energy levels" to unlock the "Play" button.

3. When you press the "Play button there is a sheep and 3 buttons; "Left", "Right and "Centre". The sheep can be moved left, right and centre by pressing these buttons! The buttons are storyboards I made using Microsoft Expression Blend. When you press a button (left, right or centre) a sheep appears which adds to your "Friend Count". Sometimes though, a sheep dog apppears and chases you out of the "Field" (brings you back to the main page). To do this I used a random array filled with sheep and dog images for each button so you don't know how many "Friends" you'll make before a dog chases you out! You can then check your "Friends Count" by pressing a button on the Main Page. If you press the Happiness button afer playing the game you will see that it has incremented by 10 with every "Friend" made.

4. The "Energy", "Happiness" and "Friends" Buttons have Global variables within them to allow me to add happiness once you've played the game or take away energy when you've played the game, to add friends to the "Friends" count once you've made them in the game and to be able to generally save the data across the pages.

5. I added a Camera functionality which uses your camera on your device and awaits the user to take a picture using async/await. The photo can then be cropped and saved to the Main Page. The user can also press "Cancel" to get out of the camera without taking a picture.

6. I added a Text File written in JSON in order to read in this data by converting it to a string first. Unfortunately, this didn't fully work so I disabled the button associated with it.

#References

##Code
https://msdn.microsoft.com/windows/uwp/audio-video-camera/capture-photos-and-video-with-cameracaptureui Camera functionality

https://msdn.microsoft.com/en-us/windows.ui.xaml.dispatchertimer.tick Dispatch Timer

https://msdn.microsoft.com/en-us/default.aspx General help

##Images
http://previews.123rf.com/images/chudtsankov/chudtsankov1401/chudtsankov140100041/25203634-Cute-Black-Head-Sheep-Cartoon-Mascot-Character-Illustration-Isolated-on-white-Stock-Vector.jpg

http://us.123rf.com/450wm/kekoka/kekoka1411/kekoka141100011/34037828-illustrations-of-dog-face.jpg?ver=6

http://www.pd4pic.com/images/animals-head-home-face-cartoon-dog-mammals-pets.png

https://image.spreadshirtmedia.com/image-server/v1/compositions/111436316/views/1,width=235,height=235,appearanceId=1,backgroundColor=f9f9f9,version=1443074494/Cute-Boxer-Dog-Face.jpg



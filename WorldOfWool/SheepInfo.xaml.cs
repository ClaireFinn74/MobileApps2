using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class SheepInfo : Page
    {

        // create list
        List<Sheep> _mySheep;


        public SheepInfo()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // get the global string
            App myapp = (Application.Current) as App;
            tblTitle.Text = myapp.ToString();

            // if the list is already full, exit
            if (_mySheep != null)
                return;

            // new instance of the list
            _mySheep = new List<Sheep>();

            // fill the list.
            loadLocalData();
            // binds the list to the listview
            lvSheep.ItemsSource = _mySheep;
        }

        private async void loadLocalData()
        {
            // get the JSON text file
            var sheepFile = await
                Package.Current.InstalledLocation.GetFileAsync("Data\\TextSheep.txt");

            // read the contents as a string
            var fileContent = await FileIO.ReadTextAsync(sheepFile);

            // convert contents to a json array
            var sheepJson = JsonArray.Parse(fileContent);

            // convert contents to objects of type Sheep
            createListOfSheep(sheepJson);
        }

        private void createListOfSheep(JsonArray sheepJson)
        {
            foreach (var item in sheepJson)
            {
                // get the object
                var obj = item.GetObject();
                // create new sheep object to map to
                Sheep sheep = new Sheep();

                // get each key value pair and sort it to the 
                // appropriate elements of the class
                foreach (var key in obj.Keys)
                {
                    IJsonValue value;
                    if (!obj.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "name":
                            sheep.name = value.GetString();
                            break;
                        case "origin":
                            sheep.origin = value.GetString();
                            break;
                        case "purpose":
                            sheep.purpose = value.GetString();
                            break;
                        case "alternateName":
                            sheep.alternateName = value.GetString();
                            break;
                    } // end switch
                } // end foreach

                _mySheep.Add(sheep);

            } // end foreach
        }

        }
    }

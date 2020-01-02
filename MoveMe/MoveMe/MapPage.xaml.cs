using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MoveMe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
            Task.Delay(2000);
        
            UpdateMap(36.9628066, -122.0194722);
		}

        public MapPage(string cityName)
        {
            InitializeComponent();
            Task.Delay(2000);

            UpdateMap(cityName);
        }

        private void UpdateMap(double lon, double lat)
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(lon, lat), Distance.FromKilometers(100)));
        }

        private async void UpdateMap(string citiName)
        {
            Geocoder geocoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geocoder.GetPositionsForAddressAsync(citiName + " Romania");
            Position position = approximateLocations.FirstOrDefault();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromKilometers(100)));
        }

        
       
    }
}
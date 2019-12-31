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
        
            UpdateMap();
		}

        private void UpdateMap()
        {
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.9628066, -122.0194722), Distance.FromKilometers(100)));
        }
    }
}
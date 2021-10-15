using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;


using PM02IP_EXAMEN.Views;


using System.ComponentModel;
using Xamarin.Essentials;
using System.Diagnostics;

namespace PM02IP_EXAMEN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
         

        }


        protected async override void OnAppearing()
        {

          
            var location = await Geolocation.GetLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLastKnownLocationAsync();
            }

            Maps.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1)));

            var localizacion = CrossGeolocator.Current;
            if (localizacion != null)
            {
                localizacion.PositionChanged += Locatilazion_PositionChanged;

                if (!localizacion.IsListening)
                {
                    Debug.WriteLine("StarListeningAsync");
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100);

                }

                var posicion = await localizacion.GetPositionAsync();
                var mapac = new Position(posicion.Latitude, posicion.Longitude);

                Maps.MoveToRegion(MapSpan.FromCenterAndRadius(mapac, Distance.FromMiles(1)));

            }

            else
            {
                await localizacion.GetLastKnownLocationAsync();
                var posicion = await localizacion.GetPositionAsync();
                var mapac = new Position(posicion.Latitude, posicion.Longitude);


                Maps.MoveToRegion(new MapSpan(mapac, 2, 2));

            }
        }



        private void Locatilazion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var mapac = new Position(e.Position.Latitude, e.Position.Longitude);
            Maps.MoveToRegion(new MapSpan(mapac, 2, 2));

        }




     





    }
}
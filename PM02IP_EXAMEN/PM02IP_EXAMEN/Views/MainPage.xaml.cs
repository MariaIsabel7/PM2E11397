using Plugin.Geolocator;
using PM02IP_EXAMEN.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM02IP_EXAMEN
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            Ubicacion();

            
        }


        private async void Ubicacion()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al cargar el plugin", "OK");
                return;
            }

          

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

            await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 1), 0.5);

        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {

                return;
            }
            var position = CrossGeolocator.Current.GetPositionAsync();

            txtlatitud.Text = position.Result.Latitude.ToString();
            txtlongitud.Text = position.Result.Longitude.ToString();



        }

        private async Task validarFormulario()
        {
            //Valida si el valor en el Entry se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(txtlatitud.Text)|| String.IsNullOrWhiteSpace(txtlongitud.Text) || String.IsNullOrWhiteSpace(txtdescripcion.Text) || String.IsNullOrWhiteSpace(txtdescripcorta.Text))
            {
                await this.DisplayAlert("Advertencia", "Todos los campos son obligatorios", "OK");
               
            }
            
            }

            private async void toolbar01_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new  MainPage());
        }

        private async void toolbar02_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesPage());
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)

        {
            if (validarFormulario().IsCompleted)
            {
                try
                {
                    var ubicacion = new Models.Localizacion
                    {
                        latitud = this.txtlatitud.Text,
                        longitud = this.txtlongitud.Text,
                        descripcionLarga = this.txtdescripcion.Text,
                        descripcionCorta = this.txtdescripcorta.Text

                    };

                    ClearScreen();

                    var resultado = await App.DataBaseSQLite.GuardarUbicacion(ubicacion);

                    if (resultado == 1)
                    {
                        await DisplayAlert("Salvado", "Guardado Exitosamente", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo guardar la ubicacion", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message.ToString(), "Ok");
                }
            }
        }

        private void ClearScreen()
        {
            this.txtlatitud.Text = String.Empty;
            this.txtlongitud.Text = String.Empty;
            this.txtdescripcion.Text = String.Empty;
            this.txtdescripcorta.Text = String.Empty;

        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicacionesPage());
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02IP_EXAMEN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionesPage : ContentPage
    {
     

        public UbicacionesPage()
        {
            InitializeComponent();
            BindingContext = new Models.Localizacion();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listaubicaciones = await App.DataBaseSQLite.ObtenerListaUbicaciones();
            lstUbicaciones.ItemsSource = listaubicaciones;
        }
        private void lstUbicaciones_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Localizacion item = (Models.Localizacion)e.Item;


            /*var page = new View.PersonasPageResult();
            page.BindingContext = item;
            await Navigation.PushAsync(page);*/
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            

            var ubicacion = lstUbicaciones.SelectedItem as Models.Localizacion;
            if (ubicacion != null)
            {
               
                bool answer = await DisplayAlert("Alerta", "¿Desea Eliminar el registro "+ubicacion.codigo+" ? Esto puede generar conflictos", "Yes", "No");
                Debug.WriteLine("Answer: " + answer);
                if (answer == true)
                {
                    await App.DataBaseSQLite.EliminarUbicacion(ubicacion);
                    await Navigation.PushAsync(new UbicacionesPage());
                }

            }
            else
            {
                await DisplayAlert("Alerta", "Seleccione un registro", "Ok");
            }
        }

       

        private void Button_Clicked(object sender, EventArgs e)
        {
            

        }
    }
}
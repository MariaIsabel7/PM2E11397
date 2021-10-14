using System;
using System.Collections.Generic;
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
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listaubicaciones = await App.DataBaseSQLite.ObtenerListaUbicaciones();
            lstUbicaciones.ItemsSource = listaubicaciones;
        }
        private void lstUbicaciones_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }

        private void btneliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
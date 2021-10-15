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
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            var ubicacion = new Models.Localizacion
            {
                
                latitud = this.txtlatitud.Text,
                longitud = this.txtlongitud.Text,
                descripcionLarga = this.txtdescripcion.Text,
                descripcionCorta = this.txtdescripcorta.Text

            };

            ClearScreen();

            if (await App.DataBaseSQLite.GuardarUbicacion(ubicacion) != 0)
                await DisplayAlert("Actualizado", "Dato actualizado", "ok");
            else
                await DisplayAlert("Error", "No se logró actualizar", "ok");

        }

        private void ClearScreen()
        {
            this.txtlatitud.Text = String.Empty;
            this.txtlongitud.Text = String.Empty;
            this.txtdescripcion.Text = String.Empty;
            this.txtdescripcorta.Text = String.Empty;

        }
    }
}
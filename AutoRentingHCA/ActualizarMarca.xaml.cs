using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarMarca : ContentPage
    {
        public const string Url = "http://192.168.1.11/proyecto/marcas.php?IDMARCAS={0}&NOMBREMARCA={1}&ESTADOMARCA={2}";

        public ActualizarMarca(int IDMARCAS, string NOMBREMARCA, int ESTADOMARCA)
        {
            InitializeComponent();

            txtIdMarca.Text = IDMARCAS.ToString();
            txtNombreMarca.Text = NOMBREMARCA.ToString();
            txtMarca.SelectedItem = ESTADOMARCA.ToString();

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            try
            {
                using (var webClient = new WebClient())
                {
                    var uri = new Uri(string.Format(Url,
                    txtIdMarca.Text, txtNombreMarca.Text, txtMarca.SelectedItem));
                    webClient.UploadString(uri, "PUT", string.Empty);

                    await DisplayAlert("Success", "Registro actualizado", "Cerrar");
                    await Navigation.PushAsync(new AdministrarMarcas());
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdministrarRentas : ContentPage
    {

        private const string Url = "http://192.168.1.11/proyecto/renta.php";

        private const string UrlCedula = "http://192.168.1.11/proyecto/buscarrenta.php?CEDULA={0}";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Renta> _post;
        public AdministrarRentas(string usuario, int numeroMenu, int tipoUsuario, string cedula)
        {
            InitializeComponent();
            Get();

        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtCedula.Text))
            {
                string Cedula = txtCedula.Text;
                try
                {
                    var uri = new Uri(string.Format(UrlCedula, Cedula));
                    var content = await client.GetStringAsync(uri);

                    if (content != "false")
                    {

                        List<Renta> post =
                        JsonConvert.DeserializeObject<List<Renta>>(content);
                        _post = new ObservableCollection<Renta>(post);
                        lstRentas.ItemsSource = post;
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Usuario o contraseña incorrectos.", "Cerrar");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Ingrese una cédula", "Cerrar");
            }
        }

        private void lstRentas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Renta> post =
                    JsonConvert.DeserializeObject<List<Renta>>(content);
                _post = new ObservableCollection<Renta>(post);
                lstRentas.ItemsSource = post;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
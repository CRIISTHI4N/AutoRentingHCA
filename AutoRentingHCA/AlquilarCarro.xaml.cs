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
    public partial class AlquilarCarro : ContentPage
    {
        //192.168.70.180
        // 192.168.1.11
        private const string Url = "http://192.168.1.11/proyecto/autos.php";

        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Autos> _post;
        public int IDAUTOS = -1;
        public int IDMARCAS, ESTADOAUTO;
        public string NOMBREAUTO, TIPOAUTO, MODELOAUTO, PLACAAUTO, COLORAUTO, foto;
        public double PRECIOAUTO;

        private void lstAutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Autos)e.SelectedItem;
            IDAUTOS = obj.IDAUTOS;
            IDMARCAS = obj.IDMARCAS;
            NOMBREAUTO = obj.NOMBREAUTO;
            TIPOAUTO = obj.TIPOAUTO;
            MODELOAUTO = obj.MODELOAUTO;
            PLACAAUTO = obj.PLACAAUTO;
            PRECIOAUTO = obj.PRECIOAUTO;
            COLORAUTO = obj.COLORAUTO;
            foto = obj.foto;
            ESTADOAUTO = obj.ESTADOAUTO;
        }

        private async void btnAlquilar_Clicked(object sender, EventArgs e)
        {
            if (IDAUTOS > 0)
            {
                await Navigation.PushAsync(new VisualizarAlquilacion(IDAUTOS, IDMARCAS, NOMBREAUTO, TIPOAUTO, MODELOAUTO, PLACAAUTO, PRECIOAUTO, COLORAUTO, foto, ESTADOAUTO, lblCedulaUser.Text));
            }
            else
            {
                await DisplayAlert("Alerta", "Selecciona un Vehículo", "Cerrar");
            }
        }

        public AlquilarCarro(string cedula)
        {
            InitializeComponent();
            Get();
            lblCedulaUser.Text = cedula;
        }

        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Autos> post =
                    JsonConvert.DeserializeObject<List<Autos>>(content);
                _post = new ObservableCollection<Autos>(post);
                lstAutos.ItemsSource = post;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
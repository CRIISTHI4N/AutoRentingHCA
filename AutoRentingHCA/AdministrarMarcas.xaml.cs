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
    public partial class AdministrarMarcas : ContentPage
    {

        private const string Url = "http://192.168.70.180/proyecto/marcas.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Marcas> _post;

        public int IDMARCAS = -1;
        public int ESTADOMARCA = -1;
        public string NOMBREMARCA;
        public DateTime FECHAREGISTROMAR;

        public AdministrarMarcas()
        {
            InitializeComponent();
            Get();
        }

        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Marcas> post =
                    JsonConvert.DeserializeObject<List<Marcas>>(content);
                _post = new ObservableCollection<Marcas>(post);
                lstMarcas.ItemsSource = post;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void lstMarcas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Marcas)e.SelectedItem;
            IDMARCAS = obj.IDMARCAS;
            NOMBREMARCA = obj.NOMBREMARCA;
            ESTADOMARCA = obj.ESTADOMARCA;
            FECHAREGISTROMAR = obj.FECHAREGISTROMAR;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresarMarca());
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}

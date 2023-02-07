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

        private const string Url = "http://192.168.1.11/proyecto/marcas.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Marcas> _post;

        public int IDMARCAS = -1;
        public int ESTADOMARCA;
        public string NOMBREMARCA;

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
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresarMarca());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (IDMARCAS > 0)
            {
                await Navigation.PushAsync(new ActualizarMarca(IDMARCAS, NOMBREMARCA, ESTADOMARCA));
            }
            else
            {
                await DisplayAlert("Alerta", "No se ha seleccionado un registro", "OK");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (IDMARCAS > 0)
            {
                string Uri = "http://192.168.1.11/proyecto/marcas.php?IDMARCAS={0}";

                try
                {
                    var action = await DisplayActionSheet("¿Estas seguro de eliminar este registro?", null, "Sí", "No");

                    if (action == "Sí")
                    {

                        HttpClient client = new HttpClient();
                        var uri = new Uri(string.Format(Uri, IDMARCAS.ToString()));
                        var result = await client.DeleteAsync(uri);
                        if (result.IsSuccessStatusCode)
                        {
                            Get();
                            await DisplayAlert("Eliminado", 
                                "Registro eliminado \n \n" 
                                + "NOTA: Si el registro esta siendo utilizado en otra tabla AUTO se eliminará", 
                                "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "Error consulte con el administrador", "OK");
                        }
                    }
                    else if (action == "No")
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Alerta", "Ocurrio un Error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "No se ha seleccionado un registro", "OK");
            }
        }
    }
}

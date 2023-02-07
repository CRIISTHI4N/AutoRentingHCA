using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresarMarca : ContentPage
    {

        private const string Url = "http://192.168.1.11/proyecto/marcas.php";
        private readonly HttpClient client = new HttpClient();
        public IngresarMarca()

        {
            InitializeComponent();
            txtMarca.SelectedIndex= 0;
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var uri = new Uri(string.Format(Url));
            var content = await client.GetStringAsync(uri);

            if (content != "false")
            {
                List<Marcas> post = JsonConvert.DeserializeObject<List<Marcas>>(content);
                if (!String.IsNullOrEmpty(txtNombreMarca.Text))
                {

                    for (int i = 0; i < post.Count; i++)
                    {
                        if (post[i].NOMBREMARCA.Equals(txtNombreMarca.Text))
                        {
                            await DisplayAlert("Alerta", "Marca registrada, Intente con otra", "Cerrar");
                            return;
                        }
                    }


                    WebClient client = new WebClient();

                    try
                    {
                        var parameters = new System.Collections.Specialized.NameValueCollection();
                        parameters.Add("IDMARCAS", txtIdMarca.Text);
                        parameters.Add("NOMBREMARCA", txtNombreMarca.Text);
                        parameters.Add("ESTADOMARCA", txtMarca.SelectedItem.ToString());

                        client.UploadValues(Url, "POST", parameters);
                        await DisplayAlert("Registro", "Marca ingresada con éxito", "Cerrar");
                        await Navigation.PushAsync(new AdministrarMarcas());


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        await DisplayAlert("Error", "Se produjo un error, Intente mas tarde", "Cerrar");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Ingrese una marca", "Cerrar");
                }

            }
            else
            {
                await DisplayAlert("Alerta", "Error en el sistema, intente mas tarde", "Cerrar");
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarAuto : ContentPage
	{

        public const string Url = "http://192.168.1.11/proyecto/marcasautos.php?IDAUTOS={0}&IDMARCAS={1}&NOMBREAUTO={2}&TIPOAUTO={3}&MODELOAUTO={4}&PLACAAUTO={5}&PRECIOAUTO={6}&COLORAUTO={7}&foto={8}&ESTADOAUTO={9}";

        private const string Urlmarcas = "http://192.168.1.11/proyecto/marcasautos.php";
        private readonly HttpClient client2 = new HttpClient();
        public ActualizarAuto (int IDAUTOS, int IDMARCAS, string NOMBREAUTO, string TIPOAUTO, string MODELOAUTO, string PLACAAUTO, double PRECIOAUTO, string COLORAUTO, string foto, int ESTADOAUTO)
		{
			InitializeComponent ();

            txtIdAuto.Text = IDAUTOS.ToString();

            txtIdMarcaVeri.Text = IDMARCAS.ToString();
            txtNombreAuto.Text = NOMBREAUTO.ToString();
            txtTipo.Text = TIPOAUTO.ToString();
            txtModelo.Text = MODELOAUTO.ToString();
            txtPlaca.Text = PLACAAUTO.ToString();
            txtPrecio.Text = PRECIOAUTO.ToString();
            txtColor.Text = COLORAUTO.ToString();
            txtFoto.Text = foto.ToString();
            txtMarca.SelectedItem = ESTADOAUTO.ToString();

            Get();

            
        }

        public async void Get()
        {
            try
            {
                var content = await client2.GetStringAsync(Urlmarcas);
                List<Marcas> post = JsonConvert.DeserializeObject<List<Marcas>>(content);

                for (int i = 0; i < post.Count; i++)
                {
                    int id = post[i].IDMARCAS;
                    string nombremarca = post[i].NOMBREMARCA;
                    txtIdMarca.Items.Add(nombremarca);

                    if (post[i].NOMBREMARCA.Equals(txtNombreAuto.Text))
                    {
                        txtIdMarca.SelectedItem = nombremarca.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {

            var content = await client2.GetStringAsync(Urlmarcas);
            List<Marcas> post = JsonConvert.DeserializeObject<List<Marcas>>(content);

            for (int i = 0; i < post.Count; i++)
            {
                int id = post[i].IDMARCAS;
                string marca = post[i].NOMBREMARCA;

                if (post[i].NOMBREMARCA.Equals(txtIdMarca.SelectedItem))
                {
                    txtIdMarcaVeri.Text = id.ToString();
                    txtNombreAuto.Text = marca;
                }
            }


            WebClient client = new WebClient();
            try
            {
                using (var webClient = new WebClient())
                {
                    var uri = new Uri(string.Format(Url,
                    txtIdAuto.Text, txtIdMarcaVeri.Text, txtNombreAuto.Text,
                    txtTipo.Text, txtModelo.Text, txtPlaca.Text, txtPrecio.Text,
                    txtColor.Text, txtFoto.Text, txtMarca.SelectedItem));

                    webClient.UploadString(uri, "PUT", string.Empty);

                    await DisplayAlert("Success", "Registro actualizado", "Cerrar");
                    await Navigation.PushAsync(new AdministrarAutos());
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}
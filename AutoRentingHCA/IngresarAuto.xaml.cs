using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class IngresarAuto : ContentPage
    {
        private const string Url = "http://192.168.1.11/proyecto/marcasautos.php";
        private readonly HttpClient client2 = new HttpClient();
        public IngresarAuto()
        {
            InitializeComponent();
            txtMarca.SelectedIndex = 0;
            Get();
        }

        public async void Get()
        {
            try
            {
                var content = await client2.GetStringAsync(Url);
                List<Marcas> post = JsonConvert.DeserializeObject<List<Marcas>>(content);

                for (int i = 0; i < post.Count; i++)
                {
                    int id = post[i].IDMARCAS;
                    string nombremarca = post[i].NOMBREMARCA;

                    txtIdMarca.Items.Add(nombremarca);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {

            if (txtIdMarca.SelectedIndex != -1)
            {

                if (!String.IsNullOrEmpty(txtTipo.Text))
                {
                    if (!String.IsNullOrEmpty(txtModelo.Text))
                    {
                        if (!String.IsNullOrEmpty(txtPlaca.Text))
                        {
                            if (!String.IsNullOrEmpty(txtPrecio.Text))
                            {
                                if (!String.IsNullOrEmpty(txtColor.Text))
                                {
                                    WebClient client = new WebClient();
                                    try
                                    {
                                        var content = await client2.GetStringAsync(Url);
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

                                        var parameters = new System.Collections.Specialized.NameValueCollection();
                                        parameters.Add("IDAUTOS", txtIdAuto.Text);
                                        parameters.Add("IDMARCAS", txtIdMarcaVeri.Text);
                                        parameters.Add("NOMBREAUTO", txtNombreAuto.Text);
                                        parameters.Add("TIPOAUTO", txtTipo.Text);
                                        parameters.Add("MODELOAUTO", txtModelo.Text);
                                        parameters.Add("PLACAAUTO", txtPlaca.Text);
                                        parameters.Add("PRECIOAUTO", txtPrecio.Text);
                                        parameters.Add("COLORAUTO", txtColor.Text);
                                        parameters.Add("foto", txtFoto.Text);
                                        parameters.Add("ESTADOAUTO", txtMarca.SelectedItem.ToString());

                                        client.UploadValues(Url, "POST", parameters);
                                        await DisplayAlert("Registro", "Auto registrado con éxito", "Cerrar");
                                        await Navigation.PushAsync(new AdministrarAutos());
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                        await DisplayAlert("Error", "Se produjo un error, Intente mas tarde", "Cerrar");
                                    }
                                }
                                else
                                {
                                    await DisplayAlert("Alerta", "Debe ingresar el color del vehículo", "Cerrar");
                                }
                            }
                            else
                            {
                                await DisplayAlert("Alerta", "Debe ingresar el precio de renta", "Cerrar");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Debe ingresar la placa del vehículo", "Cerrar");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Debe ingresar el modelo de vehículo", "Cerrar");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Debe ingresar el tipo de vehículo", "Cerrar");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Seleccione una marca de vehículo", "Cerrar");
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class VisualizarAlquilacion : ContentPage
    {
        //192.168.70.180
        //192.168.1.11
        private const string Url = "http://192.168.1.11/proyecto/renta.php";
        private const string UrlUp = "http://192.168.1.11/proyecto/renta.php?IDAUTOS={0}&ESTADOAUTO={1}";

        public VisualizarAlquilacion(int IDAUTOS, int IDMARCAS, string NOMBREAUTO, string TIPOAUTO, string MODELOAUTO, string PLACAAUTO, double PRECIOAUTO, string COLORAUTO, string foto, int ESTADOAUTO, string cedula)
        {
            InitializeComponent();
            lblID.Text = IDAUTOS.ToString();

            int idMarca = IDMARCAS;
            string idM = idMarca.ToString();
            lblIdMarca.Text = idM;

            lblNombreAuto.Text = NOMBREAUTO;
            lblTipo.Text = TIPOAUTO;
            lblModelo.Text = MODELOAUTO;
            lblPlaca.Text = PLACAAUTO;
            lblPrecio.Text = PRECIOAUTO.ToString();
            lblColor.Text = COLORAUTO;
            imgAuto.Source = foto;
            lblEstado.Text = ESTADOAUTO.ToString();

            cedu.Text = cedula;

            etFecha.Format = "yyyy/MM/dd";
        }

        private async void btnAlquilarAuto_Clicked(object sender, EventArgs e)
        {

            DateTime fechaSistema = DateTime.Now;
            string fFormat = fechaSistema.ToString("yyyy/MM/dd");

            if (!String.IsNullOrEmpty(etDias.Text))
            {
                    if (!String.IsNullOrEmpty(etDireccion.Text))
                    {
                        if (!String.IsNullOrEmpty(etTelf.Text))
                        {
                        string telf = etTelf.Text;
                        bool isValidtele = Regex.IsMatch(telf, @"^\d{10}$");
                        if (isValidtele)
                        {
                            var action = await DisplayActionSheet("¿Estas seguro de tus datos?", null, "Sí", "No");

                            if (action == "Sí")
                            {

                                int dias = Convert.ToInt32(etDias.Text);
                                double precio = Convert.ToDouble(lblPrecio.Text);
                                double totalPagar = dias * precio;

                                lblTotalPagar.Text = totalPagar.ToString(); // agregar el signo de dolar
                                //lblTotalPagar.IsVisible = true;
                                //lblPagar.IsVisible = true;
                                btnAlquilarAuto.IsVisible = false;
                                etDias.IsReadOnly = true;
                                etDireccion.IsReadOnly = true;
                                etTelf.IsReadOnly = true;

                                WebClient client = new WebClient();
                                try
                                {
                                    var parameters = new System.Collections.Specialized.NameValueCollection();
                                    parameters.Add("IDRENTA", entrIdRenta.Text);
                                    parameters.Add("IDAUTOS", lblID.Text);
                                    parameters.Add("CEDULA", cedu.Text);
                                    parameters.Add("telefono", etTelf.Text);
                                    parameters.Add("FECHAREGISTRORENTA", fFormat); // fecha del sistema
                                    parameters.Add("FECHARESERVARENTA", etFecha.Date.ToString("yyyy/MM/dd")); 
                                    parameters.Add("DIASRENTA", etDias.Text);
                                    parameters.Add("DIRECCIONRENTA", etDireccion.Text);
                                    parameters.Add("TOTALRENTA", lblTotalPagar.Text);

                                    client.UploadValues(Url, "POST", parameters);

                                    using (var webClient = new WebClient())
                                    {
                                        var uri = new Uri(string.Format(UrlUp, lblID.Text, lblEstadoAuto.Text));
                                        webClient.UploadString(uri, "PUT", string.Empty);
                                    }

                                    await DisplayAlert("Alquiler con éxito",
                                        "Por favor, Espere a que uno de nuestros ascesores se comunique con usted. \n"
                                        + "\n"
                                        + "Días: " + etDias.Text + "\n"
                                        + "Fecha de entrega: " + etFecha.Date.ToString("yyyy/MM/dd") + "\n"
                                        + "Dirección: " + etDireccion.Text + "\n"
                                        + "Teléfono: " + etTelf.Text + "\n"
                                        + "\n"
                                        + "Total a pagar: $" + lblTotalPagar.Text,
                                        "Gracias");

                                    await Navigation.PushAsync(new AlquilarCarro(cedu.Text));

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    await DisplayAlert("Error", "Se produjo un error comuniquese con" +
                                        " el Administrador", "Cerrar");
                                }
                            }
                            else if (action == "No")
                            {
                                return;
                            }
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Su telefono debe tener 10 digitos  ", "Cerrar");
                        }
                        

                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Debe ingresar su teléfono", "Cerrar");
                        }
                        
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Debe ingresar la dirección de entrega", "Cerrar");
                    }
            }
            else
            {
                await DisplayAlert("Alerta", "Debe ingresar los días de alquiler", "Cerrar");
            }
        }
    }
}
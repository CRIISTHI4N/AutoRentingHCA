using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        // 192.168.1.11
        private const string Url = "http://192.168.70.180/proyecto/usuario.php?USUARIOCLIENTE={0}&CLAVECLIENTE_={1}";
        private readonly HttpClient client = new HttpClient();       

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUser.Text))
            {
                if (!String.IsNullOrEmpty(txtPass.Text))
                {
                    string Usuario = txtUser.Text;
                    string Pass = txtPass.Text;
                    try
                    {
                        var uri = new Uri(string.Format(Url, Usuario, Pass)); /*EncodePassword(tPass)*/
                        var content = await client.GetStringAsync(uri);

                        if (content != "false")
                        //if(tUsuario == "a" && tPass == "a")
                        {
                            Datos post = JsonConvert.DeserializeObject<Datos>(content);
                            int tipoUsuario = post.PERFILCLIENTE;
                            string cedula = post.CEDULA;
                            await Navigation.PushAsync(new MainPage(Usuario, tipoUsuario, tipoUsuario, cedula)); /*tipoUsuario*/
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
                    await DisplayAlert("Alerta", "Debe ingresar su Contraseña", "Cerrar");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Debe ingresar su Usuario", "Cerrar");
            }
        }

        private async void btnCrear_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/"));
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.google.com/"));
        }

        private async void btnRecuperar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecuperarPassword());
        }
    }
}
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
    public partial class RegistroUsuario : ContentPage
    {
        //192.168.1.11      
        private const string Url = "http://192.168.70.180/proyecto/usuario.php";
        public RegistroUsuario()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnCrear_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCedula.Text))
            {
                if (!String.IsNullOrEmpty(txtUsuario.Text))
                {
                    if (!String.IsNullOrEmpty(txtContra.Text))
                    {
                        var action = await DisplayActionSheet("¿Estas seguro de tus datos?", null, "Sí", "No");

                        if (action == "Sí")
                        {
                            WebClient client = new WebClient();

                            try
                            {
                                var parameters = new System.Collections.Specialized.NameValueCollection();
                                parameters.Add("CEDULA", txtCedula.Text);
                                parameters.Add("NOMBRE", txtNombre.Text);
                                parameters.Add("APELLIDO", txtApellido.Text);
                                parameters.Add("EMAIL", txtEmail.Text);
                                parameters.Add("TELEFONO", txtTelf.Text);
                                parameters.Add("USUARIOCLIENTE", txtUsuario.Text);
                                parameters.Add("CLAVECLIENTE_", txtContra.Text);
                                parameters.Add("FOTOLICENCIA_", txtLicencia.Text);
                                parameters.Add("PERFILCLIENTE", txtPerfil.Text);

                                client.UploadValues(Url, "POST", parameters);
                                await DisplayAlert("Registro", "Usuario registrado con exito", "OK");
                                await Navigation.PushAsync(new Login());

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                await DisplayAlert("Error", "Se produjo un error, Intente mas tarde", "Cerrar");
                            }
                        }
                        else if (action == "No")
                        {
                            return;
                        }


                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Debe ingresar su contraseña", "Cerrar");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Debe ingresar su usuario", "Cerrar");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Debe ingresar su cedula", "Cerrar");
            }
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
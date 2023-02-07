using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuHamburguesa : ContentPage
    {



        public MenuHamburguesa(string usuario, int numeroMenu, int tipoUsuario,
            string cedula, string nombre, string apellido, string email, string telefono, string clave, string tipolicencia)
        {
            InitializeComponent();
            lblUser.Text = usuario;
            int tipoUser = tipoUsuario;
            string tU = tipoUser.ToString();
            lblTipoUser.Text = tU;
            lblCedula.Text = cedula;

            entNombre.Text = nombre.ToString();
            entApellido.Text = apellido.ToString();
            entEmail.Text = email.ToString();
            entTelf.Text = telefono.ToString();
            entClave.Text = clave.ToString();
            entTipoLicencia.Text = tipolicencia.ToString();

            NavigationPage.SetHasNavigationBar(this, false);


            if (tipoUsuario == 3)
            {
                userInterface.IsVisible = false;
                adminInterface.IsVisible = true;
            }
            else if (tipoUsuario == 1)
            {
                userInterface.IsVisible = true;
                adminInterface.IsVisible = false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 1, tipoUser, 
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 2, tipoUser, 
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void btnAdministrarMarcas_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 3, tipoUser, 
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }

        private async void btnAdministrarAutos_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 4, tipoUser, 
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }

        private async void btnContratarChofer_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 5, tipoUser, 
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }

        private async void btnAdministrarRentas_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 6, tipoUser, 
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }

        private async void btnMisDatos_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;

            string entNombred = entNombre.Text;
            string entApellidod = entApellido.Text;
            string entEmaild = entEmail.Text;
            string entTelfd = entTelf.Text;
            string entClaved = entClave.Text;
            string entTipoLicenceciad = entTipoLicencia.Text;

            await Navigation.PushAsync(new MainPage(usuario, 7, tipoUser,
                cedula, entNombred, entApellidod, entEmaild, entTelfd, entClaved, entTipoLicenceciad));
        }
    }
}
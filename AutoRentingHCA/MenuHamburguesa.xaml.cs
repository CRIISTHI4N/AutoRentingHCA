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
        public MenuHamburguesa(string usuario, int numeroMenu, int tipoUsuario, string cedula)
        {
            InitializeComponent();
            lblUser.Text = usuario;
            int tipoUser = tipoUsuario;
            string tU = tipoUser.ToString();
            lblTipoUser.Text = tU;
            lblCedula.Text = cedula;

            NavigationPage.SetHasNavigationBar(this, false);


            if (tipoUsuario == 3)
            {
                userInterface.IsVisible= false;
                adminInterface.IsVisible= true;
            } else if(tipoUsuario == 1)
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
            await Navigation.PushAsync(new MainPage(usuario, 1, tipoUser, cedula));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;
            await Navigation.PushAsync(new MainPage(usuario, 2, tipoUser, cedula));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async  void btnAdministrarMarcas_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;
            await Navigation.PushAsync(new MainPage(usuario, 3, tipoUser, cedula));
        }

        private async void btnAdministrarAutos_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;
            await Navigation.PushAsync(new MainPage(usuario, 4, tipoUser, cedula));
        }

        private async void btnContratarChofer_Clicked(object sender, EventArgs e)
        {
            string usuario = lblUser.Text;
            int tipoUser = Convert.ToInt32(lblTipoUser.Text);
            string cedula = lblCedula.Text;
            await Navigation.PushAsync(new MainPage(usuario, 5, tipoUser, cedula));
        }
    }
}
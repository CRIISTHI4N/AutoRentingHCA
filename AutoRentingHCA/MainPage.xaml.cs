using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AutoRentingHCA
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(string usuario, int numeroMenu, int tipoUsuario, string cedula)
        {
            InitializeComponent();

            if (numeroMenu == 1) //Inicio
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 1, tipoUsuario, cedula);
                this.Detail = new NavigationPage(new Home());
                App.menu = this;
            }
            else if (numeroMenu == 2) //alquilar vehiculo
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 2, tipoUsuario, cedula);
                this.Detail = new NavigationPage(new AlquilarCarro(cedula));
                App.menu = this;
            } else if (numeroMenu == 3) //administrar marcas
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 3, tipoUsuario, cedula);
                this.Detail = new NavigationPage(new AdministrarMarcas());
                App.menu = this;
            } else if (numeroMenu == 4) //administrar autos
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 4, tipoUsuario, cedula);
                this.Detail = new NavigationPage(new AdministrarAutos());
                App.menu = this;
            }
        }
    }
}

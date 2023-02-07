using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AutoRentingHCA
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(string usuario, int numeroMenu, int tipoUsuario, 
            string cedula, string nombre, string apellido, string email, string telefono, string clave, string tipolicencia)
        {
            InitializeComponent();

            if (numeroMenu == 1) //Inicio
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 1, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new Home(usuario));
                App.menu = this;
            }
            else if (numeroMenu == 2) //alquilar vehiculo
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 2, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new AlquilarCarro(cedula));
                App.menu = this;
            } else if (numeroMenu == 3) //administrar marcas
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 3, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new AdministrarMarcas());
                App.menu = this;
            } else if (numeroMenu == 4) //administrar autos
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 4, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new AdministrarAutos());
                App.menu = this;
            } else if (numeroMenu == 5) //servicios (choferes)
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 5, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new Servicios(usuario, 5, tipoUsuario, cedula));
                App.menu = this;
            } else if (numeroMenu == 6) // administrar rentas
            {
                NavigationPage.SetHasNavigationBar(this, false); 
                this.Master = new MenuHamburguesa(usuario, 6, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new AdministrarRentas(usuario, 6, tipoUsuario, cedula));
                App.menu = this;
            } else if (numeroMenu == 7) // datos usuario
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Master = new MenuHamburguesa(usuario, 7, tipoUsuario, cedula, nombre, apellido, email, telefono, clave, tipolicencia);
                this.Detail = new NavigationPage(new MisDatos(usuario, 7, tipoUsuario, 
                    cedula, nombre, apellido, email, telefono, clave, tipolicencia));
                App.menu = this;
            }
        }
    }
}

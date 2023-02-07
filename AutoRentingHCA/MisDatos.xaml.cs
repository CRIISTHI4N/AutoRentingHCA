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
	public partial class MisDatos : ContentPage
	{
		public MisDatos (string usuario, int numeroMenu, int tipoUsuario, 
			string cedula, string nombre, string apellido, string email, string telefono, string clave, string tipolicencia)
		{
			InitializeComponent ();

            entCedula.Text = cedula.ToString();
            entNombre.Text = nombre.ToString();
            entApellido.Text = apellido.ToString();
            entEmail.Text = email.ToString();
            entTelf.Text = telefono.ToString();
            entUsuario.Text = usuario.ToString();
            entClave.Text = clave.ToString();
            entTipoLicencia.Text = tipolicencia.ToString();
        }
	}
}
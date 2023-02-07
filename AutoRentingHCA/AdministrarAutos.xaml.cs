using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdministrarAutos : ContentPage
    {

        private const string Url = "http://192.168.1.11/proyecto/autosadmin.php";
        private const string E0 = "http://192.168.1.11/proyecto/filtro.php";
        private const string E1 = "http://192.168.1.11/proyecto/filtro2.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Autos> _post;

        public int IDAUTOS = -1;
        public int IDMARCAS, ESTADOAUTO;
        public string NOMBREAUTO, TIPOAUTO, MODELOAUTO, PLACAAUTO, COLORAUTO, foto;
        public double PRECIOAUTO;

        private void btnEstado1_Clicked(object sender, EventArgs e)
        {
            Estado1();
        }

        private void btnEstado0_Clicked(object sender, EventArgs e)
        {
            Estado0();
        }

        private void btnTodos_Clicked(object sender, EventArgs e)
        {
            Get();
        }

        public AdministrarAutos()
        {
            InitializeComponent();
            Get();
        }

        public async void Estado1()
        {
            try
            {
                var content = await client.GetStringAsync(E1);
                List<Autos> post =
                    JsonConvert.DeserializeObject<List<Autos>>(content);
                _post = new ObservableCollection<Autos>(post);
                lstAutos.ItemsSource = post;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public async void Estado0()
        {
            try
            {
                var content = await client.GetStringAsync(E0);
                List<Autos> post =
                    JsonConvert.DeserializeObject<List<Autos>>(content);
                _post = new ObservableCollection<Autos>(post);
                lstAutos.ItemsSource = post;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public async void Get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Autos> post =
                    JsonConvert.DeserializeObject<List<Autos>>(content);
                _post = new ObservableCollection<Autos>(post);
                lstAutos.ItemsSource = post;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void lstAutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Autos)e.SelectedItem;
            IDAUTOS = obj.IDAUTOS;
            IDMARCAS = obj.IDMARCAS;
            NOMBREAUTO = obj.NOMBREAUTO;
            TIPOAUTO = obj.TIPOAUTO;
            MODELOAUTO = obj.MODELOAUTO;
            PLACAAUTO = obj.PLACAAUTO;
            PRECIOAUTO = obj.PRECIOAUTO;
            COLORAUTO = obj.COLORAUTO;
            foto = obj.foto;
            ESTADOAUTO = obj.ESTADOAUTO;
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresarAuto());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (IDAUTOS > 0)
            {
                await Navigation.PushAsync(new ActualizarAuto(IDAUTOS, IDMARCAS, NOMBREAUTO, TIPOAUTO, MODELOAUTO, PLACAAUTO, PRECIOAUTO, COLORAUTO, foto, ESTADOAUTO));
            }
            else
            {
                await DisplayAlert("Alerta", "No se ha seleccionado un registro", "OK");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (IDAUTOS > 0)
            {
                string Uri = "http://192.168.1.11/proyecto/marcasautos.php?IDAUTOS={0}";

                try
                {
                    var action = await DisplayActionSheet("¿Estas seguro de eliminar este registro?", null, "Sí", "No");

                    if (action == "Sí")
                    {

                        HttpClient client = new HttpClient();
                        var uri = new Uri(string.Format(Uri, IDAUTOS.ToString()));
                        var result = await client.DeleteAsync(uri);
                        if (result.IsSuccessStatusCode)
                        {
                            Get();
                            await DisplayAlert("Eliminado",
                                "Registro eliminado \n \n"
                                + "NOTA: Si el registro esta siendo utilizado en la tabla RENTA no se eliminará",
                                "OK");
                        }
                        else
                        {
                            await DisplayAlert("Error", "Error consulte con el administrador", "OK");
                        }
                    }
                    else if (action == "No")
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Alerta", "Ocurrio un Error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "No se ha seleccionado un registro", "OK");
            }
        }
    }
}
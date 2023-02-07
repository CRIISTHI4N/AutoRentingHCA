using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoRentingHCA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        ObservableCollection<FileImageSource> fileImages =
            new ObservableCollection<FileImageSource>();
        public Home(string usuario)
        {
            InitializeComponent();

            lblWellcome.Text= "Bienvenido " + usuario;

            List<Image> images = new List<Image>()
            {
                new Image(){Title="Image 1",Url="fordraptor.jpg"},
                new Image(){Title="Image 2",Url="nissanrenaultlogan.png"},
                new Image(){Title="Image 3",Url="nissanversa.jpg"}
            };

            Carousel.ItemsSource = images;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                Carousel.Position = (Carousel.Position+1) % images.Count;
                return true;
            }));
        }
    }
}
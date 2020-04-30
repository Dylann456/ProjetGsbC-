using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Antibio.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProjetGsb
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //DataAntibio.initialiser();
            initialisation();
            //lstCategories.ItemsSource = DataAntibio.getLesCategories().ToList();
            //NombreAntibio.Text = DataAntibio.getNbAntibioParKilo().ToString();
        }
        private async void initialisation()
        {
            HttpClient wc = new HttpClient();
            var reponse = await wc.GetStringAsync("https://apigsb15789.000webhostapp.com/api/getAllCategories.php");
            List<Categorie> lesCategories = JsonConvert.DeserializeObject<List<Categorie>>(reponse);
            lstCategories.ItemsSource = lesCategories;
        }
       
        private async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (lstCategories.SelectedItem != null)
            {

              await Navigation.PushAsync(new PageProduits((lstCategories.SelectedItem as Categorie).id));
            }

        }
    }
}

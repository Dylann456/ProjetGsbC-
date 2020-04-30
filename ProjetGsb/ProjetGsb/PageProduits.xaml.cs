using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using Antibio.Models;

namespace ProjetGsb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageProduits : ContentPage
    {
        int numCateg;
        public PageProduits(int idCateg) // on passe en paramètre un objet de type catégorie
        {
            InitializeComponent();
            numCateg = idCateg;
            recuperationAntibiotiques();
            
        }
        private async void recuperationAntibiotiques()
        {
            HttpClient wc = new HttpClient();
            var reponse = await wc.GetStringAsync("https://apigsb15789.000webhostapp.com/api/getAllAntibioPCategories.php?idCateg=" + numCateg);
            List<Antibio.Models.Antibio> lesAntibiotiques = JsonConvert.DeserializeObject<List<Antibio.Models.Antibio>>(reponse);
            listeAntibiotique.ItemsSource = lesAntibiotiques;
        }
        
        private async void listeAntibiotique_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string DescriptionAntibio = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).nomAntibio; // on regarde par rapport à la liste des antibiotiques sélectionnés si ils font partie de la classe antibio et si c'est le cas on récupère le libelle
            await DisplayAlert("Antibio selectionné : ", " Vous avez choisi " + DescriptionAntibio, "OK"); // message d'alerte pour indiquer quel est le type de produits sélectionnés.
        }


        private void Button_Recherche_Clicked(object sender, EventArgs e)
        {
            if (listeAntibiotique.SelectedItem !=null) // on regarde si dans la liste des antibiotiques sélectionnés figurent des Antibios de type AntibioParKilo
            {
                
                if (Zone_Recherche.Text == null) // si la zone de saisie est nulle on informe l'utilisateur qu'il doit saisir le poid du patient
                {
                   string AntibioUn = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).unite;

                   float AntibioParPriseSelectionne = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).dose_prise;

                    int AntibioN = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).nombre_par_jour;
                    DisplayAlert(" Prescription ", "il  vous faut : " + AntibioParPriseSelectionne + AntibioUn + " " + AntibioN + " fois par jour", "OK");
                }

                else
                {
                    string AntibioU = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).unite; // on declare et on affecte à la variable l'accesseurs get.Unite

                    float saisieU = Convert.ToInt32(Zone_Recherche.Text); // on affecte à la variable saisieU une conversion de la zone de texte qui était une caractère en un nombre entier quelconque

                    float AntibioParKiloSelectionne = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).dose_kilo; // on recupère l'accesseur getDoseKilo
                    int AntibioPnombre = (listeAntibiotique.SelectedItem as Antibio.Models.Antibio).nombre_par_jour;//on recupère l'accesseur getNombre qui renvoie le nbParJour
                    saisieU = saisieU * AntibioParKiloSelectionne; // calcul avec la variable saisieU

                    DisplayAlert(" Prescription ", "il  vous faut : " + saisieU + " " + AntibioU + " " + AntibioPnombre + " fois par jour", "OK");
                    // On alerte l'utilisateur de la prescription par rapport à la donnée saisie

                }
            }
            //    if (listeAntibiotique.SelectedItem is AntibioParPrise)
            //    {
            //        if (Zone_Recherche.Text == null)
            //        {
            //            string AntibioUn = (listeAntibiotique.SelectedItem as AntibioParPrise).getUnite();

            //            float AntibioParPriseSelectionne = (listeAntibiotique.SelectedItem as AntibioParPrise).getDosePrise();

            //            int AntibioN = (listeAntibiotique.SelectedItem as AntibioParPrise).getNombre();

            //            DisplayAlert(" Prescription ", "il  vous faut : " + AntibioParPriseSelectionne + AntibioUn + " " + AntibioN + " fois par jour", "OK");
            //        }
            //    }
            //}


        }
    }
}

                    //await Navigation.PushAsync(new PageProduits(e.SelectedItem.ToString()));
    

        //private async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if(e.SelectedItem == null)
        //    {
        //        return;
        //    }
        //    string lblAntibio = e.SelectedItem.ToString();
        //    Models.Antibio a = DataAntibio.rechAntibio(libAntibio);
        //    if(a is AntibioParPrise)
        //    {
        //        //DisplayAlert("Votre posologie" , "Nombre par jour" , "OK") ;
        //    }
        //    else
        //    {
        //       // await Navigation.PushAsync(new PageProduits(e.SelectedItem.ToString()));
        //    }
        //}
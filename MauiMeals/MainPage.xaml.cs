using MauiMeals.Services;
using MauiMeals.Models;
using Microsoft.Maui.Controls;



namespace MauiMeals
{
    public partial class MainPage : ContentPage
    {
            public List<string> MealNames { get; set; }

            public MainPage()
            {
                InitializeComponent();
                MealNames = new List<string>();
                BindingContext = this;
            }

            protected override async void OnAppearing()
            {
                base.OnAppearing();
            //Ceci permet qu'a chaque fois, le user ouvre cette page, une liste de repas par defaut s'affiche. Car il prend comme parametre une chaine vide.
                await LoadMealNames("");
            }

            private async Task LoadMealNames(string userData)
            {
                // Récupérer les noms de repas depuis notre source de données
                MealNames = await GetMealNames(userData);

                // Rafraîchir la ListView pour afficher les nouveaux noms de repas
                mealListView.ItemsSource = MealNames;
            }

        private async Task<List<string>> GetMealNames(string userData)
        {
            List<string> mealNames = new List<string>();

            try
            {
                var result = await ApiService.GetMeal(userData);

                for (int i = 0; i < result.meals.Count; i++)
                {
                    var meal = result.meals[i];
                    mealNames.Add(meal.strMeal);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Unable to retrieve meal data: " + ex.Message, "OK");
            }

            return mealNames;
        }

        private async void MealListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Vérifiez si un élément est sélectionné
            if (e.SelectedItem == null)
                return;

            string selectedMeal = e.SelectedItem.ToString();

       
            ((ListView)sender).SelectedItem = null;

            // Naviguez vers la page de détails en passant le nom du repas comme paramètre
            await Navigation.PushAsync(new DetailsPage(selectedMeal));
        }

        //Cette boite de dialogue va permettre a l'user de chercher son repas en ecrivant un nom comme :chicken, fish,etc... 
        // Le user doit entre un seul nom, car le programme prend une seule chaine comme parametre 
        private async void BarClicked(object sender, EventArgs e)
            {
                var userData = await DisplayPromptAsync(title: "Meal Search", message: "Which meal are you looking for?", placeholder: "Enter a keyword",
                                                         accept: "Search", cancel: "Cancel");

                if (userData != null)
                {
                     
                    lblUserData.Text = $"Below is a list of {userData} meals";
                    await LoadMealNames(userData);
                }
         
        
        }
    }
    

}

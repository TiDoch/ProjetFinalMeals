using MauiMeals.Models;
using MauiMeals.Services;

namespace MauiMeals;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(string mealName)
    {
        InitializeComponent();
        LoadMealDetails(mealName);
    }

    private async Task LoadMealDetails(string mealName)
    {
        try
        {
            // Récupérer les détails du repas à partir de son nom
            Meal mealDetails = await GetMealDetails(mealName);

            // Utiliser les détails du repas pour afficher les informations dans l'interface utilisateur
            lblMealName.Text = mealDetails.strMeal;
            lblArea.Text = mealDetails.strArea;
            lblCategory.Text = mealDetails.strCategory;
            

            HttpClient httpClient = new HttpClient();
            byte[] imageData = await httpClient.GetByteArrayAsync(mealDetails.strMealThumb);

            ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageData));

           
            mealImage.Source = imageSource;

           
            youtubeWebView.Source = new UrlWebViewSource { Url = mealDetails.strYoutube };


           
            lblIngredient1.Text = mealDetails.strIngredient1;
            lblIngredient2.Text = mealDetails.strIngredient2;
            lblIngredient3.Text = mealDetails.strIngredient3;
            lblIngredient4.Text = mealDetails.strIngredient4;
            lblIngredient5.Text = mealDetails.strIngredient5;
            lblIngredient6.Text = mealDetails.strIngredient6;
            lblIngredient7.Text = mealDetails.strIngredient7;
            lblIngredient8.Text = mealDetails.strIngredient8;
            lblIngredient9.Text = mealDetails.strIngredient9;
            lblIngredient10.Text = mealDetails.strIngredient10;
            lblIngredient11.Text = mealDetails.strIngredient11;
            lblIngredient12.Text = mealDetails.strIngredient12;
            lblIngredient13.Text = mealDetails.strIngredient13;
            lblIngredient14.Text = mealDetails.strIngredient14;
            lblIngredient15.Text = mealDetails.strIngredient15;

            lblMeasure1.Text = mealDetails.strMeasure1;
            lblMeasure2.Text = mealDetails.strMeasure2;
            lblMeasure3.Text = mealDetails.strMeasure3;
            lblMeasure4.Text = mealDetails.strMeasure4;
            lblMeasure5.Text = mealDetails.strMeasure5;
            lblMeasure6.Text = mealDetails.strMeasure6;
            lblMeasure7.Text = mealDetails.strMeasure7;
            lblMeasure8.Text = mealDetails.strMeasure8;
            lblMeasure9.Text = mealDetails.strMeasure9;
            lblMeasure10.Text = mealDetails.strMeasure10;
            lblMeasure11.Text = mealDetails.strMeasure11;
            lblMeasure12.Text = mealDetails.strMeasure12;
            lblMeasure13.Text = mealDetails.strMeasure13;
            lblMeasure14.Text = mealDetails.strMeasure14;
            lblMeasure15.Text = mealDetails.strMeasure15;

        }
        catch (Exception ex)
        {
            // Gérer les erreurs de récupération des détails du repas 
            await DisplayAlert("Error", "Unable to retrieve meal details: " + ex.Message, "OK");
        }
    }

    private async Task<Meal> GetMealDetails(string mealName)
    {
        try
        {
            // Appeler l' API dans Services pour récupérer les détails du repas à partir de son nom
            var result = await ApiService.GetMeal(mealName);

            // Vérifier si les détails du repas sont disponibles dans la réponse
            if (result != null && result.meals != null && result.meals.Count > 0)
            {
                // Récupérer les détails du premier repas de la réponse
                var mealDetails = result.meals[0];

                // Retourner les détails du repas
                return mealDetails;
            }
            else
            {
                // Si aucun détail de repas n'est disponible dans la réponse, afficher un message d'erreur
                await DisplayAlert("Error", "No meal details found for " + mealName, "OK");
                return null;
            }
        }
        catch (Exception ex)
        {
            // Gérer les erreurs de récupération des détails du repas
            await DisplayAlert("Error", "Unable to retrieve meal details: " + ex.Message, "OK");
            return null; // En cas d'erreur, retournez null ou une valeur par défaut
        }

    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Retourne à la page précédente
    }





}
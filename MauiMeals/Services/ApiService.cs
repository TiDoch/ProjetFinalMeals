using MauiMeals.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMeals.Services
{
    public class ApiService
    {
        public static async Task<MealsModel> GetMeal(string repas)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://themealdb.com/api/json/v1/1/search.php?s={0}", repas));
            return JsonConvert.DeserializeObject<MealsModel>(response);
        }
    }
}

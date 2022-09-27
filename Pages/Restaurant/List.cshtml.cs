using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeTofood.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        public string Message { get; set; }
        //bind property // suppoertGet
        [BindProperty(SupportsGet =true)] 
        public string SearchTerm { get; set; }
        public IEnumerable<OdeToFood.Core.Restaurant> Restaurants { get; set; }
        public ListModel(IConfiguration conig, IRestaurantData restaurantData)
        {
            _config = conig;
            _restaurantData = restaurantData;
        }

        public void OnGet()
        {

            Message = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}

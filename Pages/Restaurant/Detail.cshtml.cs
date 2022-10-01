using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;

namespace OdeTofood.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        public OdeToFood.Core.Restaurant Restaurant { get; set; }
        private readonly IRestaurantData _restaurantData;
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }
    }
}

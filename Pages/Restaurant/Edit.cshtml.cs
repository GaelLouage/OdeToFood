using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;

namespace OdeTofood.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        [BindProperty]
        public OdeToFood.Core.Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurant, IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _restaurantData = restaurant;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<OdeToFood.Core.CuisineType>();
            if (restaurantId != 0)
            {
                Restaurant = _restaurantData.GetRestaurantById(restaurantId);
                if (Restaurant is null)
                {
                    return RedirectToPage("NotFound!");
                }
            }
            else
            {
                Restaurant = new OdeToFood.Core.Restaurant();

            }

            return Page();
        }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<OdeToFood.Core.CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                Restaurant = _restaurantData.UpdateRestaurant(Restaurant);
             
            } else
            {
                _restaurantData.AddRestaurant(Restaurant);
            }
            _restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("Detail", new { restaurantId = Restaurant.Id });
        }
    }
}

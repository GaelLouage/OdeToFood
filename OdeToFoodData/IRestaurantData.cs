using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        int Commit();
        Restaurant AddRestaurant(Restaurant newRestaurant);
    }

    public class InMermoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMermoryRestaurantData()
        {
            restaurants = new List<Restaurant>
                {
                    new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "MaryLand", Cuisine = CuisineType.Italian},
                     new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "London", Cuisine = CuisineType.None},
                      new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican}
                };
        }

     

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurants.SingleOrDefault(x => x.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant =  restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;

            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }
    }
}

﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
            new Restaurant {Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian},
            new Restaurant {Id = 2, Name = "Mamma Mia's Pizza", Location="New York", Cuisine=CuisineType.Italian},
            new Restaurant {Id = 3, Name = "Grand Biriyani", Location="New Jersey", Cuisine=CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;

        }
    }
}

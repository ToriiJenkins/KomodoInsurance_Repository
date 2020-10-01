using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repository
{

    //C# Object
    public class MenuItem
    {
        public int Meal_Number { get; set; }
        public string Meal_Name { get; set; }

        public string Description { get; set; }

        public List<string> IngredientsList = new List<string>();

        public double Price { get; set; }

        public MenuItem() { }

        public MenuItem(int number, string name, string description, List<string> ingredients, double price)
        {
            Meal_Number = number;
            Meal_Name = name;
            Description = description;
            IngredientsList = ingredients;
            Price = price;
        }

    }
}

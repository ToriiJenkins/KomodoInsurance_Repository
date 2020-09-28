using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repository
{
    public enum DrinkType
    {
        DrPepper = 1,
        Coke,
        Lemonaide,
        Water
    }

    public enum EntreType
    {
        Sandwich = 10,
        Wrap,
        Salad,
        Soup
    }

    public enum SideType
    {
        SideSalad = 20,
        SideSoup,
        Fries,
        Fruit
    }

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

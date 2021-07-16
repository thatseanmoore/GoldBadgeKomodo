using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public enum MealNumber
    {
        One = 1,
        Two = 2,
        Three = 3, 
        Four = 4, 
        Five = 5,
    }

    public class MenuContent
    {
        public MealNumber MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealPrice { get; set; }
        public string MealIngredients { get; set; }
        public MenuContent() { }

        public MenuContent(MealNumber mealNumber, string mealName, string mealDescription, string mealIngredients, string mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            MealIngredients = mealIngredients;

        }
    }
}

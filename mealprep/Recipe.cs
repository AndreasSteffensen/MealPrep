using System.Text;

namespace MealPrep
{
    public class Recipe
    {

        private string path = "C:\\Users\\steff\\Desktop\\Projekter\\MealPrep\\mealprep\\data\\Recipes.txt";

        public int RecipeId { get; set; }
        public string Name { get; set; }

        public ICollection<Meal> Meals { get; set; }


        public Recipe(string name)
        {
            Name = name;
        }

        /*
        public List<Recipe> readList()
        {
            // not implemented
        }
        */
        //TODO: add function that handles saving a recipe to a text file and with ingredients and all.

    }
}

namespace MealPrep
{
    public class Recipe
    {
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set;}

        public Recipe(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }



        //TODO: add function that handles saving a recipe to a text file and with ingredients and all.

    }
}

namespace MealPrep
{
    public class Recipe
    {
        public string Name { get; set; }

        public List<Ingredient> Ingredients { get; set;}

        public Recipe(string name)
        {
            Name = name;
        }

        //TODO: add function that handles saving a recipe to a text file and with ingredients and all.

    }

    public class Ingredient
    { 
        public string Name { get; set; }
        public float Quantity { get; set; }

        public Ingredient(string name, float quantity) 
        {
            Name = name;
            Quantity = quantity;
        }
    }
}

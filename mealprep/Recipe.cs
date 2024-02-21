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

        public bool testfunc (int var)
        { 
            if (var > 5)
                return false;
            else
            {
                return true;
            }
        }
        //TODO: add function that handles saving a recipe to a text file and with ingredients and all.

    }
}

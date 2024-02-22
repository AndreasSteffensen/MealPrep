using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealPrep
{
    public class Ingredient
    {
        //TODO: fix to have a relative path from directory
        private string path = "C:\\Users\\steff\\Desktop\\Projekter\\MealPrep\\mealprep\\data\\Ingredients.txt";
        public string Name;
        public float Quantity = 0f;

        static public List<Ingredient> ingredients = new List<Ingredient>();

        public Ingredient(string name)
        {
            Name = name;
        }

        public Ingredient(string name, float quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public List<Ingredient> readList()
        {
            List<Ingredient> list = new List<Ingredient>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    StringBuilder name = new StringBuilder();
                    int nextCharector;
                    do
                    {
                        nextCharector = reader.Read();
                        if(nextCharector == ',')
                        {
                            list.Add(new Ingredient(name.ToString()));
                            name.Clear();
                        }
                        else
                        {
                            name.Append((char)nextCharector);
                        }
                    }
                    while (nextCharector != -1);
                    return list;
                }
            }
            catch 
            {
                throw new FileNotFoundException();
            }
        }

        public bool listConsist (string name)
        {
            bool isInList = false;
            ingredients = readList();

            if (ingredients == null)
                throw new NullReferenceException();

            foreach (Ingredient item in ingredients)
            {
                if (item.Name == name)
                    isInList = true;
            }
            return isInList;
        }

        public void writeToList(string ingredient)
        {
            if (listConsist(ingredient))
            {
                return;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.Write(ingredient);
                    writer.Write(",");
                    writer.Close();
                }
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }

        // TODO: Implement this if nessecary but don't think it will be
        public void removeFromList(string ingredient) 
        {

        }
    }
}

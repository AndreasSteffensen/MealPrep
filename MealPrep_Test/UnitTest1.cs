using MealPrep;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System.Xml.Linq;

namespace MealPrep_Test
{
    public class Test_ingrdient
    {
        private Ingredient _ingredient { get; set;} = null!;

        [SetUp]
        public void Setup()
        {
            _ingredient = new Ingredient("test");
        }

        [Test]
        public void readList_Test()
        {
            //assign
            List<Ingredient> list = new List<Ingredient>();

            //act
            list = _ingredient.readList();

            //Assert
            Assert.IsInstanceOf(typeof(Ingredient), list[0]);
            Assert.AreEqual("Jordskokker", list[0].Name.ToString());
            Assert.AreEqual("Kartofler", list[1].Name.ToString());
            Assert.AreEqual("Løg", list[2].Name.ToString());
        }
        [Test]
        public void listConsist_Test()
        {
            //assign
            Ingredient ingredient = new Ingredient("Løg");
            Ingredient ingredient2 = new Ingredient("Fuck");

            //act

            //Assert
            Assert.IsTrue(_ingredient.listConsist(ingredient));
            Assert.IsFalse(_ingredient.listConsist(ingredient2));
        }

        [Test]
        public void WriteToList_Test()
        {
            //assign
            Ingredient ingredient = new Ingredient("Agurk");
            //act
            if (_ingredient.listConsist(ingredient))
            {
                // Do nothing it's in the list. Test only works with something not in the list...
            }
            else
            {
                _ingredient.writeToList(ingredient);
            }

            //Assert
            Assert.IsTrue(_ingredient.listConsist(ingredient));


            //Clean up
            //use remove for a cleaner test that work without if statement...
        }

        [Test]
        public void 

        /*
         * unnessecary function RemoveFromList()
        [Test]
        public void RemoveFromList_Test()
        {
            string ingredient = "NotIngredient";

            _ingredient.removeFromList(ingredient);

            Assert.IsFalse(_ingredient.listConsist(ingredient));

        }
        */
    }

    public class Test_Recipe
    {
        private Recipe _recipe = null;
        [SetUp]
        public void Setup()
        {
            _recipe = new Recipe();
        }

        [Test]
        public void readList_Test() 
        {
            //Assign
            List<Recipe> list = new List<Recipe>();
            //Act
            list = _recipe.readList();
            //Assert
            Assert.AreSame("Jordskokkesuppe", list[0].Name);
            Assert.AreEqual("Jordskoker", list[0].Ingredients[0].Name);
            Assert.IsInstanceOf(typeof(float), list[0].Ingredients[0].Quantity);
        }

        [Test]
        public void writeList_Test()
        {
            /*write to list of Recipes
             * in format 
             * Name, Ingredients: 1st,Quantity of 1st; 2nd,Quantity of 2nd .... until no more ingredients final Break and newline
             */

        }
    }
}
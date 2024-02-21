using MealPrep;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System.Xml.Linq;

namespace MealPrep_Test
{
    public class Tests
    {
        private Recipe _recipe { get; set; } = null!;
        private Ingredient _ingredient { get; set;} = null!;

        [SetUp]
        public void Setup()
        {
            _recipe = new Recipe("test");
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
            Assert.AreEqual("Jordskokker", list[0].Name.ToString());
            Assert.AreEqual("Kartoffel", list[1].Name.ToString());
            Assert.AreEqual("Løg", list[2].Name.ToString());
        }
        [Test]
        public void listConsist_Test()
        {
            //assign
            string name1 = "Løg";
            string name2 = "Fuck";

            //act

            //Assert
            Assert.IsTrue(_ingredient.listConsist(name1));
            Assert.IsFalse(_ingredient.listConsist(name2));
        }

        /*
        [Test]
        public void WriteToList_Test()
        {
            //assign
            string ingredient = "Agurk";
            //act
            Assert.IsFalse(_ingredient.listConsist(ingredient));
            _ingredient.writeToList(ingredient);

            //Assert
            Assert.IsTrue(_ingredient.listConsist(ingredient));
        }
        */
    }
}
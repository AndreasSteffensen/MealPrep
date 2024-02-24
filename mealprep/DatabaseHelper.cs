using System.Collections.Generic;
using System.Data.SQLite;
using System.Numerics;
using MealPrep;
using Microsoft.EntityFrameworkCore;

namespace MealPrep
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MealPrep.db");
        }
    }

    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Sources=..\..\MealPrep\mealprep\data\MealPrep.db;Version=3;";

        public static void initializeDatabase()
        {
            if (!File.Exists(@"..\..\MealPrep\mealprep\data\MealPrep.db"))
            {
                SQLiteConnection.CreateFile(@"..\..\MealPrep\mealprep\data\MealPrep.db");

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Create tables for data
                    string createRecipeTableQuery = @"
                        CREATE TABLE IF NOT EXISTS recipe (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL
                            
                        );";

                    string createIngredientTableQuery = @"
                        CREATE TABLE IF NOT EXISTS ingredient (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            name TEXT NOT NULL
                        );";

                    string createMealTableQuery = @"
                        CREATE TABLE IF NOT EXISTS meal (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            recipe_id INT,
                            ingredient_id INT,
                            unit INT,
                            quantity FLOAT
                        );";

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createRecipeTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createIngredientTableQuery;
                        command.ExecuteNonQuery();

                        command.CommandText = createMealTableQuery;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}

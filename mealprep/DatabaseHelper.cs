using System.Collections.Generic;
using System.Data.SQLite;
using System.Numerics;
using MealPrep;
using Microsoft.EntityFrameworkCore;

namespace MealPrep
{
    public class MealPrepDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }

        private static string connectionString = @"Data Source=..\..\MealPrep\mealprep\data\MealPrep.db;Version=3;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<Meal>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.Meals)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<Meal>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.Meals)
                .HasForeignKey(ri => ri.IngredientId);
            
        }
    }

    public static class DatabaseHelper
    {
        // TODO: Fix path so it is more abstrack
        private static string connectionString = @"Data Source=..\..\MealPrep\mealprep\data\MealPrep.db;Version=3;";

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
        public static void addIngredient(Ingredient ingredient) 
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using(SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText =
                        @"INSERT INTO ingredient (name)
                        VALUES (@name);";
                    command.Parameters.AddWithValue("@name", ingredient.Name);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
        }
        /*
        public static void readTable()
        {

            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
            }
        }
        */
    }
}

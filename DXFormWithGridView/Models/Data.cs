using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXFormWithGridView.Models
{
    public static class Data
    {
        public static List<Ingredient> Ingredients { get; set; }
        public static List<Recipe> Recipes { get; set; }

        static Data()
        {
            Ingredients = new List<Ingredient>()
            {
                new Ingredient(){Id = 1, Name = "ingredient1"},
                new Ingredient(){Id = 2, Name = "ingredient2"},
                new Ingredient(){Id = 3, Name = "ingredient3"},
            };

            Recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1, Name = "recipe1",
                    Description = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient() {RecipeId = 1, IngredientId = 1},
                        new RecipeIngredient() {RecipeId = 1, IngredientId = 2},
                    }
                },
                new Recipe()
                {
                    Id = 2, Name = "recipe2",
                    Description = "",
                    RecipeIngredients = new List<RecipeIngredient>()
                    {
                        new RecipeIngredient() {RecipeId = 2, IngredientId = 2},
                        new RecipeIngredient() {RecipeId = 2, IngredientId = 3},
                    }
                }
            };
        }
    }
}
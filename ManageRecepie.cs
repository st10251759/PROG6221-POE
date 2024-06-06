using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ST10251759_PROG6221_POE
{
    public class ManageRecepie
    {
        public List<Recipe> Recipes { get; private set; }

        public ManageRecepie()
        {
            Recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public void DisplayAllRecipes(ListBox recipeListBox)
        {
            recipeListBox.Items.Clear();
            var sortedRecipes = Recipes.OrderBy(r => r.Name).ToList();

            foreach (var recipe in sortedRecipes)
            {
                recipeListBox.Items.Add(recipe.Name);
            }
        }

        public void DisplayRecipeDetails(Recipe recipe, TextBlock recipeDetailsTextBlock)
        {
            recipeDetailsTextBlock.Text = recipe.DisplayRecipe();
        }

        public void ScaleRecipe(Recipe recipe, double factor)
        {
            recipe.ScaleRecipe(factor);
        }

        public void ResetRecipe(Recipe recipe)
        {
            recipe.ResetRecipe();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            if (Recipes.Contains(recipe))
            {
                Recipes.Remove(recipe);
                MessageBox.Show($"Recipe '{recipe.Name}' has been deleted.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Recipe '{recipe.Name}' not found.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
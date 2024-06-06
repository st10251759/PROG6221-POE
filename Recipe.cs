using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251759_PROG6221_POE
{
    public class Recipe
    {
        public string Name { get; set; }
        public int NumIngredients { get; set; }
        public int NumSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            NumIngredients = numIngredients;
            NumSteps = numSteps;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        public void SetIngredients(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public void SetSteps(List<Step> steps)
        {
            Steps = steps;
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.calories;
            }
            return totalCalories;
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetRecipe()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 0;
            }
            Steps.Clear();
        }

        public string DisplayRecipe()
        {
            string recipeDetails = $"Recipe: {Name}\n";
            recipeDetails += "Ingredients:\n";
            foreach (var ingredient in Ingredients)
            {
                recipeDetails += $"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.calories} calories)\n";
            }
            recipeDetails += "Steps:\n";
            for (int i = 0; i < Steps.Count; i++)
            {
                recipeDetails += $"{i + 1}. {Steps[i].Description}\n";
            }
            recipeDetails += $"Total Calories: {CalculateTotalCalories()}\n";
            return recipeDetails;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251759_PROG6221_POE
{
    public delegate void RecipeDelegate(string message);
    public class Recipe
    {
        public string Name { get; set; }
        public int NumIngredients { get; set; }
        public int NumSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        private double totalCalories;
        private StringBuilder calorieMessages;

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            calorieMessages = new StringBuilder();
        }

        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            NumIngredients = numIngredients;
            NumSteps = numSteps;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            calorieMessages = new StringBuilder();
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

        private void DisplayCalorieMessage(string message)
        {
            calorieMessages.AppendLine(message);
        }

        public string DisplayRecipe()
        {
            calorieMessages.Clear();
            RecipeDelegate recipeDelegate = new RecipeDelegate(DisplayCalorieMessage);

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
            //recipeDetails += $"Total Calories: {CalculateTotalCalories()}\n";

            DisplayCalories(recipeDelegate);
            recipeDetails += calorieMessages.ToString();
            return recipeDetails;
        }

        private void DisplayCalories(RecipeDelegate recipeDelegate)
        {

            totalCalories = CalculateTotalCalories();
            recipeDelegate($"Total number of calories in recipe: {totalCalories}");

            if (totalCalories > 300)
            {
                recipeDelegate("CALORIES EXCEED 300");
            }

            if (totalCalories > 0 && totalCalories <= 200)
            {
                recipeDelegate("This amount of calories is enough to satisfy you without interfering with appetite and is a good SNACK");
            }
            else if (totalCalories > 200 && totalCalories <= 400)
            {
                recipeDelegate("This amount of calories serves as a LOW CALORIE MEAL, aiding in weight loss");
            }
            else if (totalCalories > 400 && totalCalories <= 700)
            {
                recipeDelegate("This amount of calories is suitable for an AVERAGE MEAL ");
            }
            else if (totalCalories > 700)
            {
                recipeDelegate("This meal is considered a HIGH CALORIE MEAL, containing a large amount of calories, and should not be consumed frequently");
            }
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

        //public string DisplayRecipe()
        //{
        //    string recipeDetails = $"Recipe: {Name}\n";
        //    recipeDetails += "Ingredients:\n";
        //    foreach (var ingredient in Ingredients)
        //    {
        //        recipeDetails += $"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.calories} calories)\n";
        //    }
        //    recipeDetails += "Steps:\n";
        //    for (int i = 0; i < Steps.Count; i++)
        //    {
        //        recipeDetails += $"{i + 1}. {Steps[i].Description}\n";
        //    }
        //    recipeDetails += $"Total Calories: {CalculateTotalCalories()}\n";
        //    return recipeDetails;
        //}
    }
}

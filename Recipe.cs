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
            recipeDetails += "=============Ingredients:=============\n";
            foreach (var ingredient in Ingredients)
            {
                recipeDetails += $"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.calories} calories)\nFood Group: {ingredient.FoodGroup}\n";
            }
            recipeDetails += "=============Steps:=============\n";
            for (int i = 0; i < Steps.Count; i++)
            {
                recipeDetails += $"Step {i + 1}: {Steps[i].Description}\n";
            }

            recipeDetails += "=======================================\n";

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
                double scaledQuantity = ingredient.Quantity * factor;
                ingredient.CalculateScaledCalories(factor);

                switch (ingredient.Unit)
                {
                    case UnitOfMeasurement.CUP:
                    case UnitOfMeasurement.CUPS:
                        ConvertCups(ingredient, scaledQuantity);
                        break;
                    case UnitOfMeasurement.TABLESPOON:
                    case UnitOfMeasurement.TABLESPOONS:
                        ConvertTablespoons(ingredient, scaledQuantity);
                        break;
                    case UnitOfMeasurement.TEASPOON:
                    case UnitOfMeasurement.TEASPOONS:
                        ConvertTeaspoons(ingredient, scaledQuantity);
                        break;
                    default:
                        ingredient.Quantity = scaledQuantity;
                        break;
                }
            }
        }

        private void ConvertCups(Ingredient ingredient, double newQuantity)
        {
            if (newQuantity < 1)
            {
                double tablespoons = newQuantity * 16;
                ingredient.Quantity = tablespoons;
                ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
            }
            else if (newQuantity == 1)
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.CUP;
            }
            else
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.CUPS;
            }
        }

        private void ConvertTablespoons(Ingredient ingredient, double newQuantity)
        {
            if (newQuantity >= 16)
            {
                if (newQuantity == 16)
                {
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.CUP;
                }
                else
                {
                    double cups = newQuantity / 16;
                    ingredient.Quantity = cups;
                    ingredient.Unit = UnitOfMeasurement.CUPS;
                }
            }
            else if (newQuantity < 1)
            {
                double teaspoons = newQuantity * 3;
                ingredient.Quantity = teaspoons;
                ingredient.Unit = UnitOfMeasurement.TEASPOONS;
            }
            else
            {
                if (newQuantity == 1)
                {
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOON;
                }
                else
                {
                    ingredient.Quantity = newQuantity;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
                }
            }
        }

        private void ConvertTeaspoons(Ingredient ingredient, double newQuantity)
        {
            if (newQuantity >= 3)
            {
                if (newQuantity == 3)
                {
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOON;
                }
                else
                {
                    double tablespoons = newQuantity / 3;
                    ingredient.Quantity = tablespoons;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
                }
            }
            else if (newQuantity <= 1)
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.TEASPOON;
            }
            else
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.TEASPOONS;
            }
        }

        public void ResetRecipe()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
                ingredient.Unit = ingredient.OriginalUnit;
                ingredient.calories = ingredient.originalCalories;
            }

            totalCalories = CalculateTotalCalories();
        }
    }
}
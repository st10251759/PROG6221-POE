using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251759_PROG6221_POE
{//namespace end
    //delegate  for calories
    public delegate void RecipeDelegate(string message);
    public class Recipe
    {//Recipe Class begin
        //variable declaration
        public string Name { get; set; }
        public int NumIngredients { get; set; }
        public int NumSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        private double totalCalories;
        private StringBuilder calorieMessages;

        //constructor
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            calorieMessages = new StringBuilder();
        }

        //construcotr with parameters
        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            NumIngredients = numIngredients;
            NumSteps = numSteps;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            calorieMessages = new StringBuilder();
        }
        //Method to add ingreients to ingredient list instance of ingredient class
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
        //Method to add step to step list instance of step class
        public void AddStep(Step step)
        {
            Steps.Add(step);
        }

        //method to alter the ingreients in ingredient list
        public void SetIngredients(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        //method to alter steps in step list
        public void SetSteps(List<Step> steps)
        {
            Steps = steps;
        }
        //method to calulate the total calories for all ingreidnts in the recipe i.e. total recipe calories
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.calories;
            }
            return totalCalories;
        }

        //method to display calorie message
        private void DisplayCalorieMessage(string message)
        {
            calorieMessages.AppendLine(message);
        }
        //Method to display the recipe details in a neat and structured way
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
        //display calories and delegate if calories exceed 300
        private void DisplayCalories(RecipeDelegate recipeDelegate)
        {

            totalCalories = CalculateTotalCalories();
            recipeDelegate($"Total number of calories in recipe: {totalCalories}");

            //if exceed 300 notify user
            if (totalCalories > 300)
            {
                recipeDelegate("CALORIES EXCEED 300");
            }
            //display inforbased on total calories on nutrional value

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
        //method to scale the recipe
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
        //method to change the unit of cups
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

        //method to change the unit of tablespoons
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

        //method is to change the unit of teaspoons
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

        //method to rest recipe back to its orginal state
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
}//namespace end
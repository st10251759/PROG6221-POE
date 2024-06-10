using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

/*
 Student Number: ST10251759
 Full Name: Cameron Chetty
 Course: PROG6221
 Assessment: POE Part 3
 Github Link for Part 1: https://github.com/VCDN-2024/prog6221-part-1-st10251759
 Github Link for Part 2: https://github.com/st10251759/prog6221-part-2-st10251759
 Github Link for Part 3: https://github.com/st10251759/PROG6221-POE
 */

/*
=============Feedback==================== 
I obtained 100% and reciped no iplemented feedback. All work done was to address the requirements of PART 2 ONLY, and there  NO FEEDBACK to implement for part 1.  
*/

/*
=============Code Attribution====================

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/ErrorHandling_App
Date of Access: 29 May 2024  

Author: GeeksForGeeks
Website: https://www.geeksforgeeks.org/c-sharp-list-class/
Date of Access: 29 May 2024 

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/blob/main/Employee_Demo/Program.cs
Date of Access: 29 May 2024 

Author: GeeksForGeeks 
Website: https://www.geeksforgeeks.org/bubble-sort/
Date of Access: 29 May 2024 
=============Code Attribution====================
*/


namespace ST10251759_PROG6221_POE
{// namespace ST10251759_PROG6221_POE begin
    public class ManageRecepie
    {// ManageRecepie begin
        //declare a generic collection for recipe
        public List<Recipe> Recipes { get; private set; }
        //constructor
        public ManageRecepie()
        {//constructor begin
            //create a new recipe list object
            Recipes = new List<Recipe>();
        }//constructor end

        //constructor with parameter for the recipe class
        public void AddRecipe(Recipe recipe)
        {//constructor with parameters begin
            //Add the recipe to the list
            Recipes.Add(recipe);
        }//constructor with parameters end

        //Method to display the alphabetically sorted recipes
        public void DisplayAllRecipes(ListBox recipeListBox)
        {//DisplayAllRecipes begin
            recipeListBox.Items.Clear(); //clear the list box
            //sort the recipes
            var sortedRecipes = Recipes.OrderBy(r => r.Name).ToList();
            //display the recipes in a list
            //for each to access all 
            foreach (var recipe in sortedRecipes)
            {//foreach begin
                recipeListBox.Items.Add(recipe.Name);
            }//foreach end
        }//DisplayAllRecipes end

        //Method to display Recipe Details in a textblock
        public void DisplayRecipeDetails(Recipe recipe, TextBlock recipeDetailsTextBlock)
        {//DisplayRecipeDetail begin
            recipeDetailsTextBlock.Text = recipe.DisplayRecipe();
        }//DisplayRecipeDetail end

        //method to scale recipe by a factor selected by the user and passed as a parameter
        public void ScaleRecipe(Recipe recipe, double factor)
        {//ScaleRecipe begin
            //call the scaleRecipe method from recipe class
            recipe.ScaleRecipe(factor);
        }//ScaleRecipe end

        //ResetRecipe method to return recipe to its orginal state after being scaled
        public void ResetRecipe(Recipe recipe)
        {//ResetRecipe begin
            recipe.ResetRecipe();
        }//ResetRecipe end

        //Method to delete recupe the user selected by removing recipe from recipe list
        public void DeleteRecipe(Recipe recipe)
        {//DeleteRecipe begin
            if (Recipes.Contains(recipe))
            {//if recipe list contains the recipe user wants to delete begin
                Recipes.Remove(recipe);
                MessageBox.Show($"Recipe '{recipe.Name}' has been deleted.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }//if recipe list contains the recipe user wants to delete end
            else
            {//else if recipe is not in the recipe list begin
                //Disply error message for recipe not found
                MessageBox.Show($"Recipe '{recipe.Name}' not found.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Error);
            }//else if recipe is not in the recipe list end
        }//DeleteRecipe end
    }// ManageRecepie end
}// namespace ST10251759_PROG6221_POE end
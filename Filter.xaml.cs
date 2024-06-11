using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
Author: Microsoft
Website: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0
Date of Access: 09 June 2024

Author: tutorialspoint
Website: https://www.tutorialspoint.com/wpf/index.htm
Date of Access: 09 June 2024     

Author: Stack Overflow
Website: https://stackoverflow.com/questions/2820357/how-do-i-exit-a-wpf-application-programmatically
Date of Access: 09 June 2024  

Lambda Expressions
Author: Microsoft
Website: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
Date of Access: 09 June 2024 

=============Code Attribution====================
*/

namespace ST10251759_PROG6221_POE
{//namespace ST10251759_PROG6221_POE begin
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {//FilterWindow begin

        //Variable Declaration
        private int filter; //variable to hold the value of which catergory to filter by
        private ManageRecepie manageRecipe;
        private List<Recipe> recipes;
        private List<Recipe> filteredRecipes; // New member variable to store filtered recipes
        //List to hold the FoodGroup Values
        private List<FoodGroup> groups = new List<FoodGroup>();

        //constructor with parameter
        public Filter(ManageRecepie manageRecipe)
        {//constructor begin
            InitializeComponent();
            this.manageRecipe = manageRecipe;
            this.recipes = manageRecipe.Recipes;
            PopulateComboBox(); //method to populate food group comnobox with values from the enum
        }//constructor end

        //Method to populate foodgroup combobox with the enum values
        private void PopulateComboBox()
        {//PopulateComboBox begin
            groups = Enum.GetValues(typeof(FoodGroup)).Cast<FoodGroup>().ToList();
            foreach (var group in groups)
            {//foreach begin
                cmbGroup.Items.Add(group.ToString());
            }//foreach end
        }//PopulateComboBox end

        //MainMenuBtn Button click event to return to main menu
        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {//MainMenubtn begin
            //open AllRecipesWindow and close the current window
            var allRecipesWindow = new AllRecipes(manageRecipe);
            allRecipesWindow.Show();
            this.Close();
        }//MainMenubtn end



        //Method to hide thecomponets to get user input for filter options
        private void HideAllFilterOptions()
        {//HideAllFilterOptions begin
            NameTxt.Visibility = Visibility.Hidden;
            cmbGroup.Visibility = Visibility.Hidden;
            CaloriesTxt.Visibility = Visibility.Hidden;
        }//HideAllFilterOptions end

        //Method to take in the ingrient name entered by user as a parameter and search through the recipes
        private void NameFilter(string ingredientName)
        {//Namefilter method begin
            //Using the lambda expression to find if the recipe contains the name of the ingredient user entered display the filtered list of recipes
             filteredRecipes = recipes
        .Where(r => r.Ingredients.Any(i => i.Name.IndexOf(ingredientName, StringComparison.OrdinalIgnoreCase) >= 0))
        .ToList();
            DisplayRecipes(filteredRecipes);
        }//Namefilter method end

        //Method to take in the food group selected by user as a parameter and search through the recipes
        private void GroupFilter(FoodGroup selectedGroup)
        {//GroupFilter begin
         //Using the lambda expression to find if the recipe contains the food group of the ingredient user entered display the filtered list of recipes
             filteredRecipes = recipes
       .Where(r => r.Ingredients.Any(i => i.FoodGroup == selectedGroup))
       .ToList();
            DisplayRecipes(filteredRecipes);
        }//GroupFilter end

        //Method to take in the ingrient name entered by user as a parameter and search through the recipes
        private void CalorieFilter(double maxCalories)
        {//CalorieFilter begin
            //Using the lambda expression to find if the recipe contains the max calories of the ingredient user entered display the filtered list of recipes
             filteredRecipes = recipes
                .Where(r => r.CalculateTotalCalories() <= maxCalories)
                .ToList();
            DisplayRecipes(filteredRecipes);
        }//CalorieFilter end

        //Method to display the filtered reiupe list 
        private void DisplayRecipes(List<Recipe> filteredRecipes)
        {//DisplayRecipes begin

            //Clear listbox
            lbxRecipes.Items.Clear();

            //if statement to validate if there are no recipes found 
            if (filteredRecipes.Count == 0)
            {//if there are no results for filter begin
                lbxRecipes.Items.Add("No recipes found.");
            }//if there are no results for filter end
            else
            {//else if there are no results for filter begin
                foreach (var recipe in filteredRecipes)
                {//for each to display all recipes in the recipe list begin
                    lbxRecipes.Items.Add($"{recipe.Name}\n{recipe.CalculateTotalCalories()} total calories");
                }//for each end
            }//else if there are no results for filter end
        }//DisplayRecipes end

        //Button to view the recipe the user selects
        private void ViewRecipeBtn_Click_1(object sender, RoutedEventArgs e)
        {//ViewRecipeButton begin
            int selectedIndex = lbxRecipes.SelectedIndex;

            // Check if there are any recipes in the ListBox
            if (lbxRecipes.Items.Count == 0 || (lbxRecipes.Items.Count > 0 && lbxRecipes.Items[0].ToString() == "No recipes found."))
            {//if no recipes found begin
                // Display a message if no recipes are found
                MessageBox.Show("No recipes found to view. Please apply a different filter or add recipes.");
                return;
            }//if no recipes found end

            //if statement to valid if the user selected a recipe to view
            if (selectedIndex >= 0)
            {//if begin
                // Get the selected recipe from the filtered list
                var selectedRecipe = filteredRecipes[selectedIndex];

                if (selectedRecipe != null)
                {
                    // Open ViewRecipeWindow and close the current window
                    var viewRecipeWindow = new ViewRecipe(selectedRecipe, manageRecipe);
                    viewRecipeWindow.Show();
                    this.Hide();
                }
                else
                {
                    // Display error message if the recipe is not found in the filtered list
                    MessageBox.Show("Selected recipe not found in the filtered list.");
                }
            }//if end
            else
            {//else begin
                //Display error message
                MessageBox.Show("Please select a recipe to view.");
            }//else end
        }//ViewRecipeButton end

        //Button to display components to get user input for the FoodGroup Filter
        private void FoodGroupFilterBtn_Click_1(object sender, RoutedEventArgs e)
        {//FoodGroupFilterBtn begin
            HideAllFilterOptions();
            cmbGroup.Visibility = Visibility.Visible;
            filter = 2;
        }//FoodGroupFilterBtn begin

        //Button to display components to get user input for the Ingredient Name Filter
        private void NameFilterBtn_Click(object sender, RoutedEventArgs e)
        {//NameFilterBtn begin
            HideAllFilterOptions();
            NameTxt.Visibility = Visibility.Visible;
            filter = 1;
        }//NameFilterBtn begin

        //Button to display components to get user input for the Max Calories of recipe Filter
        private void CaloriesFilterBtn_Click(object sender, RoutedEventArgs e)
        {//CaloriesFilterBtn begin
            HideAllFilterOptions();
            CaloriesTxt.Visibility = Visibility.Visible;
            filter = 3;
        }//CaloriesFilterBtn end

        //Apply filter button to display filtered list of recipes for user to select
        private void ApplyFilterBtn_Click_1(object sender, RoutedEventArgs e)
        {//ApplyFilterBtn begin
            lbxRecipes.Items.Clear();
            //use the filter value in a switch case to decide on what catergory  to filter the recipes
            switch (filter)
            {//switch begin
                case 1:
                    string ingredientName = NameTxt.Text;
                    NameFilter(ingredientName);
                    break;
                case 2:
                    int selectedIndex = cmbGroup.SelectedIndex;
                    if (selectedIndex >= 0)
                    {
                        FoodGroup selectedGroup = groups[selectedIndex];
                        GroupFilter(selectedGroup);
                    }
                    break;
                case 3:
                    if (double.TryParse(CaloriesTxt.Text, out double maxCalories))
                    {
                        CalorieFilter(maxCalories);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for calories.");
                    }
                    break;
                default:
                    MessageBox.Show("Please select a filter criteria.");
                    break;
            }//switch end
        }//ApplyFilterBtn end
    }//FilterWindow end
}//namespace ST10251759_PROG6221_POE end

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

=============Code Attribution====================
*/

namespace ST10251759_PROG6221_POE
{//namespace ST10251759_PROG6221_POE begin
    /// <summary>
    /// Interaction logic for AllRecipes.xaml
    /// </summary>
    public partial class AllRecipes : Window
    {//AllRecipe Window Begin
        //Variable Declaration
        private ManageRecepie manageRecipe;
        private List<Recipe> sortedRecipes;
        private int selection;

        //AllRecipes Class with paramters in contructor
        public AllRecipes(ManageRecepie manageRecipe)
        {//AllRecipes Constructor begin
            InitializeComponent();
            this.manageRecipe = manageRecipe;
            LoadRecipes();
        }//AllRecipes Constructor end

        //Method to Load Recipes and displaying recipes in the list box
        private void LoadRecipes()
        {//LoadRecipes begin
            //Clear the list box
            lbxRecipes.Items.Clear();
            //Store the alphabetically sorted recipes in a variable
            sortedRecipes = manageRecipe.Recipes.OrderBy(r => r.Name).ToList();
            
            //Validation for no recipes added - if sortedRecipes is null
            if (sortedRecipes.Count == 0)
            {//if begin
                //display message in list boxx
                lbxRecipes.Items.Add("No recipes available.");
            }//if end
            else
            {//else if there are recipes stored in sortedrecipes display it
                //foreach method to display all recipes stored in sortedRecipes
                foreach (var recipe in sortedRecipes)
                {//for each begin
                    //display the Name of the recipe and Total Calories of Recipe
                    lbxRecipes.Items.Add($"{recipe.Name}\n{recipe.CalculateTotalCalories()} total calories");
                }//foreach end
            }//else

        }//LoadRecipe end

        //Button click event to Open the window to add another Recipe
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {//AddRecipeButton begin
            //Open addRecipe window and close the current window
            var addRecipeWindow = new AddRecipe(manageRecipe);
            addRecipeWindow.Show();
            this.Hide();
        }//AddRecipeButton end


        //Button click Method to display the recipe selected by the user by opening the viewRecipeWindow
        private void ViewRecipeButton_Click_1(object sender, RoutedEventArgs e)
        {//ViewRecipeButton begin
            //Stored the index value for the recipe the user selected
            int selection = lbxRecipes.SelectedIndex;

            //if statement for validation if the user did not select a recipe or if there are no recipes to select
            if (selection < 0 || sortedRecipes.Count == 0)
            {//if begin
                //Display message in a message box to alret user that they need to select a recipe
                MessageBox.Show("Please select a recipe to view.");
                return;
            }//if end

            //Open the viewReci[pe window to display the recipe thew user has sleected
            var selectedRecipe = sortedRecipes[selection];
            //Pass the selected recipe to the viewRecipe Window
            var viewRecipeWindow = new ViewRecipe(selectedRecipe, manageRecipe);
            //Open viewRecipeWindow and close the current window
            viewRecipeWindow.Show();
            this.Hide();
        }//end ViewRecipeButton

        //Button Click event to exit the application
        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {//ExitButton begin
            //Display message to let user know that they are exiting the App
            MessageBox.Show("Exiting Application! Thank You for using My Recipe App");

            //close the window
            this.Close();

            //Exit the application
            Application.Current.Shutdown();
        }//ExitButton end

        //Button Click to open the Filter window to allow user to filter the list of recipes
        private void FilterRecipeButton_Click_1(object sender, RoutedEventArgs e)
        {//FilterRecipeButton
            //Open the Filter window passing the manage recipe class as a parameter
            var filterWindow = new Filter(manageRecipe);
            filterWindow.Show();
            //close the current window
            this.Hide();
        }//FilterRecipeButton
    }//AllRecipe Window end
}//namespace ST10251759_PROG6221_POE end

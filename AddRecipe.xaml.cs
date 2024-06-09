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
using System.Xml.Linq;

/*
 Student Number: ST10251759
 Full Name: Cameron Chetty
 Course: PROG6221
 Assessment: POE Part 2
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

=============Code Attribution====================
*/

namespace ST10251759_PROG6221_POE
{// namespace ST10251759_PROG6221_POE begin
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {//AddRecipe Window begin
        //Varaible declaration
        private ManageRecepie manageRecipes;

        //Constructor with parameter
        public AddRecipe(ManageRecepie manageRecipes)
        {//AddRecipe constructorpassing manage recipe variable as a paramether begin
            InitializeComponent();
            this.manageRecipes = manageRecipes;
        }//AddRecipe constructorpassing manage recipe variable as a paramether end
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //Button Click Event to add the recipe details, get the number of ingredients and steps in recipe to prompt suer for their input
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {//AddRecipe Button begin

            //Store the recipe name in a variable
            string recipeName = RecipeNameTextBox.Text;
            //Validation for if input is null
            if (string.IsNullOrEmpty(recipeName))
            {//if recipeName is null display error message begin
                MessageBox.Show("Recipe name cannot be empty.");
                return;
            }//if recipeName end

            //store the number of ingreints in varaible and then do validation id user did not enter a number
            if (!int.TryParse(NumIngredientstxt.Text, out int numIngredients) || numIngredients <= 0)
            {//if user did not enter a number then display error message begin
                MessageBox.Show("Please enter a valid number of ingredients.");
                return;
            }//if numIngredients is invlaid end

            //store the number of steps in a variable and do validation if the value is a valid number
            if (!int.TryParse(NumStepstxt.Text, out int numSteps) || numSteps <= 0)
            {//if user did not enter a number then display error message begin
                MessageBox.Show("Please enter a valid number of steps.");
                return;
            }//if numSteps is invlaid end

            // Create the recipe object and pass the name of recipem number of ingredients and number of steps to the recipe class
            Recipe recipe = new Recipe(recipeName, numIngredients, numSteps);
            //Create AddIngreientWindow object int=stance pass number of ingreinetns and the recipe and manage recipe class as parameters,  numIngreidents will be used to llop the window to get all the ingredients input from user
            var addIngredientsWindow = new AddIngredients(recipe, numIngredients, manageRecipes);
            //Open AddIngredientsWindow and close the current window
            addIngredientsWindow.Show();
            this.Close();

            //Add an instance of the recipe and pass this as a parameter to manage recipe class
            manageRecipes.AddRecipe(recipe);

            

            // Reset the fields for the next recipe
            RecipeNameTextBox.Clear();
            NumIngredientstxt.Clear();
            NumStepstxt.Clear();
        }//AddRecipe button end
    }//AddRecipe Window end
}// namespace ST10251759_PROG6221_POE end

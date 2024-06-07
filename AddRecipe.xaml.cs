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

namespace ST10251759_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        private ManageRecepie manageRecipes;

        public AddRecipe(ManageRecepie manageRecipes)
        {
            InitializeComponent();
            this.manageRecipes = manageRecipes;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Recipe name cannot be empty.");
                return;
            }

            if (!int.TryParse(NumIngredientstxt.Text, out int numIngredients) || numIngredients <= 0)
            {
                MessageBox.Show("Please enter a valid number of ingredients.");
                return;
            }

            if (!int.TryParse(NumStepstxt.Text, out int numSteps) || numSteps <= 0)
            {
                MessageBox.Show("Please enter a valid number of steps.");
                return;
            }

            // Create the recipe object
            Recipe recipe = new Recipe(recipeName, numIngredients, numSteps);

            // Open a new window to enter ingredients and steps
            var addIngredients = new AddIngredients(recipe);
            if (addIngredients.ShowDialog() == true)
            {
                // Add the recipe to the manageRecipes collection if user successfully entered ingredients and steps
                manageRecipes.AddRecipe(recipe);
                MessageBox.Show("Recipe added successfully!");
                this.Close();
            }
        }
    }
}

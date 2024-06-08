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
    /// Interaction logic for AllRecipes.xaml
    /// </summary>
    public partial class AllRecipes : Window
    {
        private ManageRecepie manageRecipe;
        private List<Recipe> recipes;
        private int selection;

        public AllRecipes(ManageRecepie manageRecipe)
        {
            InitializeComponent();
            this.manageRecipe = manageRecipe;
            this.recipes = manageRecipe.Recipes;
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            lbxRecipes.Items.Clear();
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                lbxRecipes.Items.Add($"{recipe.Name}\n{recipe.CalculateTotalCalories()} total calories");
            }
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipe(manageRecipe);
            addRecipeWindow.Show();
            this.Hide();
        }


        private void FilterRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //var filterWindow = new Filter(manageRecipe);
            //filterWindow.Show();
            //this.Hide();
        }

        private void ViewRecipeButton_Click_1(object sender, RoutedEventArgs e)
        {
            int selection = lbxRecipes.SelectedIndex;
            if (selection < 0)
            {
                MessageBox.Show("Please select a recipe to view.");
                return;
            }

            var selectedRecipe = recipes[selection];
            var viewRecipeWindow = new ViewRecipe(selectedRecipe, manageRecipe);
            viewRecipeWindow.Show();
            this.Hide();
        }

        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

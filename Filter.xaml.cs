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
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private int filter;
        private ManageRecepie manageRecipe;
        private List<Recipe> recipes;
        private List<FoodGroup> groups = new List<FoodGroup>();

        public Filter(ManageRecepie manageRecipe)
        {
            InitializeComponent();
            this.manageRecipe = manageRecipe;
            this.recipes = manageRecipe.Recipes;
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            groups = Enum.GetValues(typeof(FoodGroup)).Cast<FoodGroup>().ToList();
            foreach (var group in groups)
            {
                cmbGroup.Items.Add(group.ToString());
            }
        }

        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            var allRecipesWindow = new AllRecipes(manageRecipe);
            allRecipesWindow.Show();
            this.Close();
        }




        private void HideAllFilterOptions()
        {
            NameTxt.Visibility = Visibility.Hidden;
            cmbGroup.Visibility = Visibility.Hidden;
            CaloriesTxt.Visibility = Visibility.Hidden;
        }

        private void NameFilter(string ingredientName)
        {
            var filteredRecipes = recipes
        .Where(r => r.Ingredients.Any(i => i.Name.IndexOf(ingredientName, StringComparison.OrdinalIgnoreCase) >= 0))
        .ToList();
            DisplayRecipes(filteredRecipes);
        }

        private void GroupFilter(FoodGroup selectedGroup)
        {
            var filteredRecipes = recipes
       .Where(r => r.Ingredients.Any(i => i.FoodGroup == selectedGroup))
       .ToList();
            DisplayRecipes(filteredRecipes);
        }

        private void CalorieFilter(double maxCalories)
        {
            var filteredRecipes = recipes
                .Where(r => r.CalculateTotalCalories() <= maxCalories)
                .ToList();
            DisplayRecipes(filteredRecipes);
        }

        private void DisplayRecipes(List<Recipe> filteredRecipes)
        {
            foreach (var recipe in filteredRecipes)
            {
                lbxRecipes.Items.Add($"{recipe.Name}\n{recipe.CalculateTotalCalories()} total calories");
            }
        }


        private void ViewRecipeBtn_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lbxRecipes.SelectedIndex;
            if (selectedIndex >= 0)
            {
                var viewRecipeWindow = new ViewRecipe(recipes[selectedIndex], manageRecipe);
                viewRecipeWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a recipe to view.");
            }
        }

        private void FoodGroupFilterBtn_Click_1(object sender, RoutedEventArgs e)
        {
            HideAllFilterOptions();
            cmbGroup.Visibility = Visibility.Visible;
            filter = 2;
        }

        private void NameFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            HideAllFilterOptions();
            NameTxt.Visibility = Visibility.Visible;
            filter = 1;
        }

        private void CaloriesFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            HideAllFilterOptions();
            CaloriesTxt.Visibility = Visibility.Visible;
            filter = 3;
        }

        private void ApplyFilterBtn_Click_1(object sender, RoutedEventArgs e)
        {
            lbxRecipes.Items.Clear();
            switch (filter)
            {
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
            }
        }
    }
}

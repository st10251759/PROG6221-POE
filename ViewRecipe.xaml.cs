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
    /// Interaction logic for ViewRecipe.xaml
    /// </summary>
    public partial class ViewRecipe : Window
    {
        private Recipe currentRecipe;
        private ManageRecepie manageRecipe;

        public ViewRecipe(Recipe recipe, ManageRecepie manageRecipe)
        {
            InitializeComponent();
            this.currentRecipe = recipe;
            DisplayRecipeDetails();
            this.manageRecipe = manageRecipe;
        }

        private void DisplayRecipeDetails()
        {
            txtRecipeDetails.Document.Blocks.Clear();
            txtRecipeDetails.AppendText(currentRecipe.DisplayRecipe());
        }

        private void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            var AllRecipes = new AllRecipes(manageRecipe);
            AllRecipes.Show();
            this.Close();

        }

        private void ScalingRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            lblScalingFactor.Visibility = Visibility.Visible;
            FactorComboBox.Visibility = Visibility.Visible;
            ProccedButton.Visibility = Visibility.Visible;
        }

        private void ProccedButton_Click(object sender, RoutedEventArgs e)
        {
            if (FactorComboBox.SelectedItem != null)
            {
                txtRecipeDetails.Document.Blocks.Clear();

                ComboBoxItem selectedItem = (ComboBoxItem)FactorComboBox.SelectedItem;
                double factor = Convert.ToDouble(selectedItem.Content);
                manageRecipe.ScaleRecipe(currentRecipe, factor);
                txtRecipeDetails.AppendText(currentRecipe.DisplayRecipe());

                //Hide the Scaling Components
                lblScalingFactor.Visibility = Visibility.Hidden;
                FactorComboBox.SelectedIndex = -1;
                FactorComboBox.Visibility = Visibility.Hidden;
                ProccedButton.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Please select a scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            manageRecipe.ResetRecipe(currentRecipe);
            txtRecipeDetails.Document.Blocks.Clear();
            txtRecipeDetails.AppendText(currentRecipe.DisplayRecipe());
        }

        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                manageRecipe.DeleteRecipe(currentRecipe);
                OpenAllRecipesWindow();
            }
        }

        private void OpenAllRecipesWindow()
        {
            AllRecipes allRecipesWindow = new AllRecipes(manageRecipe);
            allRecipesWindow.Show();
            this.Close();
        }

    }
}

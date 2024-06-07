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
    /// Interaction logic for AddIngredients.xaml
    /// </summary>
    public partial class AddIngredients : Window
    {
        private Recipe recipe;

        List<UnitOfMeasurement> units = new List<UnitOfMeasurement>();
        // list to store units in enum
        List<FoodGroup> groups = new List<FoodGroup>();
        // list to store food groups in enum



        public AddIngredients(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            units.Add(UnitOfMeasurement.SMALL);
            units.Add(UnitOfMeasurement.MEDIUM);
            units.Add(UnitOfMeasurement.LARGE);
            units.Add(UnitOfMeasurement.EXTRALARGE);
            units.Add(UnitOfMeasurement.TEASPOON);
            units.Add(UnitOfMeasurement.TEASPOONS);
            units.Add(UnitOfMeasurement.TABLESPOON);
            units.Add(UnitOfMeasurement.TABLESPOONS);
            units.Add(UnitOfMeasurement.CUP);
            units.Add(UnitOfMeasurement.CUPS);
            // add all enum values to units list

            for (int i = 0; i < units.Count(); i++)
            {
                unitComboBox.Items.Add(units[i]);
            }// add all enum values from the list to the correct combo box

            groups.Add(FoodGroup.CARBOHYDRATE);
            groups.Add(FoodGroup.PROTEIN);
            groups.Add(FoodGroup.FAT);
            groups.Add(FoodGroup.FRUIT);
            groups.Add(FoodGroup.VEGETABLE);
            groups.Add(FoodGroup.DAIRY);
            // add all enum values to groups list

            for (int i = 0; i < groups.Count(); i++)
            {
                foodGroupComboBox.Items.Add(groups[i]);
            }// add all enum values from list to the correct combo box
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < recipe.NumIngredients; i++)
            {
                string name = IngredientNameTextBox.Text;
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show($"Ingredient {i + 1} name cannot be empty.");
                    return;
                }

                if (!double.TryParse(Quantitytxt.Text, out double quantity) || quantity <= 0)
                {
                    MessageBox.Show($"Please enter a valid quantity for ingredient {i + 1}.");
                    return;
                }

                if (!double.TryParse(NumCaloriestxt.Text, out double calories) || calories < 0)
                {
                    MessageBox.Show($"Please enter a valid number of calories for ingredient {i + 1}.");
                    return;
                }

                if (!Enum.TryParse<UnitOfMeasurement>(unitComboBox.SelectedItem?.ToString(), out UnitOfMeasurement unit))
                {
                    MessageBox.Show($"Please select a unit of measurement for ingredient {i + 1}.");
                    return;
                }

                if (!Enum.TryParse<FoodGroup>(foodGroupComboBox.SelectedItem?.ToString(), out FoodGroup group))
                {
                    MessageBox.Show($"Please select a food group for ingredient {i + 1}.");
                    return;
                }

                // Add the ingredient to the recipe
                recipe.Ingredients.Add(new Ingredient(name, quantity, unit, group, calories));
            }

            recipe.CalculateTotalCalories();

            // Show success confirmation
            //var successWindow = new SuccessWindow();
            //successWindow.ShowDialog();

            // Reset the fields for the next ingredient
            IngredientNameTextBox.Clear();
            Quantitytxt.Clear();
            NumCaloriestxt.Clear();
            unitComboBox.SelectedIndex = -1;
            foodGroupComboBox.SelectedIndex = -1;
        }
    }
}

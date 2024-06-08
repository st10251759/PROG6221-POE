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
    /// Interaction logic for AddSteps.xaml
    /// </summary>
    public partial class AddSteps : Window
    {
        private Recipe recipe;
        private int numSteps;
        private int currentStepIndex = 0;
        public AddSteps(Recipe recipe, int numSteps)
        {
            InitializeComponent();
            this.recipe = recipe;
            this.numSteps = numSteps;
            UpdateStepLabel();
        }

        //private void btnAddStep_Click(object sender, RoutedEventArgs e)
        //{
        //    string description = StepDescriptiontxt.Text;
        //    if (string.IsNullOrWhiteSpace(description))
        //    {
        //        MessageBox.Show("Step description cannot be empty.");
        //        return;
        //    }

        //    recipe.Steps.Add(new Step { Description = description });

        //    // Show success confirmation
        //    var successWindow = new SuccessWindow("Step added successfully!");
        //    successWindow.ShowDialog();

        //    // Reset the field for the next step
        //    StepDescriptiontxt.Text = "";
        //}

        private void btnAddStep_Click_1(object sender, RoutedEventArgs e)
        {
            string description = StepDescriptiontxt.Text;
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Step description cannot be empty.");
                return;
            }

            recipe.Steps.Add(new Step { Description = description });

            currentStepIndex++;

            if (currentStepIndex < numSteps)
            {
                var successWindow = new SuccessWindow("Step added successfully!");
                successWindow.Show();
                ResetFields();
                UpdateStepLabel();
            }
            else
            {
                var successWindow = new SuccessWindow("All steps added successfully!");
                successWindow.Show();
                this.Close();

                var successWindow2 =new SuccessWindow("Recipe added successfully!");
                successWindow2.Show();
            }
        }

        private void ResetFields()
        {
            StepDescriptiontxt.Text = "";
        }

        private void UpdateStepLabel()
        {
            AddStepLabel.Content = $"Add Step {currentStepIndex + 1} of {numSteps}";
        }
    }
}

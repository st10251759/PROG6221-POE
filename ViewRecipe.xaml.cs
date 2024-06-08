﻿using System;
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
        private Recipe recipe;

        public ViewRecipe(Recipe selectedRecipe)
        {
            InitializeComponent();
            recipe = selectedRecipe;
            DisplayRecipeDetails();
        }

        private void DisplayRecipeDetails()
        {
            txtRecipeDetails.Text = recipe.DisplayRecipe();
        }

    }
}

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
using System.Windows.Navigation;
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

=============Code Attribution====================
*/

namespace ST10251759_PROG6221_POE
{//namespace ST10251759pROG6221_POE begin
    public partial class MainWindow : Window
    {//MainWindow Class begin
        //Variable to hold manageRecipe Class
        private ManageRecepie manageRecipes;

        // Parameterless constructor required by the XAML loader
        public MainWindow()
        {//MainWindow() begin
            InitializeComponent();
            this.manageRecipes = new ManageRecepie(); // Initialize ManageRecepie instance here
        }//MainWindow() end

        // Optional constructor to pass an existing ManageRecepie instance
        public MainWindow(ManageRecepie manageRecipes)
        {//MainWindow() passing manageRecipe class begin
            InitializeComponent();
            this.manageRecipes = manageRecipes;
        }//MainWindow() passing manageRecipe class end

        //Get Started Button to navigate to the next form
        private void Button_Click(object sender, RoutedEventArgs e)
        {//GetStarted method begin
            //Open the AddRecipe Window
            AddRecipe addRecipeWindow = new AddRecipe(manageRecipes);
            addRecipeWindow.Show();
            //Close this Window
            this.Close();
        }//GetStarted method end
    }//MainWindowClass End
}//namespace ST10251759pROG6221_POE end

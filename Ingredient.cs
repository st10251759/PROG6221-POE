using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 Student Number: ST10251759
 Full Name: Cameron Chetty
 Course: PROG6221
 Assessment: POE Part 2
 Github Link for Part 1: https://github.com/VCDN-2024/prog6221-part-1-st10251759
 Github Link for Part 2: https://github.com/st10251759/prog6221-part-2-st10251759
 */

/*
=============Code Attribution====================

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/EnumDemo_App
Date of Access: 09 April 2024 

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Generics_Library_App
Date of Access: 29 May 2024 

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Collection_Generics_LU3
Date of Access: 29 May 2024 


=============Code Attribution====================
*/

namespace ST10251759_PROG6221_POE
{//namespace begin
    public class Ingredient
    {//Ingredient Class Begin
        //attribute variable declaration - with getter and setter methods 
        public string Name { get; set; }
        public double Quantity { get; set; }
        //public string Unit { get; set; }
        public double OriginalQuantity { get; set; } //variable to hold orginal value for Quanity used in reset method
        public UnitOfMeasurement OriginalUnit { get; set; } //variable to hold orginal Unit of measurement used in reset method
        public UnitOfMeasurement Unit { get; set; } //enum for unit of measurement

        public FoodGroup FoodGroup { get; set; } //enum for food group
        public double calories { get; set; } //variable to hold the  calories for each ingredient
        public double originalCalories { get; set; }//variable to hold the the orginal quanity used when calling the reset recipe method

        //contructor method without parameters
        public Ingredient()
        {
        }

        //constructor Method with 5 parameters
        public Ingredient(string name, double quantity, UnitOfMeasurement unit, FoodGroup foodGroup, double calories)
        {//constructor begin
            Name = name;
            Quantity = quantity;
            Unit = unit;
            OriginalQuantity = quantity;
            OriginalUnit = unit; //needs to be stroed in an integer
            FoodGroup = foodGroup;
            this.calories = calories;
            originalCalories = calories;
        }//constructor end


        //method to alter the Quatity to return to its orginal state
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }
        //method to alter the Unit to return to its orginal state
        public void ResetUnit()
        {
            Unit = OriginalUnit;
        }

        //method to calulate the scaled cories (alter the calories using the scaling factor)
        public void CalculateScaledCalories(double factor)
        {
            // Assuming CaloriesPerUnit is the number of calories per unit of the ingredient
            calories = factor * calories;
        }

        //method to alter the calories to return to its orginal state
        public void ResetCalories()
        {
            this.calories = originalCalories;
        }

        public void display()
        { Console.WriteLine($"{Quantity} {Unit} of {Name}\nFood Group: {FoodGroup}\n{calories} calories\n"); }
        // display method created to display the quantity along with the unit of measurment for each ingredient
        // as well as number of calories and food group
        // string interpolation used in display

    }//Ingredient Class end
}//namespace end

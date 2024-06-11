# Recipe Management Console Application

## Description
This Windows Presentation Foundation (WPF) application allows users to manage recipes, including entering an unlimited amount of recipes, ingredients, and steps. The user is shown a welcome window and must press the "Get Started" button to begin. They will then be prompted to enter the name of the recipe, the number of ingredients, and the number of steps. The application stores this information in memory using generic collections.

Users can then add ingredients, including name, quantity, unit of measurement, calories, and food group, which are stored in a list. They can also add steps for the recipe, stored as strings in a separate list. The application provides a user-friendly graphical user interface (GUI) for easy navigation and input.

The application includes features to scale recipes by a desired factor (0.5, 2, 3), allowing users to view half, double, triple, or the original recipe. The unit of measurement for each ingredient scales along with the quantities. For example, if the original recipe requires 8 tablespoons and the user selects to double the recipe, the system will display 1 cup, equivalent to 16 tablespoons.

Additionally, the application calculates and displays the total number of calories in a recipe. It provides a unique message to the user based on the number of calories, with an explanation for the calorie range. An alert is displayed if the recipe exceeds 300 total calories.

Users can add many different recipes and view or manipulate them as needed (scale by half, double, or triple). The application also allows users to filter the list of recipes by name, food group, or maximum calories, providing a customized recipe selection.

## Links to Github Repositories
- Part 1: [https://github.com/VCDN-2024/prog6221-part-1-st10251759](https://github.com/VCDN-2024/prog6221-part-1-st10251759)
- Part 2: [https://github.com/st10251759/prog6221-part-2-st10251759](https://github.com/st10251759/prog6221-part-2-st10251759)
- Part 3: [https://github.com/st10251759/PROG6221-POE](https://github.com/st10251759/PROG6221-POE)
  
## Table of Contents
1. [Installation](#installation)
2. [Feedback Implementation](#feedback-implementation)
3. [Usage](#usage)
4. [New Features](#new-features)
5. [Code Attribution](#code-attribution)
6. [Learning Outcomes](#learning-outcomes)

## Installation
To run the application, follow these steps:
1. Clone the repository to your local machine.
3. Open the project in Visual Studio.
4. Build the project to restore dependencies.
5. Run the application by clicking the green play button in Visual Studio.

## Feedback Implementation
I obtained 100% and required no implemented feedback. All work done was to address the requirements of PART 2 ONLY, and there is NO FEEDBACK to implement for part 1.  

## Usage
1. Click the "Get Started" button on the welcome page.
2. Enter the name of the recipe, the number of ingredients, and the number of steps.
3. Input the details for each ingredient, including name, quantity, unit of measurement, calories, and food group. Then Click the 'Add Ingredient' button.
4. Input the steps for the recipe. Then Click the 'Add Step' button.
5. In the main menu all recipe added will be displayed as well and options including, Add Recipe, Filter Recipes, View Recipe, Exit. Chose your option.
6. Select an option from the main menu:
   - **Add Recipe**: Add a new Recipe with the recipe details mentioned from point 2 to 4.
   - **Filter Recipe**: Filter recipes by name, food group, or maximum number of calories.
   - **View Recipe**: Displays the recipe selected by the user and provides options including scaling by a factor, reset recipe to orginal state, Clearing or deleteing the recipe from the list of recipes, or returning to main menu.
   - **Exit**: Exit the application.

## New Features
- Converted from a console application to a user-friendly WPF application.
- Added the ability to filter recipes by name, food group, or maximum calories.
- Improved the user interface with colors, pictures, input validation components and formatting.

Feel free to contribute to the project by submitting pull requests or suggesting new features. Thank you for using the Recipe Management Console Application!

## Code Attribution
- **Fatima Shaik**
  - Source: [PROG6221-Group1-2024](https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/ErrorHandling_App)
  - Date Accessed: 29 May 2024
  - Source: [PROG6221-Group1-2024](https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Class_Objects_App)
  - Date Accessed: 29 May 2024
  - Source: [PROG6221-Group1-2024](https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/EnumDemo_App)
  - Date Accessed: 29 May 2024
  - Source: [PROG6221-Group1-2024](https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Generics_Library_App)
  - Date Accessed: 29 May 2024
  - Source: [PROG6221-Group1-2024](https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Collection_Generics_LU3)
  - Date Accessed: 29 May 2024
- **GeeksForGeeks**
  - Source: [C# List Class](https://www.geeksforgeeks.org/c-sharp-list-class/)
  - Date Accessed: 29 May 2024
  - Source: [Bubble Sort](https://www.geeksforgeeks.org/bubble-sort/)
  - Date Accessed: 29 May 2024
  - Source: [Delegates]((https://www.geeksforgeeks.org/c-sharp-delegates/)
  - Date Accessed: 29 May 2024
- **Microsoft**
  - Source: [WPF](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0)
  - Date Accessed: 09 June 2024
  - Source: [Lambda Expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)
  - Date Accessed: 09 June 2024
- **tutorialspoint**
  - Source: [WPF](https://www.tutorialspoint.com/wpf/index.htm)
  - Date Accessed: 09 June 2024
- **Stack Overflow**
  - Source: [WPF](https://stackoverflow.com/questions/2820357/how-do-i-exit-a-wpf-application-programmatically)
  - Date Accessed: 09 June 2024
  
## Learning Outcomes
By the end of this project, I have mastered the knowlegde related to:
- Use Extensible Application Markup Language (XAML) to create graphical user interfaces.
- Utilize controls to build a graphical user interface.
- Implement graphics rendering services to display graphical views of data.
- Apply styles in a user interface.

### Future Development Goals
In the final phase of this project, you will update the application to include a graphical user interface (GUI) using either WPF or UWP. All functionalities from the command-line application must be preserved and presented in a more user-friendly way. Additionally, one of the following features should be added:
1. Filter recipes by:
   - Ingredient name,
   - Food group, or
   - Maximum calories.
2. Create a menu with multiple recipes and display a pie chart showing the percentage of each food group in the total menu.

Thank you for your interest and contributions to the Recipe Management Console Application!

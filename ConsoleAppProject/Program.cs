﻿using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Ethan Smith
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;
            string appChoice;
            //setting the types for these variables

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n =================================================");
            Console.WriteLine("   BNU CO453 Applications Programming 2022-2023!  ");
            Console.WriteLine("                  by Ethan Smith                  ");
            Console.WriteLine(" =================================================\n");
            //creates the main heading shown to the user

            while(exit == false){
            //creates a loop to keep the program running until the user manually exits it
                Console.Write("MAIN MENU\n1. Distance Converter\n2. BMI Calculator\n3. Grade Calculator\n4. Social Network\n5. Exit Program\n\nPlease enter your choice: ");
                appChoice = Console.ReadLine();
                //asks the user to enter the app they want to use, or exit the program
                
                if (string.Equals(appChoice, "1")){
                    DistanceConverter converter = new DistanceConverter();
                    converter.Run();
                }
                //checks if the user entered the first program, and then opens it if they did
                
                else if (string.Equals(appChoice, "2")){
                    BMI calculator = new BMI();
                    calculator.Run();
                }
                //checks if the user entered the second program, and then opens it if they did
                
                else if (string.Equals(appChoice, "3")){
                    StudentGrades grades = new StudentGrades();
                    grades.Run();
                }
                //checks if the user entered the third program, and then opens it if they did

                else if (string.Equals(appChoice, "4")){
                    NewsFeed feed= new NewsFeed();
                    feed.Run();
                }
                //checks if the user entered the fourth program, and then opens it if they did

                else if (string.Equals(appChoice, "5")){
                    exit = true;
                    Console.WriteLine("Exiting Program...\n");
                }
                //checks if the user wants to exit program, and then exits it if they did by breaking the loop
                
                else{
                    Console.WriteLine("Invalid option.\n");
                }
                //if no other option is entered then the user entered an invalid option so an error is displayed
            }
        }
    }
}
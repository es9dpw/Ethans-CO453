﻿using System;
using System.Collections.Generic;
using System.Collections;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// The NewsFeed class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author> 
    public class NewsFeed
    {
        bool exit = false;
        bool userPosts;
        int postCount = -1;
        int listCount;
        string menuChoice;
        string user = "";
        string userChoice;
        ArrayList posts = new ArrayList();
        ArrayList author = new ArrayList();

        public void Run()
        {
            Console.WriteLine("\n =================================================");
            Console.WriteLine("               App04: Social Network              ");
            Console.WriteLine("                  by Ethan Smith                  ");
            Console.WriteLine(" =================================================");
            Console.WriteLine("            This is an app to create             ");
            Console.WriteLine("         and view text and photo posts           ");
            Console.WriteLine(" =================================================\n");
            //creates the heading for the app and displays it to the user;

            while (exit == false){
                Menu();
                //calls the Menu method

                if (string.Equals(menuChoice, "1")){
                //checks if the entred the first menu option
                    Login();
                }

                if (string.Equals(menuChoice, "4")){
                //checks if the entred the fourth menu option
                    PostDisplay();
                }

                if (string.Equals(menuChoice, "5")){
                //checks if the entred the fifth menu option
                    AuthorPostDisplay();
                }
                
                else if (string.Equals(menuChoice, "6")){
                //checks if the entred the sixth menu option
                    exit = true;
                    Console.WriteLine("Exiting App...\n");
                    //breaks the apps loop to exit the app
                }

                else{
                    Console.WriteLine("Invalid option.\n");
                }
                //if none of the available options are entered then an error is diplayed
            }
        }

        public void Menu()
        {
            Console.Write("MAIN MENU\n1. Log");
            if (string.Equals(user, "")){
                Console.Write("in");
            }
            else{
                Console.Write("out");
            }
            Console.Write("\n2. Add message post\n3. Add photo post\n4. Display all posts\n5. Display all posts by a user\n6. Exit App\n\nPlease enter your choice: ");
            menuChoice = Console.ReadLine();
        }
        //takes the users input on which menu option they want

        public void Login()
        {
            if (string.Equals(user, "")){
                while (string.Equals(user, "")){
                    Console.Write("Enter your username to login: ");
                    user = Console.ReadLine();
                    if (string.Equals(user, "")){
                        Console.WriteLine("Invalid username, try again.");
                    }
                }
                Console.WriteLine(user + " logged in.\n");
            }
            else{
                Console.WriteLine("Logged out.\n");
                user = "";
            }
        }

        public void PostDisplay(){
            if (postCount < 0){
                Console.WriteLine("No posts have been made.\n");
            }
            else{
                listCount = -1;
                Console.WriteLine("");
                while(listCount < postCount){
                    listCount++;
                    Console.WriteLine(posts[listCount] + "\n@" + author[listCount] + "\n");
                }
            }
        }

        public void AuthorPostDisplay(){
            if (postCount < 0){
                Console.WriteLine("No posts have been made.\n");
            }
            else{
                listCount = -1;
                userPosts = false;
                Console.Write("Enter the username to see their posts: ");
                userChoice = Console.ReadLine();
                while(listCount < postCount){
                    listCount++;
                    if (string.Equals(author[listCount], "userChoice")){
                        Console.WriteLine("\n" + posts[listCount] + "\n@" + author[listCount]);
                        userPosts = true;
                    }
                }
                if (userPosts == false){
                        Console.WriteLine("This user hasn't made any posts.");
                }
                Console.WriteLine("");
            }
        }
    }
}
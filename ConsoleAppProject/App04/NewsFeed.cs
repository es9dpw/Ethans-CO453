﻿using System;
using System.Collections.Generic;
using System.Collections;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class contains the main method run running the social network app. It allows users to slect options from the menu
    /// including logging in or out, create a message or image post and displaying all posts or posts by a certain user.
    ///</summary>
    ///<author>
    /// Ethan Smith
    ///</author> 
    public class NewsFeed
    {
        bool exit = false;
        bool userPosts;
        int listCount;
        string menuChoice;
        static public string user = "";
        string userChoice;
        string ID;
        static public ArrayList posts = new ArrayList();
        static public ArrayList author = new ArrayList();

        ///<summary>
        /// This method is the main method and is where all other classes and methods are called from, as well as where all the
        /// checks for what the user has entered at the menu are done.
        ///</summary>
        public void Run()
        {
            Console.WriteLine("\n =================================================");
            Console.WriteLine("               App04: Social Network              ");
            Console.WriteLine("                  by Ethan Smith                  ");
            Console.WriteLine(" =================================================");
            Console.WriteLine("            This is an app to create             ");
            Console.WriteLine("         and view text and photo posts           ");
            Console.WriteLine(" =================================================\n");

            while (exit == false){
                Menu();

                if (string.Equals(menuChoice, "1")){
                    Login();
                }

                else if (string.Equals(menuChoice, "2")){
                    if (string.Equals(user, "")){
                        Console.WriteLine("A User must be logged in to create a post.\n");
                    }
                    else{
                        Messages message = new Messages();
                        message.MessagePost();
                    }
                }

                else if (string.Equals(menuChoice, "3")){
                    if (string.Equals(user, "")){
                        Console.WriteLine("A User must be logged in to create a post.\n");
                    }
                    else{
                        Images image = new Images();
                        image.ImagePost();
                    }
                }

                else if (string.Equals(menuChoice, "4")){
                    RemovePost();
                }

                else if (string.Equals(menuChoice, "5")){
                    PostDisplay();
                }

                else if (string.Equals(menuChoice, "6")){
                    AuthorPostDisplay();
                }
                
                else if (string.Equals(menuChoice, "7")){
                    exit = true;
                    Console.WriteLine("Exiting App...\n");
                }

                else{
                    Console.WriteLine("Invalid option.\n");
                }
            }
        }

        ///<summary>
        /// This method creates the main menu, changing the first option depending on if the user is already logged in or not,
        /// and then takes the user's input.
        ///</summary>
        public void Menu()
        {
            Console.Write("MAIN MENU\n1. Log");
            if (string.Equals(user, "")){
                Console.Write("in");
            }
            else{
                Console.Write("out");
            }
            Console.Write("\n2. Add message post\n3. Add photo post\n4. Remove post\n5. Display all posts\n6. Display all posts by a user\n7. Exit App\n\nPlease enter your choice: ");
            menuChoice = Console.ReadLine();
        }

        ///<summary>
        /// This method is run after the user selects the login or logout option on the menu, and will prompt them to enter
        /// their username to login if no one is already logged in, and will log them out if someone is already logged in.
        ///</summary>
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

        public void RemovePost(){
            if (string.Equals(user, "")){
                Console.WriteLine("A User must be logged in to remove their posts.\n");
            }
            else if ((posts.Count-1) < 0){
                Console.WriteLine("You haven't made any posts.\n");
            }
            else{
                listCount = -1;
                userPosts = false;
                while(listCount < (posts.Count-1)){
                    listCount++;
                    if (string.Equals(author[listCount], user)){
                        Console.WriteLine("\n" + posts[listCount] + "\n@" + author[listCount] + "\nPost ID: " + (listCount+1));
                        userPosts = true;
                    }
                }
                if (userPosts == false){
                        Console.WriteLine("You haven't made any posts.\n");
                }
                else{
                    Console.WriteLine("");
                    Console.Write("Enter the ID of the post you want to remove, or enter nothing to cancel and return to the menu: ");
                    ID = Console.ReadLine();
                    if (string.Equals(ID, "")){
                        Console.WriteLine("Returning to menu.\n");
                    }
                    else{
                        posts.RemoveAt(Convert.ToInt32(ID) - 1);
                        author.RemoveAt(Convert.ToInt32(ID) - 1);
                        Console.WriteLine("Post Removed.\n");
                    }
                }
            }
        }

        ///<summary>
        /// This method will run after the user has selected the option to display all posts on the menu, and will run through
        /// all the posts and display them with the user that posted them and the post ID underneath.
        ///</summary>
        public void PostDisplay(){
            if ((posts.Count-1) < 0){
                Console.WriteLine("No posts have been made.\n");
            }
            else{
                listCount = -1;
                while(listCount < (posts.Count-1)){
                    listCount++;
                    Console.WriteLine("\n" + posts[listCount] + "\n@" + author[listCount]);
                }
                Console.WriteLine("");
            }
        }

        public void AuthorPostDisplay(){
            if ((posts.Count-1) < 0){
                Console.WriteLine("No posts have been made.\n");
            }
            else{
                listCount = -1;
                userPosts = false;
                Console.Write("Enter the username to see their posts: ");
                userChoice = Console.ReadLine();
                while(listCount < (posts.Count-1)){
                    listCount++;
                    if (string.Equals(author[listCount], userChoice)){
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

    public class Posts
    {
        public string postContent;

        public void Post(){
            NewsFeed.author.Add(NewsFeed.user);
            Console.WriteLine("Post Created.\n");
        }
    }

    public class Messages : Posts
    {
        public void MessagePost()
        {
            Console.Write("Please enter the message for your post: ");
            NewsFeed.posts.Add(Console.ReadLine());
            Post();
        }
    }

    public class Images : Posts
    {
        string imageContent;
        string captionContent;

        public void ImagePost()
        {
            Console.Write("Please enter the URL for your image: ");
            imageContent = Console.ReadLine();
            Console.Write("Please enter the caption for your post: ");
            captionContent = Console.ReadLine();
            NewsFeed.posts.Add(imageContent + "\n" + captionContent);
            Post();
        }
    }
}
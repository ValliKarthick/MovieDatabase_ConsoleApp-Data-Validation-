using System;

namespace MovieDatabase_ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {           
            MovieManipulation movieManipulation = new MovieManipulation();
            MenuOption:
            Console.WriteLine("Welcome to Movie Database..! \n1. Display All Movies \n2. Add Movie Details \n3. Edit Movie \n4. Remove Movie \n5. Find Movie \n5. Exit \nSelect Your Option");
            int userChoice;
            userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    movieManipulation.DisplayMovies();
                    break;
                case 2:
                    movieManipulation.AddMovie();
                    break;
                case 3:
                    movieManipulation.EditMovie();
                    break;
                //case 4:
                //    movieManipulation.RemoveMovie();
                //    break;
                //case 5:
                //    movieManipulation.FindMovie();
                //    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Enter Valid Option");
                    goto MenuOption;
            }
            Console.ReadLine();
        }
    }
}

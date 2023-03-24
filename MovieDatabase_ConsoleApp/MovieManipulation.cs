using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MovieDatabase_ConsoleApp
{
    public class MovieManipulation
    {
        List<Moviedetails> movieDetailsList = new List<Moviedetails>();
        Moviedetails moviedetails = new Moviedetails();
        public void DisplayMovies()
        {
            foreach (var movie in movieDetailsList)
            {
                Console.WriteLine(movie.MovieId + "-" + movie.MovieName + "-" + movie.MovieGenre);
            }

        }
        public void AddMovie()
        {
        EnterMovieId:
            Console.WriteLine("Enter Movie id: ");
            moviedetails.MovieId = Convert.ToInt32(Console.ReadLine());
            string idvalidationResult = ValidateMovieId(moviedetails.MovieId);
            if (idvalidationResult != "Valid")
            {
                Console.WriteLine(idvalidationResult);
                goto EnterMovieId;
            }
            bool isMovieIdPresent = CheckIfMovieIdPresent(moviedetails.MovieId);
            if (isMovieIdPresent)
            {
                Console.WriteLine("Id Already Exists");
                goto EnterMovieId;
            }
        EnterMovieName:
            Console.WriteLine("Enter Movie Name: ");
            moviedetails.MovieName = Console.ReadLine();
            string movieNamevalidationResult = ValidateMovieName(moviedetails.MovieName);
            if (movieNamevalidationResult != "Valid")
            {
                Console.WriteLine(movieNamevalidationResult);
                goto EnterMovieName;
            }
        EnterMovieGenre:
            Console.WriteLine("Enter Movie Genre: ");
            moviedetails.MovieGenre = Console.ReadLine();
            string movieGenrevalidationResult = ValidateMovieGenre(moviedetails.MovieGenre);
            if (movieGenrevalidationResult != "Valid")
            {
                Console.WriteLine(movieGenrevalidationResult);
                goto EnterMovieGenre;
            }

            if (idvalidationResult == "Valid" && movieNamevalidationResult == "Valid" && movieGenrevalidationResult == "Valid" && isMovieIdPresent == false)
                movieDetailsList.Add(moviedetails);
            Console.WriteLine("Movie added successfully!");

        }             
        private string ValidateMovieId(int movieId)
        {
            if (movieId == 0)
                return "Id Cannot be Blank";
            string movieIdToString = movieId.ToString();
            string IdPattern = "^[0-9]*$";
            if (!Regex.IsMatch(movieIdToString, IdPattern))
            {
                return "Id can only be a number";
            }
            else return "Valid";
        }
        private bool CheckIfMovieIdPresent(int movieId)
        {
            Moviedetails movieToCheck = movieDetailsList.Find(movie => movie.MovieId == movieId);
            if (movieToCheck != null)
                return true;
            else
                return false;
        }
        private string ValidateMovieName(string movieName)
        {
            if (movieName == null || movieName == string.Empty)
                return "Name Cannot be Blank";
            else return "Valid";
        }
        private string ValidateMovieGenre(string movieGenre)
        {
            if (movieGenre == null || movieGenre == string.Empty)
                return "Genre Cannot be Blank";
            string genrePattern = "^[a-zA-Z]*$";
            if (!Regex.IsMatch(movieGenre, genrePattern))
            {
                return "Genre can only be alphabets";
            }
            else return "Valid";
        }
        public void EditMovie()
        {
        GetMovieId:
            Console.WriteLine("Enter id to edit: ");
            moviedetails.MovieId = Convert.ToInt32(Console.ReadLine());
            bool isMoviePresent = CheckIfMovieIdPresent(moviedetails.MovieId);
            if(isMoviePresent)
            {
                Moviedetails movieToEdit = movieDetailsList.Find(movie => movie.MovieId == moviedetails.MovieId);
                Console.WriteLine("What to Edit? \n1.Movie Name \n2.Movie Genre");
                int userChoice;
                userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        UpdateMovieName(movieToEdit);
                        break;
                    case 2:
                        UpdateMovieGenre(movieToEdit);
                        break;

                    default:
                        Console.WriteLine("Enter Valid Option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Item does not exist! Enter Proper Value");
                goto GetMovieId;
            }

        }
        private void UpdateMovieGenre(Moviedetails movieToEdit)
        {
            throw new NotImplementedException();
        }
        private void UpdateMovieName(Moviedetails movieToEdit)
        {

            Console.WriteLine("Current Value =" + movieToEdit.MovieName);
        EnterNewMovieName:
            Console.WriteLine("Enter the new movie name: ");
            moviedetails.MovieName = Console.ReadLine();
            string movieNamevalidationResult = ValidateMovieName(moviedetails.MovieName);
            if (movieNamevalidationResult != "Valid")
            {
                Console.WriteLine(movieNamevalidationResult);
                goto EnterNewMovieName;
            }
            else  
            Console.WriteLine("Movie data entered successfully!");
        }
        public void Removemovie(Moviedetails movie)
        {
            Console.WriteLine("Entermovie id to remove: ");
            movie.MovieId = Convert.ToInt32(Console.ReadLine());
            movieDetailsList.Remove(movie);
            Console.WriteLine("Movie data removed successfully!");
            Console.ReadLine();
        }
    }
}

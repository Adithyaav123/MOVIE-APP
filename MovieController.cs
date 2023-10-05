using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreSerializationClassLibrary.Service;

namespace MovieDeserializationPresentation
{
    internal class MovieController
    {

            private MovieManager manager;

            public MovieController()
            {
                manager = new MovieManager();
            }

            public void Start()
            {
                while (true)
                {
                    DisplayMenu();

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            TryAddMovie();
                            break;

                        case 2:
                            TryDisplayMovies();
                            break;

                        case 3:
                            ClearAll();
                            break;

                        case 4:
                            TryFindMovieByYear();
                            break;

                        case 5:
                            TryRemoveMovieByName();
                            break;

                        case 6:
                            Console.WriteLine("Exiting the application.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
            }

            private void DisplayMenu()
            {
                Console.WriteLine("==========Welcome to Movie Store==========");
                Console.WriteLine("Choose an option from the following:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Display Movies");
                Console.WriteLine("3. Clear All");
                Console.WriteLine("4. Find Movie By Year");
                Console.WriteLine("5. Remove Movie By Name");
                Console.WriteLine("6. Exit ");
                Console.Write("Enter your choice: ");
            }

            private void TryAddMovie()
            {
                try
                {
                    Console.WriteLine("Enter the movie ID:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter movie title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter movie genre: ");
                    string genre = Console.ReadLine();
                    Console.Write("Enter movie year: ");
                    int year = Convert.ToInt32(Console.ReadLine());

                    string addResult = manager.AddMovie(id, title, year, genre);
                    Console.WriteLine(addResult);
                }
                catch (Exception mse)
                {
                    Console.WriteLine(mse.Message);
                }
            }

            private void TryDisplayMovies()
            {
                try
                {
                    string displayResult = manager.DisplayMovies();
                    Console.WriteLine(displayResult);
                }
                catch (Exception mee)
                {
                    Console.WriteLine(mee.Message);
                }
            }

            private void ClearAll()
            {
                string removeAllResult = manager.ClearAll();
                Console.WriteLine(removeAllResult);
            }

            private void TryFindMovieByYear()
            {
                Console.Write("Enter the year to find movies for: ");
                int yearToFind = Convert.ToInt32(Console.ReadLine());
                string findResult = manager.FindMovieByYear(yearToFind);
                Console.WriteLine(findResult);
            }

            private void TryRemoveMovieByName()
            {
                Console.Write("Enter the name of the movie to remove: ");
                string nameToRemove = Console.ReadLine();
                string removeByNameResult = manager.RemoveMovieByName(nameToRemove);
                Console.WriteLine(removeByNameResult);
            }
        }
    }




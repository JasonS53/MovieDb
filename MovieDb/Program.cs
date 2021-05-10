using System;
using System.Linq;

namespace MovieDb
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDB();
            
            using (var context = new MovieDbContext())
            {
                Console.WriteLine(string.Format("{0,-30}{1,-40}", "Title", "Genre"));
                foreach (Movie movie in context.Movies)
                {
                    Console.WriteLine(string.Format("{0,-30}{1,-40}", movie.Title , movie.Genre));
                }
            }

            Console.WriteLine("Would you like to search by title or genre?");
            string choice = Console.ReadLine().ToLower().Trim();
            if (choice == "genre")
            {
                SearchbyGenre();
            }
            else if (choice == "title")
            {
                SearchbyTitle();
            }
            else
            {
                Console.WriteLine("That was an invalid entry");
            }    
        }

        static void SearchbyTitle()
        {
            using (var context = new MovieDbContext())
            {
                Console.WriteLine("Please chose a movie title");
                string input = Console.ReadLine();

                var sts = context.Movies.Where(s => s.Title.Contains(input));
                //Console.WriteLine($"Movie {sts.Title} is {sts.Runtime} minutes long.");
                foreach (Movie movie in context.Movies)
                {
                    Console.WriteLine($"Movie {movie.Title} is {movie.Runtime} minutes long.");
                }
            }
        }

        static void SearchbyGenre()
        {
            Console.WriteLine("Please chose a movie genre");
            string input = Console.ReadLine();
            
            using (var context = new MovieDbContext())
            {
                var sts = context.Movies.Where(s => s.Genre == input).ToList();
                //Console.WriteLine(sts.ToList);                
                foreach (Movie movie in context.Movies)
                {
                    Console.WriteLine($"Movie {movie.Title} is {movie.Runtime} minutes long.");     
                }
            }
        }

        static void CreateDB()
        {
            using (var context = new MovieDbContext())
            {
                Movie m1 = new Movie()
                {
                    Title = "The Fall",
                    Genre = "drama",
                    Runtime = 117
                };

                Movie m2 = new Movie()
                {
                    Title = "Star Wars",
                    Genre = "scifi",
                    Runtime = 121
                };

                Movie m3 = new Movie()
                {
                    Title = "Finding Nemo",
                    Genre = "animated",
                    Runtime = 100
                };

                Movie m4 = new Movie()
                {
                    Title = "Fast and Furious",
                    Genre = "drama",
                    Runtime = 106
                };

                Movie m5 = new Movie()
                {
                    Title = "Pursuit of Happiness",
                    Genre = "drama",
                    Runtime = 93
                };

                Movie m6 = new Movie()
                {
                    Title = "Star Trek",
                    Genre = "scifi",
                    Runtime = 127
                };

                Movie m7 = new Movie()
                {
                    Title = "Up",
                    Genre = "animated",
                    Runtime = 96
                };

                Movie m8 = new Movie()
                {
                    Title = "Saw",
                    Genre = "horror",
                    Runtime = 103
                };

                Movie m9 = new Movie()
                {
                    Title = "Final Destination",
                    Genre = "horror",
                    Runtime = 98
                };

                Movie m10 = new Movie()
                {
                    Title = "Cinderella",
                    Genre = "animated",
                    Runtime = 74
                };

                Movie m11 = new Movie()
                {
                    Title = "Ferris Buellers Day Off",
                    Genre = "comedy",
                    Runtime = 103
                };

                Movie m12 = new Movie()
                {
                    Title = "Marat/Sade",
                    Genre = "drama",
                    Runtime = 116
                };

                Movie m13 = new Movie()
                {
                    Title = "Life of Brian",
                    Genre = "comedy",
                    Runtime = 94
                };

                Movie m14 = new Movie()
                {
                    Title = "Namesake",
                    Genre = "drama",
                    Runtime = 122
                };

                Movie m15 = new Movie()
                {
                    Title = "Noises Off",
                    Genre = "comedy",
                    Runtime = 101
                };

                context.Movies.Add(m1);
                context.Movies.Add(m2);
                context.Movies.Add(m3);
                context.Movies.Add(m4);
                context.Movies.Add(m5);
                context.Movies.Add(m6);
                context.Movies.Add(m7);
                context.Movies.Add(m8);
                context.Movies.Add(m9);
                context.Movies.Add(m10);
                context.Movies.Add(m11);
                context.Movies.Add(m12);
                context.Movies.Add(m13);
                context.Movies.Add(m14);
                context.Movies.Add(m15);
                
                context.SaveChanges();

            }
        }
    }
}

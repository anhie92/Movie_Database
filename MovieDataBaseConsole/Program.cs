using MovieDataBase_Domain;
using MovieDataBase_DTO;
using MovieDataBaseConsole;



MovieObject movieObject = new MovieObject();

//movieObject.BuildMovieCollection();
//movieObject.LoadStartUpData();


Console.WriteLine("Hello, Welcome To the Movie Database.");

while (true)
{
   
    Console.WriteLine("How would you like to search for a movie");
    Console.WriteLine("Press 1 or Title to search by Title");
    Console.WriteLine("Press 2 or Genre to search by Genre");
    Console.WriteLine("Press 3 or all to view all movies");
    Console.WriteLine("Press anything else to exit the movie database");
    string searchChoice = Console.ReadLine();

    if (searchChoice == "1" || searchChoice.ToLower() == "title")
    {
        Console.WriteLine("Please enter a Title");
        string title = Console.ReadLine();
        movieObject.SearchMovieByTitle(title);
    }
    else if (searchChoice == "2" || searchChoice.ToLower() == "genre")
    {
        Console.WriteLine("Please enter a Genre");
        string genre = Console.ReadLine();
        movieObject.SearchMovieByGenre(genre);
    }
    else if(searchChoice =="3"||searchChoice.ToLower() == "all")
    {
        movieObject.DisplayAllMovies();
    }
    else
    {
        Console.WriteLine("Thanks for Viewing the database!");
        break;
    }
    

}

Console.WriteLine("GoodBye!");






using System.ComponentModel.DataAnnotations;

namespace MovieDataBase_DTO;
public class Movie
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string Genre { get; set; }

    public double RunTime { get; set; }

}


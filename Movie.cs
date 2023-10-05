namespace MovieStoreSerializationClassLibrary
{
    [Serializable]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public const int MOVIE_COUNT = 5;

        public Movie(int id, string title, int year, string genre)
        {
            Id = id;
            Title = title;
            Year = year;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"ID: {Id}\nName: {Title}\nYear: {Year}\nGenre: {Genre}";
        }
    }
}



   
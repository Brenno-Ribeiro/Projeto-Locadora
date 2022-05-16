using System;

namespace MovieStore.ViewModels
{
    public class MovieResponseViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }   
        public string Duration { get; set; }       
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public string ImageLink { get; set; }
        public string NameDirector { get; set; }
        public string LastNameDirector { get; set; }
    }
}

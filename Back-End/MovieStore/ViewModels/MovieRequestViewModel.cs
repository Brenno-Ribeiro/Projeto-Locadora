using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.ViewModels
{
    public class MovieRequestViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string AgeGroup { get; set; }
        [Required]
        public string NameDirector { get; set; }
        [Required]
        public string LastNameDirector { get; set; }
    }
}

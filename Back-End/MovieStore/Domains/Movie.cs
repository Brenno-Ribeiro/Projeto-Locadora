using MovieStore.Domains;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Domain
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Duration { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public Image Image { get; set; }


        [ForeignKey("Director")]
        public Guid DirectorId { get; set; }
        public Director Director { get; set; }

    }
}

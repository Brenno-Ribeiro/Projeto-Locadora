using MovieStore.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Domains
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PublicId { get; set; }
        public string SecureUrl { get; set; }


        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Domain
{
    public class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}

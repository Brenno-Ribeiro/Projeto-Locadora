using MovieStore.Domain;
using Microsoft.EntityFrameworkCore;
using MovieStore.Domains;

namespace MovieStore.Context
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Image> images { get; set; }

        public LocadoraContext(DbContextOptions<LocadoraContext> options ): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.HasPostgresExtension("uuid-ossp");

            builder.Entity<Image>(image => 
            {
                image.ToTable("Images");
                image.HasKey(m => m.Id);
                image.Property(d => d.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired().ValueGeneratedOnAdd();
                image.Property(m => m.PublicId).HasColumnType("uuid").IsRequired();
                image.Property(m => m.SecureUrl).HasColumnType("VARCHAR(MAX)").IsRequired();

                image.HasOne(m => m.Movie)
               .WithOne(m => m.Image)
               .HasConstraintName("FK_Id_Movie");
            });


            builder.Entity<Movie>(movie => 
            {
                movie.ToTable("Movies");
                movie.HasKey(m => m.Id);
                movie.Property(d => d.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired().ValueGeneratedOnAdd();
                movie.Property(m => m.Title).HasColumnType("VARCHAR(50)").IsRequired();
                movie.Property(m => m.ReleaseYear).HasColumnType("INT").IsRequired();
                movie.Property(m => m.AgeGroup).HasColumnType("CHAR(2)").IsRequired();
                movie.Property(m => m.Duration).HasColumnType("VARCHAR(10)").IsRequired();
                movie.Property(m => m.Gender).HasColumnType("VARCHAR(20)").IsRequired();
                movie.Property(m => m.DirectorId).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()");

                movie.HasOne(m => m.Director)
                .WithMany(m => m.Movies)
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.DirectorId)
                .HasConstraintName("FK_Id_Director")
                .OnDelete(DeleteBehavior.Cascade);

                movie.HasIndex(m => m.Id);

            });

            builder.Entity<Director>(director => 
            {
                director.ToTable("Directors");
                director.HasKey(d => d.Id);
                director.Property(d => d.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired().ValueGeneratedOnAdd();
                director.Property(d => d.Name).HasColumnType("VARCHAR(30)").IsRequired();
                director.Property(d => d.LastName).HasColumnType("VARCHAR(30)").IsRequired();
                director.HasIndex(d => d.Id); 
            });
        }
    }
}

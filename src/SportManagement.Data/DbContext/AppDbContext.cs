using Microsoft.EntityFrameworkCore;
using SportManagement.Domain.Entities;
using SportManagement.Domain.Enums;
using System.Reflection;

namespace SportManagement.Data.DbContexts
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Score> Scores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany()
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany()
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().HasData(
                 new Team { Id = 1, TeamName = "Manchester City", Coach = "Zuc" },
                 new Team { Id = 2, TeamName = "Liverpool", Coach = "Abbos" }
             );

            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Van", Age = 25, TeamId = 1, PhotoPath = "van.jpg" },
                new Player { Id = 2, Name = "Rinku", Age = 22, TeamId = 1, PhotoPath = "rinku.jpg" },
                new Player { Id = 3, Name = "Abbos", Age = 28, TeamId = 2, PhotoPath = "abbos.jpg" },
                new Player { Id = 4, Name = "Zuc", Age = 24, TeamId = 2, PhotoPath = "zuc.jpg" }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match { Id = 1, Team1Id = 1, Team2Id = 2, MatchDate = new DateTime(2024, 03, 28, 12, 00, 00), Result = MatchResult.Draw }
            );

            modelBuilder.Entity<Score>().HasData(
                new Score { Id = 1, MatchId = 1, PlayerId = 1, Points = 10 },
                new Score { Id = 2, MatchId = 1, PlayerId = 3, Points = 12 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "zucc", Email = "zuc@gmail.com", Password = "admin123", Role = Role.Admin },
                new User { Id = 2, UserName = "abbos", Email = "abbos@gmail.com", Password = "user123", Role = Role.User }
            );

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);


        }

    }

}

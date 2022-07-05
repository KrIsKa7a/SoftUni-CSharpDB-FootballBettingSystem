namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class FootballBettingContext : DbContext
    {
        //Testing
        public FootballBettingContext()
        {
            
        }

        //Judge
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        //Establish a connection to the SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //True -> Connection string is already set
            //False -> Connection string isn't set
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }

            optionsBuilder.UseLazyLoadingProxies();
        }

        //Define rules for creating db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            //Composite PK of mapping entity
            modelBuilder
                .Entity<PlayerStatistic>(e =>
                {
                    //Configuration for the current Entity (PlayerStatistics)
                    //Define PK
                    e.HasKey(ps => new { ps.PlayerId, ps.GameId });
                });

            modelBuilder
                .Entity<Team>(e =>
                {
                    e
                        .HasOne(t => t.PrimaryKitColor)
                        .WithMany(c => c.PrimaryKitTeams)
                        .HasForeignKey(t => t.PrimaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);

                    e
                        .HasOne(t => t.SecondaryKitColor)
                        .WithMany(c => c.SecondaryKitTeams)
                        .HasForeignKey(t => t.SecondaryKitColorId)
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder
                .Entity<Game>(e =>
                {
                    e
                        .HasOne(g => g.HomeTeam)
                        .WithMany(t => t.HomeGames)
                        .HasForeignKey(g => g.HomeTeamId)
                        .OnDelete(DeleteBehavior.NoAction);

                    e
                        .HasOne(g => g.AwayTeam)
                        .WithMany(t => t.AwayGames)
                        .HasForeignKey(g => g.AwayTeamId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        }

        //private void DiscoverDbSets()
        //{
        //    Assembly assembly = Assembly.GetAssembly(typeof(Player));
        //    Type[] entities = assembly
        //        .GetTypes();

        //    Type dbContext = this
        //        .GetType();
        //    foreach (Type entity in entities)
        //    {
        //        object dbSet = typeof(DbSet<>)
        //            .MakeGenericType(entity);

                
        //    }
        //}
    }
}

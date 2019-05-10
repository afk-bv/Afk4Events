using Afk4Events.Data.Entities.Events;
using Afk4Events.Data.Entities.Groups;
using Afk4Events.Data.Entities.Themes;
using Afk4Events.Data.Entities.UserAvailabilities;
using Afk4Events.Data.Entities.UserGroups;
using Afk4Events.Data.Entities.Users;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Afk4Events.Data
{
	public class Afk4EventsContext : DbContext, IDataProtectionKeyContext
	{
		public Afk4EventsContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<EventDate> EventDates { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Theme> Themes { get; set; }
		public DbSet<UserGroup> UserGroups { get; set; }
		public DbSet<UserAvailability> UserAvailabilities { get; set; }
		public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
#if DEBUG
			optionsBuilder.EnableSensitiveDataLogging();
#endif
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserGroup>().HasOne(x => x.User).WithMany(x => x.Groups).HasForeignKey(x => x.UserId);
			modelBuilder.Entity<UserGroup>().HasOne(x => x.Group).WithMany(x => x.Users).HasForeignKey(x => x.GroupId);
			modelBuilder.Entity<UserAvailability>().HasKey(x => new {x.UserId, x.EventDateId});
			modelBuilder.Entity<UserGroup>().HasKey(x => new {x.UserId, x.GroupId});
			modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
			modelBuilder.Entity<User>().HasIndex(x => x.GoogleId).IsUnique();
			modelBuilder.Entity<Event>().HasOne(x => x.PickedDate);
			modelBuilder.Entity<Event>().HasMany(x => x.EventDates).WithOne(x => x.Event).HasForeignKey(x => x.EventId);
		}
	}

	/// <summary>
	///   Used by EF to create model without API project
	/// </summary>
	public class ContextFactory : IDesignTimeDbContextFactory<Afk4EventsContext>
	{
		public Afk4EventsContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<Afk4EventsContext>();
			optionsBuilder.UseNpgsql("Host=localhost;Port=21337;Database=afk4events;Username=development;Password=development");

			return new Afk4EventsContext(optionsBuilder.Options);
		}
	}
}

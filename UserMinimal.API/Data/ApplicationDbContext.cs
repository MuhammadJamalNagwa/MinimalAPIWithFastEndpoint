using Microsoft.EntityFrameworkCore;
using UserMinimal.API.Data.Converters;
using UserMinimal.API.Models;
using UserMinimal.API.Models.Common;

namespace UserMinimal.API.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<EmailAddress>()
                            .HaveConversion<EmailAddressConverter>();

        configurationBuilder.Properties<Name>()
                            .HaveConversion<NameConverter>();

        configurationBuilder.Properties<UserId>()
                            .HaveConversion<UserIdConverter>();

        configurationBuilder.Properties<DateOfBirth>()
                            .HaveConversion<DateOfBirthConverter>();
    }
}

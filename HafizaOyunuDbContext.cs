using Microsoft.EntityFrameworkCore;

public class HafizaOyunuDbContext : DbContext
{
    public DbSet<Kullanici> Kullanicilar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("name=HafizaOyunuDb");
    }
}

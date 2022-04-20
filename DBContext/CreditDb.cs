using Microsoft.EntityFrameworkCore;
public class CreditDB : DbContext {

    public CreditDB(DbContextOptions<CreditDB> options): base(options) {

    }

    public DbSet<Credit> Credits => Set<Credit>();
}
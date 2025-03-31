using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;
using Microsoft.EntityFrameworkCore;


namespace loja_api.infra.Context;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Cupom> Cupom { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Storage> Storage { get; set; }
    public DbSet<Paymant> Paymant { get; set; }
    //para fazer a chamada do banco de dados

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cupom>()
            .OwnsOne(c => c.Auditable);

        // Configuração da entidade Employee com Auditable
        modelBuilder.Entity<Employee>()
            .OwnsOne(e => e.Auditable);

        // Configuração da relação entre MarketCart e User
        modelBuilder.Entity<Paymant>()
            .HasOne(m => m.User)
            .WithMany(u => u.Paymant)
            .HasForeignKey(m => m.IdUser);

        // Configuração da relação entre MarketCart e Cupom
        modelBuilder.Entity<Paymant>()
            .HasOne(m => m.Cupom)
            .WithOne()
            .HasForeignKey<Paymant>(m => m.CupomId);

        // Configuração de Products com Auditable
        modelBuilder.Entity<Products>()
            .OwnsOne(m => m.Auditable);

        //Declarando classe intermediaria
        modelBuilder.Entity<ProductsPaymant>()
        .HasKey(mp => new { mp.MarketCartId, mp.IdProducts });

        modelBuilder.Entity<ProductsPaymant>()
            .HasOne(mp => mp.Paymant)
            .WithMany(m => m.ProductsPaymant)
            .HasForeignKey(mp => mp.MarketCartId);

        modelBuilder.Entity<ProductsPaymant>()
            .HasOne(mp => mp.Products)
            .WithMany(p => p.ProductsPaymant)
            .HasForeignKey(mp => mp.IdProducts);

        // Configuração de Storage e Products
        modelBuilder.Entity<Storage>()
            .HasOne(s => s.Products)
            .WithMany(p => p.Storages)
            .HasForeignKey(s => s.IdProducts);

        // Configuração de Auditable no Storage
        modelBuilder.Entity<Storage>()
            .OwnsOne(s => s.Auditable);

        modelBuilder.Entity<Paymant>()
            .OwnsOne(m => m.AttDate);

        base.OnModelCreating(modelBuilder);
    }
}

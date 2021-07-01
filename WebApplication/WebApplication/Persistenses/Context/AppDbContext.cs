using System;
using Microsoft.EntityFrameworkCore;
using WebApplication.Dominio.Modelos;

namespace WebApplication.Persistenses.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Companhia> Companhia { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        
        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=postgres; password=postgres; database=ecommerce2;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Companhia>().ToTable("Companhia");
            builder.Entity<Companhia>().HasKey(p => p.Id);
            builder.Entity<Companhia>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Companhia>().Property(p => p.NomeFantasia).IsRequired().HasMaxLength(30);
            builder.Entity<Companhia>().Property(p => p.RazaoSocial).IsRequired().HasMaxLength(30);
            builder.Entity<Companhia>().Property(p => p.Cnpj).IsRequired().HasMaxLength(14);
            builder.Entity<Companhia>().HasAlternateKey(p => p.Cnpj);
            builder.Entity<Companhia>().HasMany(p => p.Produtos).WithOne(p => p.Companhia)
                .HasForeignKey(p => p.CompanhiaId);

           
            builder.Entity<Produto>().ToTable("Produto");
            builder.Entity<Produto>().HasKey(p => p.Id);
            builder.Entity<Produto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Produto>().Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Entity<Produto>().Property(p => p.Valor).IsRequired();
            builder.Entity<Produto>().Property(p => p.Observacao).IsRequired().HasMaxLength(200);
            builder.Entity<Produto>().Property(p => p.CompanhiaId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Produto>().HasOne(p => p.Companhia).WithMany(p => p.Produtos)
                .HasForeignKey(p => p.CompanhiaId).IsRequired().OnDelete(DeleteBehavior.Cascade);
           
           
            builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<Usuario>().HasKey(p => p.Id);
            builder.Entity<Usuario>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().Property(p => p.Cpf).IsRequired().HasMaxLength(11);
            builder.Entity<Usuario>().HasAlternateKey(p => p.Cpf);
            builder.Entity<Usuario>().Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Entity<Usuario>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Usuario>().HasAlternateKey(p => p.Email);
            builder.Entity<Usuario>().Property(p => p.Password).IsRequired().HasMaxLength(50);
            builder.Entity<Usuario>().HasMany(p => p.Compra).WithOne(p => p.Usuario).HasForeignKey(p => p.UsuarioId);
            
            builder.Entity<Compra>().ToTable("Compra");
            builder.Entity<Compra>().HasKey(p => p.Id);
            builder.Entity<Compra>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Compra>().Property(p => p.Date).IsRequired().HasDefaultValueSql("now()");
            builder.Entity<Compra>().Property(p => p.Valor).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Compra>().Property(p => p.FormaPagamento).IsRequired();
            builder.Entity<Compra>().Property(p => p.Status).IsRequired();
            builder.Entity<Compra>().Property(p => p.Observacao).IsRequired().HasMaxLength(250);
            builder.Entity<Compra>().Property(p => p.Cep).IsRequired().HasMaxLength(50);
            builder.Entity<Compra>().Property(p => p.Endereco).IsRequired().HasMaxLength(150 );
            builder.Entity<Compra>().HasMany<Item>(p => p.Items).WithOne(p => p.Compra)
                .HasForeignKey(p => p.CompraId).OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(p => new {p.CompraId, p.ProdutoId});
            builder.Entity<Item>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p => p.Quantidade).IsRequired().HasDefaultValue(0);
        }

    }
}

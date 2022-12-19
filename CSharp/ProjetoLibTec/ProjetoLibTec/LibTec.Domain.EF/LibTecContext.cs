using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Domain.EF
{
    public partial class LibTecContexto : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<TipoStatusReserva> TipoStatusReservas { get; set; } = null!;
        public DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Autor> Autores { get; set; } = null!;
        public DbSet<Emprestimo> Emprestimos { get; set; } = null!;
        public DbSet<TipoItem> TipoItens { get; set; } = null!;
        public DbSet<TipoStatusEmprestimo> TipoStatusEmprestimos { get; set; } = null!;
        public DbSet<Item> Itens { get; set; } = null!;
        public DbSet<AutorPorItem> AutorPorItens { get; set; } = null!;


        public LibTecContexto() : base()
        { }

        public LibTecContexto(DbContextOptions<LibTecContexto> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aqui ficava a Connection StrinSg.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AutorPorItem>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoItem>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoStatusEmprestimo>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoStatusReserva>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

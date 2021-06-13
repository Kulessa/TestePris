using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CristianKulessa.Locadora.BackOffice.WebApi.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Imovel> Imovel { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Bairro)
                    .HasForeignKey(d => d.CidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bairro_Cidade");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ufid).HasColumnName("UFId");

                entity.HasOne(d => d.Uf)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.Ufid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidade_UF");
            });

            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.Property(e => e.Area).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP")
                    .HasDefaultValueSql("('00000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Condominio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Dormitorios).HasDefaultValueSql("((1))");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ufid).HasColumnName("UFId");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(19, 2)")
                    .HasComputedColumnSql("([Valor]+[Condominio])", false);

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Imovel)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Imovel_Tipo");

                entity.HasOne(d => d.Uf)
                    .WithMany(p => p.Imovel)
                    .HasForeignKey(d => d.Ufid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Imovel_UF");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.ToTable("UF");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

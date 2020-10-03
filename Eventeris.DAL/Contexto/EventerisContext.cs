using System;
using Eventeris.DAL;
using Eventeris.DAL.Entidade;
using Eventeris.DAL.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Eventeris.DAL.Contexto
{
    public partial class EventerisContext : DbContext
    {
        public EventerisContext()
        {
        }

        public EventerisContext(DbContextOptions<EventerisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaEvento> CategoriaEvento { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Participacao> Participacao { get; set; }
        public virtual DbSet<StatusEvento> StatusEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=INOTE747\\SQLEXPRESS;Database=Eventeris;Trusted_Connection=True");
                optionsBuilder.UseSqlServer("Server=INOTE749\\SQLEXPRESS;Database=Eventeris;Trusted_Connection=True");
                //optionsBuilder.UseSqlServer("Server=DESKTOP-RPP8MN6\\SQLEXPRESS;Database=Eventeris;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaEvento>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaEvento);

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.Property(e => e.DataHoraFim).HasColumnType("datetime");

                entity.Property(e => e.DataHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaEventoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdCategoriaEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_CategoriaEvento");

                entity.HasOne(d => d.IdEventoStatusNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdEventoStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_EventoStatus");
            });

            modelBuilder.Entity<Participacao>(entity =>
            {
                entity.HasKey(e => e.IdParticipacao);

                entity.Property(e => e.Comentario)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LoginParticipante)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Participacao)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participacao_Evento");
            });

            modelBuilder.Entity<StatusEvento>(entity =>
            {
                entity.HasKey(e => e.IdEventoStatus);

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

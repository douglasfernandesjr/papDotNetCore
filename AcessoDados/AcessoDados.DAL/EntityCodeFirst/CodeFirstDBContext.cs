using AcessoDados.DAL.EntityCodeFirst.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados.DAL.EntityCodeFirst
{
	public class CodeFirstDBContext : DbContext
	{
		public CodeFirstDBContext()
		{
		}

		public CodeFirstDBContext(DbContextOptions<CodeFirstDBContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=youvideos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			}
		}

		public virtual DbSet<Categoria> Categoria { get; set; }
		public virtual DbSet<Video> Video { get; set; }
		public virtual DbSet<Responsavel> Responsavel { get; set; }
		public virtual DbSet<VideoCategoria> VideoCategoria { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Responsavel>(entity =>
			{
				entity.Property(x => x.Nome).IsUnicode(false);
			});


			modelBuilder.Entity<Categoria>(entity =>
			{
				entity.Property(x => x.Nome).IsUnicode(false);
			});

			modelBuilder.Entity<Video>(entity =>
			{
				entity.Property(x => x.Titulo).IsUnicode(false);
				entity.Property(x => x.Titulo).IsUnicode(false);

				entity.HasIndex(x => x.IdadeMinima).HasName("IX_VIDEO_IDADE");

				entity.HasOne(x => x.Responsavel)
					.WithMany(y => y.Videos)
					.HasForeignKey(x => x.IdResponsavel)
					.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<VideoCategoria>(entity =>
			{
				entity.HasOne(x => x.Video)
					.WithMany(y => y.VideoCategorias)
					.HasForeignKey(x => x.IdVideo)
					.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Categoria)
					.WithMany(y => y.VideoCategorias)
					.HasForeignKey(x => x.IdCategoria)
					.OnDelete(DeleteBehavior.Restrict);


			});
		}
	}
}

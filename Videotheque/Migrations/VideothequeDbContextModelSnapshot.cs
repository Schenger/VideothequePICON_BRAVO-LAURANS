﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Videotheque.DataAccess;

namespace Videotheque.Migrations
{
    [DbContext(typeof(VideothequeDbContext))]
    partial class VideothequeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("Videotheque.Models.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgeMinimum");

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("DateSortie");

                    b.Property<TimeSpan>("Duree");

                    b.Property<int>("IdMedia");

                    b.Property<string>("Nom");

                    b.Property<int>("Note");

                    b.Property<int>("Numero");

                    b.Property<int>("Saison");

                    b.Property<int>("Statut");

                    b.Property<string>("Synopsis");

                    b.HasKey("Id");

                    b.HasIndex("IdMedia");

                    b.ToTable("Episode");
                });

            modelBuilder.Entity("Videotheque.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Videotheque.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgeMinimum");

                    b.Property<bool>("AudioDescription");

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("DateCreation");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("LangueMedia");

                    b.Property<int>("LangueVO");

                    b.Property<int>("Note");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("SousTitre");

                    b.Property<int>("Statut");

                    b.Property<bool>("SupportNumerique");

                    b.Property<bool>("SupportPhysique");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Titre");

                    b.HasKey("Id");

                    b.ToTable("Media");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");
                });

            modelBuilder.Entity("Videotheque.Models.MediaGenre", b =>
                {
                    b.Property<int>("IdMedia");

                    b.Property<int>("IdGenre");

                    b.HasKey("IdMedia", "IdGenre");

                    b.HasIndex("IdGenre");

                    b.ToTable("MediaGenre");
                });

            modelBuilder.Entity("Videotheque.Models.MediaPersonne", b =>
                {
                    b.Property<int>("IdMedia");

                    b.Property<int>("IdPersonne");

                    b.Property<string>("Fonction");

                    b.Property<string>("Role");

                    b.HasKey("IdMedia", "IdPersonne");

                    b.HasIndex("IdPersonne");

                    b.ToTable("MediaPersonne");
                });

            modelBuilder.Entity("Videotheque.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Civilite");

                    b.Property<bool>("EstAmi");

                    b.Property<int>("Nationalite");

                    b.Property<string>("Nom");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Prenom");

                    b.HasKey("Id");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("Videotheque.Models.Pret", b =>
                {
                    b.Property<int>("IdMedia");

                    b.Property<int>("IdPersonne");

                    b.Property<DateTime>("DatePret");

                    b.Property<DateTime>("DateRetour");

                    b.HasKey("IdMedia", "IdPersonne");

                    b.HasIndex("IdMedia")
                        .IsUnique();

                    b.HasIndex("IdPersonne");

                    b.ToTable("Pret");
                });

            modelBuilder.Entity("Videotheque.Models.Film", b =>
                {
                    b.HasBaseType("Videotheque.Models.Media");

                    b.Property<TimeSpan>("Duree");

                    b.HasDiscriminator().HasValue("Film");
                });

            modelBuilder.Entity("Videotheque.Models.Serie", b =>
                {
                    b.HasBaseType("Videotheque.Models.Media");

                    b.Property<int>("Duree")
                        .HasColumnName("Serie_Duree");

                    b.Property<int>("NbSaison");

                    b.HasDiscriminator().HasValue("Serie");
                });

            modelBuilder.Entity("Videotheque.Models.Episode", b =>
                {
                    b.HasOne("Videotheque.Models.Serie", "Media")
                        .WithMany("Episodes")
                        .HasForeignKey("IdMedia")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Videotheque.Models.MediaGenre", b =>
                {
                    b.HasOne("Videotheque.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Videotheque.Models.Media", "Media")
                        .WithMany("MediaGenres")
                        .HasForeignKey("IdMedia")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Videotheque.Models.MediaPersonne", b =>
                {
                    b.HasOne("Videotheque.Models.Media", "Media")
                        .WithMany("MediaPersonnes")
                        .HasForeignKey("IdMedia")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Videotheque.Models.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("IdPersonne")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Videotheque.Models.Pret", b =>
                {
                    b.HasOne("Videotheque.Models.Media", "Media")
                        .WithOne("Pret")
                        .HasForeignKey("Videotheque.Models.Pret", "IdMedia")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Videotheque.Models.Personne", "Personne")
                        .WithMany()
                        .HasForeignKey("IdPersonne")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Dossier> Dossiers { get; set; }
        public virtual DbSet<Hospitalisation> Hospitalisations { get; set; }
        public virtual DbSet<Hospitaliser> Hospitalisers { get; set; }
        public virtual DbSet<Medecin> Medecins { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<RendezVous> RendezVous { get; set; }
        public virtual DbSet<SecretaireInfirmiere> SecretaireInfirmieres { get; set; }

        public virtual DbSet<SecretairePatient> SecretairePatients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Dossier
            modelBuilder.Entity<Dossier>()
                .HasMany(a => a.RendezVous)
                .WithOne(x => x.Dossier)
                .HasForeignKey(x => x.DossierId);

            modelBuilder.Entity<Dossier>()
                .HasMany(x => x.Notes)
                .WithOne(x => x.Dossier)
                .HasForeignKey(x => x.DossierId);

            modelBuilder.Entity<Dossier>()
                .HasOne(x => x.Patient)
                .WithOne(x => x.Dossier)
                .HasForeignKey<Dossier>(x => x.PatientId);
            #endregion

            #region Note
            modelBuilder.Entity<Note>()
               .HasOne(x => x.Dossier)
               .WithMany(x => x.Notes)
               .HasForeignKey(x => x.DossierId);
            #endregion

            #region Rendez-Vous
            modelBuilder.Entity<RendezVous>()
               .HasOne(x => x.Dossier)
               .WithMany(x => x.RendezVous)
               .HasForeignKey(x => x.DossierId);
            #endregion

            #region Patient
            modelBuilder.Entity<Patient>()
                .HasOne(x => x.Dossier)
                .WithOne(x => x.Patient)
                .HasForeignKey<Patient>(x => x.DossierId);

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Hospitalisations)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);
            #endregion

            #region Hospitalisation
            modelBuilder.Entity<Hospitalisation>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Hospitalisations)
                .HasForeignKey(x => x.PatientId);

            modelBuilder.Entity<Hospitalisation>()
                .HasMany(x => x.Hospitalisers)
                .WithOne(x => x.Hospitalisation)
                .HasForeignKey(x => x.HospitalisationId);
            #endregion

            modelBuilder.Entity<Medecin>()
                .HasMany(x => x.Hospitalisers)
                .WithOne(x => x.Medecin)
                .HasForeignKey(x => x.MedecinId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

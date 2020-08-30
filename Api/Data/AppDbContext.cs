using System;
using Microsoft.EntityFrameworkCore;
using Reservatio.Models;

namespace Reservatio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public AppDbContext()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            #region Address Map
            modelBuilder.Entity<Address>(address =>
            {
                address.HasKey(a => a.Id);
                address.Property(a => a.Id).ValueGeneratedOnAdd();

                address.Property(a => a.Cep)
                    .IsRequired()
                    .HasMaxLength(8);

                address.Property(a => a.District)
                    .HasMaxLength(200);

                address.Property(a => a.Street)
                    .HasMaxLength(200);

                address.Property(a => a.Complement)
                    .HasMaxLength(400);

                address.Property(a => a.PersonId)
                    .IsRequired(false);
                address.HasOne(a => a.Person)
                    .WithMany(np => np.Addresses)
                    .HasForeignKey(a => a.PersonId);

                address.HasOne(a => a.City)
                    .WithMany(c => c.Addresses)
                    .HasForeignKey(a => a.CityId);
            });
            #endregion

            #region City Map
            modelBuilder.Entity<City>(city =>
            {
                city.HasKey(c => c.Id);
                city.Property(c => c.Id).ValueGeneratedOnAdd();

                city.Property(c => c.Code)
                    .IsRequired();
                city.HasIndex(c => c.Code)
                    .IsUnique();

                city.Property(s => s.StateAbbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                city.Property(c => c.Name)
                    .IsRequired();

                city.HasMany(c => c.Addresses)
                    .WithOne(a => a.City)
                    .HasForeignKey(a => a.CityId);
            });
            #endregion

            #region Event Map
            modelBuilder.Entity<Event>(_event =>
            {
                _event.HasKey(e => e.Id);
                _event.Property(e => e.Id).ValueGeneratedOnAdd();

                _event.Property(e => e.Date)
                    .IsRequired();

                _event.HasOne(e => e.PaymentMethod)
                    .WithMany(pm => pm.Events)
                    .HasForeignKey(e => e.PaymentMethodId);

                _event.Property(e => e.PlaceId)
                    .IsRequired(false);
                _event.HasOne(e => e.Place)
                    .WithMany(a => a.Events)
                    .HasForeignKey(e => e.PlaceId);

                _event.HasMany(np => np.NaturalPersonEvents)
                    .WithOne(npe => npe.Event)
                    .HasForeignKey(npe => npe.EventId);
            });
            #endregion

            #region Natural Person Map
            modelBuilder.Entity<NaturalPerson>(naturalPerson =>
            {
                naturalPerson.HasKey(np => np.Id);
                naturalPerson.Property(np => np.Id).ValueGeneratedOnAdd();

                naturalPerson.HasIndex(np => np.Cpf)
                    .IsUnique();
                naturalPerson.Property(np => np.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

                naturalPerson.HasIndex(np => np.UserId)
                    .IsUnique();
                naturalPerson.Property(np => np.UserId)
                    .IsRequired();

                naturalPerson.Property(np => np.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                naturalPerson.Property(np => np.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                naturalPerson.Property(np => np.Phone)
                    .HasMaxLength(20);

                naturalPerson.Property(np => np.SecondaryPhone)
                    .HasMaxLength(20);

                naturalPerson.HasMany(np => np.NaturalPersonEvents)
                    .WithOne(npe => npe.Person)
                    .HasForeignKey(npe => npe.PersonId);

                naturalPerson.HasMany(np => np.Addresses)
                    .WithOne(a => a.Person)
                    .HasForeignKey(a => a.PersonId);
            });
            #endregion

            #region Natural Person Event Map
            modelBuilder.Entity<NaturalPersonEvent>(naturalPersonEvent =>
            {
                naturalPersonEvent.HasKey(np => np.Id);
                naturalPersonEvent.Property(np => np.Id).ValueGeneratedOnAdd();

                naturalPersonEvent.Property(np => np.Role)
                    .IsRequired();
            });
            #endregion

            #region Payment Method Map
            modelBuilder.Entity<PaymentMethod>(paymentMethod =>
            {
                paymentMethod.HasKey(pm => pm.Id);
                paymentMethod.Property(pm => pm.Id).ValueGeneratedOnAdd();

                paymentMethod.Property(pm => pm.TotalValue)
                    .IsRequired();

                paymentMethod.Property(pm => pm.NumberInstallments)
                    .IsRequired()
                    .HasDefaultValue(1);

                paymentMethod.Property(pm => pm.ValueReceived)
                    .IsRequired();

                paymentMethod.Property(pm => pm.PaymentType)
                    .IsRequired()
                    .HasConversion(
                        pmt => pmt.ToString(),
                        pmt => (PaymentMethodType)Enum.Parse(typeof(PaymentMethodType), pmt)
                    );
            });
            #endregion

            #region State Map
            modelBuilder.Entity<State>(state =>
            {
                state.HasKey(s => s.Id);
                state.Property(s => s.Id).ValueGeneratedOnAdd();

                state.Property(s => s.StateAbbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();
                state.HasIndex(s => s.StateAbbreviation)
                    .IsUnique();

                state.Property(s => s.Name)
                    .IsRequired();

                state.Property(s => s.Region)
                    .IsRequired()
                    .HasConversion(
                        r => r.ToString(),
                        r => (Region)Enum.Parse(typeof(Region), r)
                    );

                state.HasMany(s => s.Cities)
                    .WithOne(c => c.State)
                    .HasForeignKey(c => c.StateId);

                state.HasMany(s => s.Addresses)
                    .WithOne(c => c.State)
                    .HasForeignKey(c => c.StateId)
                    .OnDelete(DeleteBehavior.NoAction);

            });
            #endregion
        }
    }
}

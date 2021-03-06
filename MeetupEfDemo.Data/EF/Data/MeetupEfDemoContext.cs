﻿using MeetupEfDemo.Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetupEfDemo.Data.EF.Data
{
    public class MeetupEfDemoContext : DbContext
    {
        public MeetupEfDemoContext(DbContextOptions<MeetupEfDemoContext> options)
            : base(options)
        { }

        public DbSet<MeetupEvent> MeetupEvents { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EventAttendance> EventAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Describes MeetupEvent table.
            modelBuilder.Entity<MeetupEvent>(entity =>
            {
                // Custom column name in database.
                entity.Property(e => e.Id).HasColumnName("ID");

                // Specify database data type.
                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(100);

                // Specify event's one-to-many relationship with attendance entity.
                entity.HasMany(e => e.EventAttendance)
                    .WithOne(ea => ea.MeetupEvent);
            });

            // Describes Person table.
            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                // TODO : Add a unique index to email for demo
                //entity.HasIndex(e => e.Email)
                //    .HasName("UQ_Person_Email")
                //    .IsUnique();
            });

            // Describes EventAttendance table.
            modelBuilder.Entity<EventAttendance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                // TODO : Demonstrate composite key with migration
                //entity.HasKey(e => new { e.PersonId, e.MeetupEventId });

                // Describe one-to-many relationship between person and attendance.
                entity.HasOne(e => e.Person)
                    .WithMany(p => p.EventAttendance)
                    .HasForeignKey(e => e.PersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EventAttendance_PersonId");

                // Describe one-to-many relationship between event and attendance.
                entity.HasOne(e => e.MeetupEvent)
                    .WithMany(me => me.EventAttendance)
                    .HasForeignKey(e => e.MeetupEventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EventAttendance_MeetupEventId");
            });

            // TODO : Seed user data for demo
            //modelBuilder.Entity<Person>()
            //    .HasData(
            //        new Person
            //        {
            //            Id = 1,
            //            Name = "Ben",
            //            Email = "ben@test.com"
            //        },
            //        new Person
            //        {
            //            Id = 2,
            //            Name = "Bill",
            //            // TODO : Fix email clash for demo
            //            Email = "ben@test.com"
            //        },
            //        new Person
            //        {
            //            Id = 3,
            //            Name = "Fred",
            //            Email = "fred@test.com"
            //        },
            //        new Person
            //        {
            //            Id = 4,
            //            Name = "Theodore",
            //            Email = "theodore@test.com"
            //        },
            //        new Person
            //        {
            //            Id = 5,
            //            Name = "Steve",
            //            Email = "steve@test.com"
            //        }
            //    );
        }
    }
}

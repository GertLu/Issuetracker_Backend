using System;
using Microsoft.EntityFrameworkCore;
using Issuetracker_Backend.Model;

namespace Issuetracker_Backend.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<RecordData> Records { get; set; }
        public DbSet<LabelData> Labels { get; set; }
        public DbSet<RecordStateData> RecordStates { get; set; }
        public DbSet<TableData> Tables { get; set; }
        public DbSet<TableStateData> TableStates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecordStateData>().HasKey(x => new { x.RecordId, x.StateId });
            modelBuilder.Entity<RecordData>().Property(p => p.Id).HasIdentityOptions(startValue: 4);
            modelBuilder.Entity<LabelData>().Property(p => p.Id).HasIdentityOptions(startValue: 3);
            modelBuilder.Entity<TableData>().Property(p => p.Id).HasIdentityOptions(startValue: 2);
            modelBuilder.Entity<TableStateData>().Property(p => p.Id).HasIdentityOptions(startValue: 4);
            modelBuilder.Entity<RecordData>().HasData(new RecordData
            {
                Id = "1",
                Title = "Record1",
                Description = "Kirjeldus1",
                StateId = "1",
                DueDate = new DateTime(2021, 6, 1, 7, 47, 0),
                TableId = "1",
            }, new RecordData
            {
                Id = "2",
                Title = "Record2",
                Description = "Kirjeldus2",
                StateId = "2",
                DueDate = new DateTime(2021, 3, 5, 7, 47, 0),
                TableId = "1",
            }, new RecordData
            {
                Id = "3",
                Title = "Record3",
                Description = "Kirjeldus3",
                StateId = "3",
                DueDate = new DateTime(2021, 3, 2, 20, 40, 0),
                TableId = "1",
            });
            modelBuilder.Entity<LabelData>().HasData(
               new LabelData
               {
                   Id = "1",
                   Name = "Label1",
                   RecordId = "1",
                   ColorId = "1",
               },
            new LabelData
            {
                Id = "2",
                Name = "Label1",
                RecordId = "2",
                ColorId = "1",
            });

            modelBuilder.Entity<RecordStateData>().HasData(
            new RecordStateData
            {
                StateId = "1",
                RecordId = "1",
                DateStarted = DateTime.Now,
                DateFinished = DateTime.Now,
            },
               new RecordStateData
               {
                   StateId = "2",
                   RecordId = "2",
                   DateStarted = DateTime.Now,
                   DateFinished = DateTime.Now,
               },
               new RecordStateData
               {
                   StateId = "3",
                   RecordId = "3",
                   DateStarted = DateTime.Now,
                   DateFinished = DateTime.Now,
               });
            modelBuilder.Entity<TableData>().HasData(
               new TableData
               {
                   Id = "1",
                   Name = "Tabel 1",
                   Description = "tabel1",
               });

            modelBuilder.Entity<TableStateData>().HasData(
             new TableStateData
            {
                Id = "1",
                Name = "Waiting List",
                TableId = "1",
                FinalState = false,
            },
            new TableStateData
            {
                Id = "2",
                Name = "In Progress",
                TableId = "1",
                FinalState = false,
            },
            new TableStateData
            {
                Id = "3",
                Name = "Finished",
                TableId = "1",
                FinalState = true,
            });

        }

    }
}

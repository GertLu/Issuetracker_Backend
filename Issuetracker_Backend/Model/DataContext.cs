using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Issuetracker_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WorkoutApplication.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<RecordData> Records { get; set; }
        public DbSet<LabelData> Labels { get; set; }
        public DbSet<StateData> States { get; set; }
        public DbSet<TableData> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

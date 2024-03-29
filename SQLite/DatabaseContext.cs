﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace ConvertTxtDictionaryToDB.SQLite
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = "./Dictionary.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Words> Words { get; set; }
    }
}
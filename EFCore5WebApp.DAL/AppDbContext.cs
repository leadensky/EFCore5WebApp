using EFCore5WebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFCore5WebApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        { }

        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LookUp> LookUps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookUp>().HasData(new List<LookUp>
            {
                new LookUp() {Code = "AL", Description = "Alabama", LookUpType = LookUpType.State},
                new LookUp() {Code = "AK", Description = "Alaska", LookUpType = LookUpType.State},
                new LookUp() {Code = "AZ", Description = "Arizona", LookUpType = LookUpType.State},
                new LookUp() {Code = "AR", Description = "Arkansas", LookUpType = LookUpType.State},
                new LookUp() {Code = "CA", Description = "California", LookUpType = LookUpType.State},
                new LookUp() {Code = "CO", Description = "Colorado", LookUpType = LookUpType.State},
                new LookUp() {Code = "CT", Description = "Connecticut", LookUpType = LookUpType.State},
                new LookUp() {Code = "DE", Description = "Delaware", LookUpType = LookUpType.State},
                new LookUp() {Code = "DC", Description = "District of Columbia", LookUpType = LookUpType.State},
                new LookUp() {Code = "FL", Description = "Florida", LookUpType = LookUpType.State},
                new LookUp() {Code = "GA", Description = "Georgia", LookUpType = LookUpType.State},
                new LookUp() {Code = "HI", Description = "Hawaii", LookUpType = LookUpType.State},
                new LookUp() {Code = "ID", Description = "Idaho", LookUpType = LookUpType.State},
                new LookUp() {Code = "IL", Description = "Illinois", LookUpType = LookUpType.State},
                new LookUp() {Code = "IA", Description = "Iowa", LookUpType = LookUpType.State},
                new LookUp() {Code = "IN", Description = "Indiana", LookUpType = LookUpType.State},
                new LookUp() {Code = "KS", Description = "Kansas", LookUpType = LookUpType.State},
                new LookUp() {Code = "KY", Description = "Kentucky", LookUpType = LookUpType.State},
                new LookUp() {Code = "LA", Description = "Louisiana", LookUpType = LookUpType.State},
                new LookUp() {Code = "ME", Description = "Maine", LookUpType = LookUpType.State},
                new LookUp() {Code = "MD", Description = "Maryland", LookUpType = LookUpType.State},
                new LookUp() {Code = "MA", Description = "Massachusetts", LookUpType = LookUpType.State},
                new LookUp() {Code = "MI", Description = "Michigan", LookUpType = LookUpType.State},
                new LookUp() {Code = "MN", Description = "Minnesota", LookUpType = LookUpType.State},
                new LookUp() {Code = "MO", Description = "Missouri", LookUpType = LookUpType.State},
                new LookUp() {Code = "MT", Description = "Montana", LookUpType = LookUpType.State},
                new LookUp() {Code = "NE", Description = "Nebraska", LookUpType = LookUpType.State},
                new LookUp() {Code = "NV", Description = "Nevada", LookUpType = LookUpType.State},
                new LookUp() {Code = "NH", Description = "New Hampshire", LookUpType = LookUpType.State},
                new LookUp() {Code = "NJ", Description = "New Jersey", LookUpType = LookUpType.State},
                new LookUp() {Code = "NM", Description = "New Mexico", LookUpType = LookUpType.State},
                new LookUp() {Code = "NY", Description = "New York", LookUpType = LookUpType.State},
                new LookUp() {Code = "NC", Description = "North Carolina", LookUpType = LookUpType.State},
                new LookUp() {Code = "ND", Description = "North Dakota", LookUpType = LookUpType.State},
                new LookUp() {Code = "OH", Description = "Ohio", LookUpType = LookUpType.State},
                new LookUp() {Code = "OK", Description = "Oklahoma", LookUpType = LookUpType.State},
                new LookUp() {Code = "OR", Description = "Oregon", LookUpType = LookUpType.State},
                new LookUp() {Code = "PA", Description = "Pennsylvania", LookUpType = LookUpType.State},
                new LookUp() {Code = "PR", Description = "Puerto Rico", LookUpType = LookUpType.State},
                new LookUp() {Code = "RI", Description = "Rhode Island", LookUpType = LookUpType.State},
                new LookUp() {Code = "SC", Description = "South Carolina", LookUpType = LookUpType.State},
                new LookUp() {Code = "SD", Description = "South Dakota", LookUpType = LookUpType.State},
                new LookUp() {Code = "TN", Description = "Tennessee", LookUpType = LookUpType.State},
                new LookUp() {Code = "TX", Description = "Texas", LookUpType = LookUpType.State},
                new LookUp() {Code = "UT", Description = "Utah", LookUpType = LookUpType.State},
                new LookUp() {Code = "VT", Description = "Vermont", LookUpType = LookUpType.State},
                new LookUp() {Code = "VA", Description = "Virginia", LookUpType = LookUpType.State},
                new LookUp() {Code = "WA", Description = "Washington", LookUpType = LookUpType.State},
                new LookUp() {Code = "WV", Description = "West Virginia", LookUpType = LookUpType.State},
                new LookUp() {Code = "WI", Description = "Wisconsin", LookUpType = LookUpType.State},
                new LookUp() {Code = "WY", Description = "Wyoming", LookUpType = LookUpType.State},
                new LookUp() {Code = "USA", Description = "United States of America", LookUpType = LookUpType.Country},
            });
        }
    }
}

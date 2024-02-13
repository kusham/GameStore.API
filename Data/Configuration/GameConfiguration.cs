﻿using GamesStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.API.Data.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(game => game.Price)
                .HasPrecision(5, 2);
        }
    }
}

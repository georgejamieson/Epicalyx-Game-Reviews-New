﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Epicalyx_Game_Reviews.Models;

namespace Epicalyx_Game_Reviews.Data
{
    public class Epicalyx_Game_ReviewsContext : DbContext
    {
        public Epicalyx_Game_ReviewsContext (DbContextOptions<Epicalyx_Game_ReviewsContext> options)
            : base(options)
        {
        }

        public DbSet<Epicalyx_Game_Reviews.Models.Game> Game { get; set; }

        public DbSet<Epicalyx_Game_Reviews.Models.FinalReview> FinalReview { get; set; }

        public DbSet<Epicalyx_Game_Reviews.Models.User> User { get; set; }
    }
}

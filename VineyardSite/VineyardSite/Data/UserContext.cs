﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VineyardSite.Model;

namespace VineyardSite.Data;

public class UserContext : IdentityDbContext<User, IdentityRole, string>
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

﻿using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catelog.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catelog.Infra.Data.EF;

public class CodeflixCatalogDbContext :DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public CodeflixCatalogDbContext(
        DbContextOptions<CodeflixCatalogDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfiguration());
    }
}

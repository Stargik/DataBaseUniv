using System;
using System.Collections.Generic;
using DataBaseUniv.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseUniv;

public partial class DataBaseUniv2Context : DbContext
{
    public DataBaseUniv2Context()
    {
    }

    public DataBaseUniv2Context(DbContextOptions<DataBaseUniv2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Cource> Cources { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {

            entity.HasOne(d => d.Cource).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Classes_Cources");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Classes_Teachers");
        });

        modelBuilder.Entity<Cource>(entity =>
        {

            entity.HasOne(d => d.Level).WithMany(p => p.Cources)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Cources_Levels");
        });

        modelBuilder.Entity<Level>(entity =>
        {

        });

        modelBuilder.Entity<Models.Task>(entity =>
        {

            entity.HasOne(d => d.Cource).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CourceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tasks_Cources");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

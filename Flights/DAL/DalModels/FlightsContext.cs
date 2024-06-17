using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Flights.Models;

public partial class FlightsContext : DbContext
{
    public FlightsContext()
    {
    }

    public FlightsContext(DbContextOptions<FlightsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightCrew> FlightCrews { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Traveling> Travelings { get; set; }

    public virtual DbSet<Workers> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"H:\\פרויקט C#\\Flights\\DAL\\Flights.mdf\";Integrated Security=True;Connect Timeout=30;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.AirlineId).HasName("PK__Airlines__DC458273B30FFA6B");

            entity.Property(e => e.AirlineId)
                .ValueGeneratedNever()
                .HasColumnName("AirlineID");
            entity.Property(e => e.AirlineName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ContactInformation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

            entity.HasOne(d => d.Worker).WithMany(p => p.Airlines)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Airlines_Workers");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Flights__8A9E148E1C4DB5F1");

            entity.Property(e => e.FlightId)
                .ValueGeneratedNever()
                .HasColumnName("FlightID");
            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.ArrivalAirport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ArrivalTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureAirport)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");

            entity.HasOne(d => d.Airline).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Flights_Airlines");
        });

        modelBuilder.Entity<FlightCrew>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__FlightCr__123AE7B9B0037281");

            entity.ToTable("FlightCrew");

            entity.Property(e => e.TeamId)
                .ValueGeneratedNever()
                .HasColumnName("TeamID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightCrews)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FlightCrew_Flights");

            entity.HasOne(d => d.Role).WithMany(p => p.FlightCrews)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FlightCrew_Roles");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF9D1C7D21");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.FlightId).HasColumnName("FlightID");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.PassengerId).HasColumnName("PassengerID");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Flight).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Flights");

            entity.HasOne(d => d.Passenger).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Traveling");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AD8E1323D");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.Attendant)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.MainPilot)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.SecondaryPilot)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Traveling>(entity =>
        {
            entity.HasKey(e => e.PassengerId).HasName("PK__Travelin__88915F9028FEB8A6");

            entity.ToTable("Traveling");

            entity.Property(e => e.PassengerId)
                .ValueGeneratedNever()
                .HasColumnName("PassengerID");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Workers>(entity =>
        {
            entity.HasKey(e => e.WorkerId).HasName("PK__Workers__7AD04FF115B73D77");

            entity.Property(e => e.WorkerId)
                .ValueGeneratedNever()
                .HasColumnName("WorkerID");
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DateOfEmployment).HasColumnType("date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

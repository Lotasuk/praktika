using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace praktika.BD;

public partial class Entity : DbContext
{
    public Entity()
    {
    }

    public Entity(DbContextOptions<Entity> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientsLogin> ClientsLogins { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiceMaintenance> ServiceMaintenances { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffLogin> StaffLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=CarSale;User ID=postgres;Password=Lotasuk21gaybar");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Cars_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Cost)
                .HasColumnType("money")
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.YearOfRelease).HasColumnName("year_of_release");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Clients_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(11)
                .HasColumnName("number");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<ClientsLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ClientsLogin_pkey");

            entity.ToTable("ClientsLogin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClients).HasColumnName("id_clients");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");

            entity.HasOne(d => d.IdClientsNavigation).WithMany(p => p.ClientsLogins)
                .HasForeignKey(d => d.IdClients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.DateOfSale).HasColumnName("date_of_sale");
            entity.Property(e => e.IdCar).HasColumnName("id_car");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.StatusOfOrder).HasColumnName("status_of_order");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Car");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStaff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Staff");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<ServiceMaintenance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ServiceMaintenance_pkey");

            entity.ToTable("ServiceMaintenance");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateOfService).HasColumnName("date_of_service");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.TypeOfWork)
                .HasMaxLength(50)
                .HasColumnName("type_of_work");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ServiceMaintenances)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Client");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.ServiceMaintenances)
                .HasForeignKey(d => d.IdStaff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Staff");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Staff_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(11)
                .HasColumnName("number");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");

            entity.HasOne(d => d.Role).WithMany(p => p.Staff)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Role");
        });

        modelBuilder.Entity<StaffLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("StaffLogin_pkey");

            entity.ToTable("StaffLogin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.StaffLogins)
                .HasForeignKey(d => d.IdStaff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Staff");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

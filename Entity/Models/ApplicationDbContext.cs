using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customerorder> Customerorders { get; set; }

    public virtual DbSet<Dinetable> Dinetables { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Kot> Kots { get; set; }

    public virtual DbSet<Menucategory> Menucategories { get; set; }

    public virtual DbSet<Menuitem> Menuitems { get; set; }

    public virtual DbSet<Modifier> Modifiers { get; set; }

    public virtual DbSet<Modifiergroup> Modifiergroups { get; set; }

    public virtual DbSet<Modifiergroupandmodifier> Modifiergroupandmodifiers { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Ordertax> Ordertaxes { get; set; }

    public virtual DbSet<Roleandpermission> Roleandpermissions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<Userdetail> Userdetails { get; set; }

    public virtual DbSet<Userlogin> Userlogins { get; set; }

    public virtual DbSet<Userpermission> Userpermissions { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    public virtual DbSet<Waitinglist> Waitinglists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=pizza_shop;Username=postgres;Password=trush");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Cityid).HasName("city_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CityCreatedbyNavigations).HasConstraintName("city_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CityModifiedbyNavigations).HasConstraintName("city_modifiedby_fkey");

            entity.HasOne(d => d.State).WithMany(p => p.Cities).HasConstraintName("city_stateid_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Countryid).HasName("country_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CountryCreatedbyNavigations).HasConstraintName("country_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CountryModifiedbyNavigations).HasConstraintName("country_modifiedby_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("customer_pkey");

            entity.Property(e => e.Customerid).ValueGeneratedOnAdd();

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CustomerCreatedbyNavigations).HasConstraintName("customer_createdby_fkey");

            entity.HasOne(d => d.CustomerNavigation).WithOne(p => p.CustomerCustomerNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CustomerModifiedbyNavigations).HasConstraintName("customer_modifiedby_fkey");
        });

        modelBuilder.Entity<Customerorder>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("customerorder_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.CustomerorderCreatedbyNavigations).HasConstraintName("customerorder_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Customerorders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customerorder_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.CustomerorderModifiedbyNavigations).HasConstraintName("customerorder_modifiedby_fkey");
        });

        modelBuilder.Entity<Dinetable>(entity =>
        {
            entity.HasKey(e => e.Tableid).HasName("dinetable_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.DinetableCreatedbyNavigations).HasConstraintName("dinetable_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.DinetableModifiedbyNavigations).HasConstraintName("dinetable_modifiedby_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Dinetables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dinetable_sectionid_fkey");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Feedbackid).HasName("feedback_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.FeedbackCreatedbyNavigations).HasConstraintName("feedback_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks).HasConstraintName("feedback_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.FeedbackModifiedbyNavigations).HasConstraintName("feedback_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks).HasConstraintName("feedback_orderid_fkey");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Invoiceid).HasName("invoice_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.InvoiceCreatedbyNavigations).HasConstraintName("invoice_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices).HasConstraintName("invoice_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.InvoiceModifiedbyNavigations).HasConstraintName("invoice_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices).HasConstraintName("invoice_orderid_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Invoices).HasConstraintName("invoice_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Invoices).HasConstraintName("invoice_tableid_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Invoices).HasConstraintName("invoice_taxid_fkey");
        });

        modelBuilder.Entity<Kot>(entity =>
        {
            entity.HasKey(e => e.Kotid).HasName("kot_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.KotCreatedbyNavigations).HasConstraintName("kot_createdby_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.Kots).HasConstraintName("kot_itemid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.KotModifiedbyNavigations).HasConstraintName("kot_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Kots).HasConstraintName("kot_orderid_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Kots).HasConstraintName("kot_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Kots).HasConstraintName("kot_tableid_fkey");
        });

        modelBuilder.Entity<Menucategory>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("menucategory_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.MenucategoryCreatedbyNavigations).HasConstraintName("menucategory_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.MenucategoryModifiedbyNavigations).HasConstraintName("menucategory_modifiedby_fkey");
        });

        modelBuilder.Entity<Menuitem>(entity =>
        {
            entity.HasKey(e => e.Itemid).HasName("menuitems_pkey");

            entity.HasOne(d => d.Category).WithMany(p => p.Menuitems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuitems_categoryid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.MenuitemCreatedbyNavigations).HasConstraintName("menuitems_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.MenuitemModifiedbyNavigations).HasConstraintName("menuitems_modifiedby_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Menuitems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menuitems_taxid_fkey");
        });

        modelBuilder.Entity<Modifier>(entity =>
        {
            entity.HasKey(e => e.Modifierid).HasName("modifier_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ModifierCreatedbyNavigations).HasConstraintName("modifier_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.ModifierModifiedbyNavigations).HasConstraintName("modifier_modifiedby_fkey");
        });

        modelBuilder.Entity<Modifiergroup>(entity =>
        {
            entity.HasKey(e => e.Modifiergroupid).HasName("modifiergroup_pkey");

            entity.Property(e => e.Maxselect).HasDefaultValueSql("1");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.ModifiergroupCreatedbyNavigations).HasConstraintName("modifiergroup_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.ModifiergroupModifiedbyNavigations).HasConstraintName("modifiergroup_modifiedby_fkey");
        });

        modelBuilder.Entity<Modifiergroupandmodifier>(entity =>
        {
            entity.HasKey(e => e.Mandmid).HasName("modifiergroupandmodifier_pkey");

            entity.HasOne(d => d.Modifiergroup).WithMany(p => p.Modifiergroupandmodifiers).HasConstraintName("modifiergroupandmodifier_modifiergroupid_fkey");

            entity.HasOne(d => d.Modifier).WithMany(p => p.Modifiergroupandmodifiers).HasConstraintName("modifiergroupandmodifier_modifierid_fkey");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.Orderdetailid).HasName("orderdetail_pkey");

            entity.Property(e => e.Orderdetailid).HasDefaultValueSql("nextval('orderdetail_orderid_seq'::regclass)");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.OrderdetailCreatedbyNavigations).HasConstraintName("orderdetail_createdby_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.Orderdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_itemid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.OrderdetailModifiedbyNavigations).HasConstraintName("orderdetail_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_orderid_fkey");
        });

        modelBuilder.Entity<Ordertax>(entity =>
        {
            entity.HasKey(e => e.Ordertaxid).HasName("ordertax_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.OrdertaxCreatedbyNavigations).HasConstraintName("ordertax_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.OrdertaxModifiedbyNavigations).HasConstraintName("ordertax_modifiedby_fkey");

            entity.HasOne(d => d.Order).WithMany(p => p.Ordertaxes).HasConstraintName("ordertax_orderid_fkey");

            entity.HasOne(d => d.Tax).WithMany(p => p.Ordertaxes).HasConstraintName("ordertax_taxid_fkey");
        });

        modelBuilder.Entity<Roleandpermission>(entity =>
        {
            entity.HasKey(e => e.Rapid).HasName("roleandpermission_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.RoleandpermissionCreatedbyNavigations).HasConstraintName("roleandpermission_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.RoleandpermissionModifiedbyNavigations).HasConstraintName("roleandpermission_modifiedby_fkey");

            entity.HasOne(d => d.Permission).WithMany(p => p.Roleandpermissions).HasConstraintName("roleandpermission_permissionid_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Roleandpermissions).HasConstraintName("roleandpermission_roleid_fkey");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.Sectionid).HasName("section_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.SectionCreatedbyNavigations).HasConstraintName("section_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.SectionModifiedbyNavigations).HasConstraintName("section_modifiedby_fkey");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Stateid).HasName("state_pkey");

            entity.HasOne(d => d.Country).WithMany(p => p.States).HasConstraintName("state_countryid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.StateCreatedbyNavigations).HasConstraintName("state_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.StateModifiedbyNavigations).HasConstraintName("state_modifiedby_fkey");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.Taxid).HasName("tax_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TaxCreatedbyNavigations).HasConstraintName("tax_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.TaxModifiedbyNavigations).HasConstraintName("tax_modifiedby_fkey");
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("userdetail_pkey");

            entity.Property(e => e.Userid).HasDefaultValueSql("nextval('userdetail_id_seq'::regclass)");

            entity.HasOne(d => d.City).WithMany(p => p.Userdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_cityid_fkey");

            entity.HasOne(d => d.Country).WithMany(p => p.Userdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_countryid_fkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.UserdetailCreatedbyNavigations).HasConstraintName("userdetail_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.UserdetailModifiedbyNavigations).HasConstraintName("userdetail_modifiedby_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Userdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_roleid_fkey");

            entity.HasOne(d => d.State).WithMany(p => p.Userdetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_stateid_fkey");

            entity.HasOne(d => d.User).WithOne(p => p.UserdetailUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_userid_fkey");
        });

        modelBuilder.Entity<Userlogin>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("userlogin_pkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Userlogins)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userlogin_roleid_fkey");
        });

        modelBuilder.Entity<Userpermission>(entity =>
        {
            entity.HasKey(e => e.Permissionid).HasName("userpermissions_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.UserpermissionCreatedbyNavigations).HasConstraintName("userpermissions_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.UserpermissionModifiedbyNavigations).HasConstraintName("userpermissions_modifiedby_fkey");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("userrole_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.UserroleCreatedbyNavigations).HasConstraintName("userrole_createdby_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.UserroleModifiedbyNavigations).HasConstraintName("userrole_modifiedby_fkey");
        });

        modelBuilder.Entity<Waitinglist>(entity =>
        {
            entity.HasKey(e => e.Tokenid).HasName("waitinglist_pkey");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.WaitinglistCreatedbyNavigations).HasConstraintName("waitinglist_createdby_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Waitinglists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("waitinglist_customerid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.WaitinglistModifiedbyNavigations).HasConstraintName("waitinglist_modifiedby_fkey");

            entity.HasOne(d => d.Section).WithMany(p => p.Waitinglists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("waitinglist_sectionid_fkey");

            entity.HasOne(d => d.Table).WithMany(p => p.Waitinglists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("waitinglist_tableid_fkey");
                 modelBuilder.Entity<Modifiergroupandmodifier>()
        .HasKey(m => m.Mandmid);
    
    modelBuilder.Entity<Modifiergroupandmodifier>()
        .HasOne(m => m.Modifiergroup)
        .WithMany(mg => mg.Modifiergroupandmodifiers)
        .HasForeignKey(m => m.Modifiergroupid);
    
    modelBuilder.Entity<Modifiergroupandmodifier>()
        .HasOne(m => m.Modifier)
        .WithMany(m => m.Modifiergroupandmodifiers)
        .HasForeignKey(m => m.Modifierid);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

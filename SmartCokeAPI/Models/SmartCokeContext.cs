using Microsoft.EntityFrameworkCore;

namespace SmartCokeAPI.Models
{
    public partial class SmartCokeContext : DbContext
    {
        public SmartCokeContext()
        {
        }

        public SmartCokeContext(DbContextOptions<SmartCokeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Comolaints> Comolaints { get; set; }
        public virtual DbSet<CountryCodes> CountryCodes { get; set; }
        public virtual DbSet<CustomerDetails> CustomerDetails { get; set; }
        public virtual DbSet<CustomOrders> CustomOrders { get; set; }
        public virtual DbSet<CustomProducts> CustomProducts { get; set; }
        public virtual DbSet<Distributors> Distributors { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<EventSize> EventSize { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PackageBreakdown> PackageBreakdown { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<PackSizes> PackSizes { get; set; }
        public virtual DbSet<PromoCodes> PromoCodes { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Screference> Screference { get; set; }
        public virtual DbSet<ServiceCharge> ServiceCharge { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "SmartCoke");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.AddedTime).IsUnicode(false);

                entity.Property(e => e.AreaId)
                    .HasColumnName("AreaID")
                    .IsUnicode(false);

                entity.Property(e => e.AreaName).IsUnicode(false);

                entity.Property(e => e.ChargeType).IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .HasMaxLength(10);

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .IsUnicode(false);

                entity.Property(e => e.ServCharge).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            modelBuilder.Entity<Comolaints>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);
            });

            modelBuilder.Entity<CountryCodes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);
            });

            modelBuilder.Entity<CustomerDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustCode).IsUnicode(false);

                entity.Property(e => e.Dob).IsUnicode(false);

                entity.Property(e => e.DobDay).IsUnicode(false);

                entity.Property(e => e.DobMonth).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .IsUnicode(false);

                entity.Property(e => e.Lname).IsUnicode(false);

                entity.Property(e => e.Membership).IsUnicode(false);

                entity.Property(e => e.Orders).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.PhoneNum).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Uname).IsUnicode(false);

                entity.Property(e => e.AltContactPersonName).IsUnicode(false);

                entity.Property(e => e.AltContactPersonNumber).IsUnicode(false);

                entity.Property(e => e.GhanaPost).IsUnicode(false);

                entity.Property(e => e.HowYouHeard).IsUnicode(false);
                
                entity.Property(e => e.ReferenceDetails).IsUnicode(false);
            });

            modelBuilder.Entity<CustomOrders>(entity =>
            {
                entity.ToTable("CustomOrders", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).IsUnicode(false);

                entity.Property(e => e.DateLogged).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Quantity).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.Total).IsUnicode(false);
            });

            modelBuilder.Entity<CustomProducts>(entity =>
            {
                entity.ToTable("CustomProducts", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.AddedDate).IsUnicode(false);

                entity.Property(e => e.PackSize).IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.UnitAmount).IsUnicode(false);
            });

            modelBuilder.Entity<Distributors>(entity =>
            {
                entity.ToTable("Distributors", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.AddedDate).IsUnicode(false);

                entity.Property(e => e.DistribId)
                    .HasColumnName("DistribID")
                    .IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName).IsUnicode(false);

                entity.Property(e => e.EditedBy).IsUnicode(false);

                entity.Property(e => e.EditedDate).IsUnicode(false);

                entity.Property(e => e.OtcontactNumber)
                    .HasColumnName("OTContactNumber")
                    .IsUnicode(false);

                entity.Property(e => e.OtcontactPerson)
                    .HasColumnName("OTContactPerson")
                    .IsUnicode(false);

                entity.Property(e => e.Otemail)
                    .HasColumnName("OTEmail")
                    .IsUnicode(false);

                entity.Property(e => e.Outlet).IsUnicode(false);

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .IsUnicode(false);

                entity.Property(e => e.Rsmemail)
                    .HasColumnName("RSMEmail")
                    .IsUnicode(false);

                entity.Property(e => e.Rsmname)
                    .HasColumnName("RSMName")
                    .IsUnicode(false);

                entity.Property(e => e.Rsmnumber)
                    .HasColumnName("RSMNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Rssemail)
                    .HasColumnName("RSSEmail")
                    .IsUnicode(false);

                entity.Property(e => e.Rssname)
                    .HasColumnName("RSSName")
                    .IsUnicode(false);

                entity.Property(e => e.Rssnumber)
                    .HasColumnName("RSSNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Township).IsUnicode(false);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.AddedDate).IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName).IsUnicode(false);

                entity.Property(e => e.EditBy).IsUnicode(false);

                entity.Property(e => e.EditTime).IsUnicode(false);

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<District>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_District");
            });

            modelBuilder.Entity<EventSize>(entity =>
            {
                entity.ToTable("EventSize", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventSize1)
                    .HasColumnName("EventSize")
                    .IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventType1)
                    .HasColumnName("EventType")
                    .IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.LoggedDate).IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .IsUnicode(false);

                entity.Property(e => e.Rating).IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fname).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcqResponseCode).IsUnicode(false);

                entity.Property(e => e.Area).IsUnicode(false);

                entity.Property(e => e.AuthorizeId).IsUnicode(false);

                entity.Property(e => e.BatchNo).IsUnicode(false);

                entity.Property(e => e.BtbankName)
                    .HasColumnName("BTBankName")
                    .IsUnicode(false);

                entity.Property(e => e.Btdate)
                    .HasColumnName("BTDate")
                    .IsUnicode(false);

                entity.Property(e => e.Btrefrence)
                    .HasColumnName("BTRefrence")
                    .IsUnicode(false);

                entity.Property(e => e.Card).IsUnicode(false);

                entity.Property(e => e.CountCode).IsUnicode(false);

                entity.Property(e => e.CscResultCode)
                    .HasColumnName("cscResultCode")
                    .IsUnicode(false);

                entity.Property(e => e.CscResultCodeDesc)
                    .HasColumnName("cscResultCodeDesc")
                    .IsUnicode(false);

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.DeliveryMail).IsUnicode(false);

                entity.Property(e => e.DistributorAmount).IsUnicode(false);

                entity.Property(e => e.DistributorId)
                    .HasColumnName("DistributorID")
                    .IsUnicode(false);

                entity.Property(e => e.DistributorName).IsUnicode(false);

                entity.Property(e => e.District).IsUnicode(false);

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .IsUnicode(false);

                entity.Property(e => e.Dseci)
                    .HasColumnName("DSECI")
                    .IsUnicode(false);

                entity.Property(e => e.Dsenrolled)
                    .HasColumnName("DSenrolled")
                    .IsUnicode(false);

                entity.Property(e => e.Dsstatus)
                    .HasColumnName("DSstatus")
                    .IsUnicode(false);

                entity.Property(e => e.Dsxid)
                    .HasColumnName("DSXID")
                    .IsUnicode(false);

                entity.Property(e => e.Duration).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EpicorStatus).IsUnicode(false);

                entity.Property(e => e.EventSize).IsUnicode(false);

                entity.Property(e => e.EventType).IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .IsUnicode(false);

                entity.Property(e => e.GhanaPostGps)
                    .HasColumnName("GhanaPostGPS")
                    .IsUnicode(false);

                entity.Property(e => e.Lname).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.LoggedDate).HasColumnType("date");

                entity.Property(e => e.LoyalytyPoint).IsUnicode(false);

                entity.Property(e => e.MailStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MerchTxnRef).IsUnicode(false);

                entity.Property(e => e.Merchant).IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Momonetwork)
                    .HasColumnName("MOMONetwork")
                    .IsUnicode(false);

                entity.Property(e => e.Momonumber)
                    .HasColumnName("MOMONumber")
                    .IsUnicode(false);

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .IsUnicode(false);

                entity.Property(e => e.OrderInfo).IsUnicode(false);

                entity.Property(e => e.PackageName)
                     .HasColumnName("package")
                     .IsUnicode(false);

                entity.Property(e => e.PaidAmount).IsUnicode(false);

                entity.Property(e => e.PaymentType).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.PromoCode).IsUnicode(false);

                entity.Property(e => e.ReceiptErrorMessage).IsUnicode(false);

                entity.Property(e => e.ReceiptNo).IsUnicode(false);

                entity.Property(e => e.ReferenceDetails).IsUnicode(false);

                entity.Property(e => e.ReferenceType).IsUnicode(false);

                entity.Property(e => e.Region).IsUnicode(false);

                entity.Property(e => e.RiskOverallResult).IsUnicode(false);

                entity.Property(e => e.Rsvpname)
                    .HasColumnName("RSVPname")
                    .IsUnicode(false);

                entity.Property(e => e.Rsvpnumber)
                    .HasColumnName("RSVPNumber")
                    .IsUnicode(false);

                entity.Property(e => e.ServCharge).IsUnicode(false);

                entity.Property(e => e.ShareAcoke).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.TotalAmount).IsUnicode(false);

                entity.Property(e => e.TransactionNo).IsUnicode(false);

                entity.Property(e => e.TxnResponseCode).IsUnicode(false);

                entity.Property(e => e.TxnResponseCodeDesc).IsUnicode(false);

                entity.Property(e => e.TxnReversalResult).IsUnicode(false);

                entity.Property(e => e.Venue).IsUnicode(false);

                entity.Property(e => e.VerSecurityLevel).IsUnicode(false);

                entity.Property(e => e.VerStatus).IsUnicode(false);

                entity.Property(e => e.VerToken).IsUnicode(false);

                entity.Property(e => e.VerType).IsUnicode(false);

                entity.Property(e => e.Volume).IsUnicode(false);
            });

            modelBuilder.Entity<PackageBreakdown>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.AddedDate).IsUnicode(false);

                entity.Property(e => e.PackSize).IsUnicode(false);

                entity.Property(e => e.PackageName).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Quantity).IsUnicode(false);

                entity.Property(e => e.Total).IsUnicode(false);
            });

            modelBuilder.Entity<Packages>(entity =>
            {
                entity.ToTable("Packages", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PackageDesc).IsUnicode(false);

                entity.Property(e => e.PackageName).IsUnicode(false);

                entity.Property(e => e.PackageText).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Volume).IsUnicode(false);
            });

            modelBuilder.Entity<PackSizes>(entity =>
            {
                entity.ToTable("PackSizes", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.SizeId)
                    .HasColumnName("SizeID")
                    .IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<PromoCodes>(entity =>
            {
                entity.ToTable("PromoCodes", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateEntered).HasColumnType("datetime");

                entity.Property(e => e.Duration).IsUnicode(false);

                entity.Property(e => e.OrganisationContact).IsUnicode(false);

                entity.Property(e => e.OrganisationEmail).IsUnicode(false);

                entity.Property(e => e.OrganisationName).IsUnicode(false);

                entity.Property(e => e.ProjectedOrders).IsUnicode(false);

                entity.Property(e => e.PromoId)
                    .HasColumnName("PromoID")
                    .IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .IsUnicode(false);

                entity.Property(e => e.RegionName).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);
            });

            modelBuilder.Entity<Screference>(entity =>
            {
                entity.ToTable("SCreference", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Mamlade).IsUnicode(false);

                entity.Property(e => e.ReferenceName).IsUnicode(false);
            });


            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("CustomerAddress", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.RegionId).IsUnicode(false);

                entity.Property(e => e.RegionName).IsUnicode(false);

                entity.Property(e => e.DistrictId).IsUnicode(false);

                entity.Property(e => e.DistrictName).IsUnicode(false);

                entity.Property(e => e.AreaId).IsUnicode(false);

                entity.Property(e => e.AreaName).IsUnicode(false);
            });

            modelBuilder.Entity<ServiceCharge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.AddedDate).IsUnicode(false);

                entity.Property(e => e.Definiton).IsUnicode(false);

                entity.Property(e => e.ServChrgAmt).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.ChargePercentage).IsUnicode(false);

                entity.Property(e=>e.MinimumCasesCount).IsUnicode(false);

            });
        }
    }
}

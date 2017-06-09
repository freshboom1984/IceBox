using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IceBox.Models
{
    public partial class IceboxDBContext : DbContext
    {
        public virtual DbSet<Consignee> Consignee { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerType> CustomerType { get; set; }
        public virtual DbSet<CustomerWords> CustomerWords { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<NewsTable> NewsTable { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<ProductTable> ProductTable { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TypeTable> TypeTable { get; set; }
        public virtual DbSet<User> User { get; set; }

        public IceboxDBContext(DbContextOptions<IceboxDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consignee>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Consigne__530A638C9AC215F3");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.DoorNumber)
                    .HasColumnName("doorNumber")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone)
                    .HasColumnName("homePhone")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobilePhone")
                    .HasColumnType("nchar(18)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(16)");

                entity.Property(e => e.OfficePhone)
                    .HasColumnName("officePhone")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.QqNumber)
                    .HasColumnName("qqNumber")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.RoadName)
                    .HasColumnName("roadName")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.StreetName)
                    .HasColumnName("streetName")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.TheCustomer).HasColumnName("theCustomer");

                entity.Property(e => e.ZipCode).HasColumnName("zipCode");

                entity.HasOne(d => d.TheCustomerNavigation)
                    .WithMany(p => p.Consignee)
                    .HasForeignKey(d => d.TheCustomer)
                    .HasConstraintName("FK__Consignee__theCu__73BA3083");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                     .HasName("PK__tmp_ms_x__530A638C18D5C261");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(512);

                entity.Property(e => e.HomePhone)
                    .HasColumnName("homePhone")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobilePhone")
                    .HasColumnType("nchar(18)");

                entity.Property(e => e.OfficePhone)
                    .HasColumnName("officePhone")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.QqNumber)
                    .HasColumnName("qqNumber")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.RegistDate)
                    .HasColumnName("registDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TheCustomerType).HasColumnName("theCustomerType");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(256);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(256);
                entity.HasOne(d => d.TheCustomerTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TheCustomerType)
                    .HasConstraintName("FK__Customer__theCus__5CD6CB2B");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Customer__530A638C3E6E5339");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.MinSpending).HasColumnName("minSpending");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<CustomerWords>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Customer__530A638CA1478D47");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.TheOrder).HasColumnName("theOrder");

                entity.Property(e => e.Words)
                    .HasColumnName("words")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Division__530A638C20FD8475");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.DoorNumber)
                    .HasColumnName("doorNumber")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.RoadName)
                    .HasColumnName("roadName")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.StreeName)
                    .HasColumnName("streeName")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.ZipCode).HasColumnName("zipCode");
            });

            modelBuilder.Entity<NewsTable>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK_News_table");

                entity.ToTable("News_table");

                entity.Property(e => e.ObjId).ValueGeneratedNever();

                entity.Property(e => e.Buttoncontext).HasColumnType("nchar(50)");

                entity.Property(e => e.Img).HasColumnType("nchar(50)");

                entity.Property(e => e.Name).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Order__530A638C0800386E");

                entity.Property(e => e.ObjId)
                    .HasColumnName("objId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.OrderState).HasColumnName("orderState");

                entity.Property(e => e.OrderTime)
                    .HasColumnName("orderTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TheClerk).HasColumnName("theClerk");

                entity.Property(e => e.TheConsignee).HasColumnName("theConsignee");

                entity.Property(e => e.TheCustomer).HasColumnName("theCustomer");

                entity.Property(e => e.TheDeliverer).HasColumnName("theDeliverer");

                entity.Property(e => e.ThePayment).HasColumnName("thePayment");

                entity.Property(e => e.TheProduct).HasColumnName("theProduct");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Payment__530A638C968EA5B9");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.AccountName)
                    .HasColumnName("accountName")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasColumnType("nchar(24)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.PaymentState).HasColumnName("paymentState");

                entity.Property(e => e.ThePaymentType).HasColumnName("thePaymentType");

                entity.Property(e => e.TransNo)
                    .HasColumnName("transNo")
                    .HasColumnType("nchar(16)");

                entity.Property(e => e.TransTime)
                    .HasColumnName("transTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ThePaymentTypeNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ThePaymentType)
                    .HasConstraintName("FK__Payment__thePaym__7D439ABD");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__PaymentT__530A638C8DAEA1C9");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.BigImg)
                    .HasColumnName("bigImg")
                    .HasMaxLength(80);

                entity.Property(e => e.MethodName)
                    .HasColumnName("methodName")
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.SmallImg)
                    .HasColumnName("smallImg")
                    .HasMaxLength(80);

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasColumnType("nchar(16)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.ToTable("Product_table");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Chigh).HasColumnType("nchar(500)");

                entity.Property(e => e.Clow)
                    .IsRequired()
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.Ename).HasColumnType("nchar(40)");

                entity.Property(e => e.Hdiscribe).HasColumnType("nchar(500)");

                entity.Property(e => e.Hpicture)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Sdisvribe).HasColumnType("nchar(1500)");

                entity.Property(e => e.Spicture1)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Spicture2)
                    .IsRequired()
                    .HasColumnType("nchar(100)");

                entity.Property(e => e.Svideo).HasColumnType("nchar(100)");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Province__530A638C70E10C37");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Receipt__530A638CF450DA59");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.ReceiptFile)
                    .HasColumnName("receiptFile")
                    .HasMaxLength(500);

                entity.Property(e => e.TheOrder).HasColumnName("theOrder");

                entity.HasOne(d => d.TheOrderNavigation)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.TheOrder)
                    .HasConstraintName("FK__Receipt__theOrde__02084FDA");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__Role__530A638C15EC81B7");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<TypeTable>(entity =>
            {
                entity.ToTable("Type_table");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type).HasColumnType("nchar(15)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PK__User__530A638C3A855F66");

                entity.Property(e => e.ObjId).HasColumnName("objId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.HomePhone)
                    .HasColumnName("homePhone")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.MobilePhone)
                    .HasColumnName("mobilePhone")
                    .HasColumnType("nchar(18)");

                entity.Property(e => e.OfficePhone)
                    .HasColumnName("officePhone")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("nchar(16)");

                entity.Property(e => e.QqNumber)
                    .HasColumnName("qqNumber")
                    .HasColumnType("nchar(12)");

                entity.Property(e => e.TheDivision).HasColumnName("theDivision");

                entity.Property(e => e.TheRole).HasColumnName("theRole");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasColumnType("nchar(16)");

                entity.Property(e => e.UserState).HasColumnName("userState");

                entity.HasOne(d => d.TheDivisionNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TheDivision)
                    .HasConstraintName("FK__User__theDivisio__06CD04F7");

                entity.HasOne(d => d.TheRoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TheRole)
                    .HasConstraintName("FK__User__theRole__07C12930");
            });
        }
    }
}
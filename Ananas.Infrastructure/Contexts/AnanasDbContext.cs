using Ananas.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Ananas.Infrastructure.Contexts
{
    public partial class AnanasDbContext : DbContext
    {
        public AnanasDbContext()
        {
        }

        public AnanasDbContext(DbContextOptions<AnanasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Collection> Collections { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<Market> Markets { get; set; }

        public virtual DbSet<Medium> Media { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        public virtual DbSet<ProductLine> ProductLines { get; set; }

        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }

        public virtual DbSet<Sex> Sexes { get; set; }

        public virtual DbSet<Size> Sizes { get; set; }

        public virtual DbSet<Style> Styles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//            => optionsBuilder.UseSqlServer("server =(local); database =Ananas ;uid=sa;pwd=123456;Trusted_Connection=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK__category__23CAF1F899A59B69");

                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.HasKey(e => e.CollectionId).HasName("PK__collecti__5BCE26BC69E9F734");

                entity.ToTable("collection");

                entity.Property(e => e.CollectionId).HasColumnName("collectionID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId).HasName("PK__color__70A64C3D5199824A");

                entity.ToTable("color");

                entity.Property(e => e.ColorId).HasColumnName("colorID");
                entity.Property(e => e.Code)
                    .HasMaxLength(7)
                    .HasColumnName("code");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.DiscountId).HasName("PK__discount__D2130A06746F6A34");

                entity.ToTable("discount");

                entity.Property(e => e.DiscountId).HasColumnName("discountID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("discount_percent");
                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasKey(e => e.MarketId).HasName("PK__market__EB884BDA836551EB");

                entity.ToTable("market");

                entity.Property(e => e.MarketId).HasColumnName("marketID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.MediaId).HasName("PK__media__D271B442629E2B7B");

                entity.ToTable("media");

                entity.Property(e => e.MediaId).HasColumnName("mediaID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("link");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__product__2D10D14A3779420B");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductCode, "UQ__product__AE1A8CC4EA3B9B52").IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("productID");
                entity.Property(e => e.Accessory).HasColumnName("accessory");
                entity.Property(e => e.CategoryId).HasColumnName("categoryID");
                entity.Property(e => e.CollectionId).HasColumnName("collectionID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");
                entity.Property(e => e.DiscountId).HasColumnName("discountID");
                entity.Property(e => e.Lower).HasColumnName("lower");
                entity.Property(e => e.MarketId).HasColumnName("marketID");
                entity.Property(e => e.MediaId).HasColumnName("mediaID");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
                entity.Property(e => e.ProductCode)
                    .HasMaxLength(255)
                    .HasColumnName("product_code");
                entity.Property(e => e.ProductLineId).HasColumnName("productLineID");
                entity.Property(e => e.ProductStatusId).HasColumnName("productStatusID");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("size");
                entity.Property(e => e.StyleId).HasColumnName("styleID");
                entity.Property(e => e.Upper).HasColumnName("upper");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__3B75D760");

                entity.HasOne(d => d.Collection).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CollectionId)
                    .HasConstraintName("FK__product__collect__3A81B327");

                entity.HasOne(d => d.Discount).WithMany(p => p.Products)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK__product__discoun__398D8EEE");

                entity.HasOne(d => d.Market).WithMany(p => p.Products)
                    .HasForeignKey(d => d.MarketId)
                    .HasConstraintName("FK__product__marketI__38996AB5");

                entity.HasOne(d => d.Media).WithMany(p => p.Products)
                    .HasForeignKey(d => d.MediaId)
                    .HasConstraintName("FK__product__mediaID__3F466844");

                entity.HasOne(d => d.ProductLine).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductLineId)
                    .HasConstraintName("FK__product__product__3C69FB99");

                entity.HasOne(d => d.ProductStatus).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductStatusId)
                    .HasConstraintName("FK__product__product__3D5E1FD2");

                entity.HasOne(d => d.Style).WithMany(p => p.Products)
                    .HasForeignKey(d => d.StyleId)
                    .HasConstraintName("FK__product__styleID__3E52440B");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.ProductDetailId).HasName("PK__product___D7B1FEA3419F8B36");

                entity.ToTable("product_detail");

                entity.Property(e => e.ProductDetailId).HasColumnName("productDetailID");
                entity.Property(e => e.ColorId).HasColumnName("colorID");
                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasColumnName("image");
                entity.Property(e => e.ProductId).HasColumnName("productID");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.SexId).HasColumnName("sexID");
                entity.Property(e => e.SizeId).HasColumnName("sizeID");
                entity.Property(e => e.Specialname)
                    .HasMaxLength(255)
                    .HasColumnName("specialname");

                entity.HasOne(d => d.Color).WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_d__color__4316F928");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_d__produ__4222D4EF");

                entity.HasOne(d => d.Sex).WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.SexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_d__sexID__440B1D61");
            });

            modelBuilder.Entity<ProductLine>(entity =>
            {
                entity.HasKey(e => e.ProductLineId).HasName("PK__product___690EA997DAA8D627");

                entity.ToTable("product_line");

                entity.Property(e => e.ProductLineId).HasColumnName("productLineID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<ProductStatus>(entity =>
            {
                entity.HasKey(e => e.ProductStatusId).HasName("PK__product___CFBEBB9C3E88627D");

                entity.ToTable("product_status");

                entity.Property(e => e.ProductStatusId).HasColumnName("productStatusID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.HasKey(e => e.SexId).HasName("PK__sex__D8437C7CCA842095");

                entity.ToTable("sex");

                entity.Property(e => e.SexId).HasColumnName("sexID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.Property(e => e.SizeId).HasColumnName("sizeID");
                entity.Property(e => e.CategoryId).HasColumnName("categoryID");
                entity.Property(e => e.Size1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.HasOne(d => d.Category).WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_size_category");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.StyleId).HasName("PK__style__1F798D7E6FD80E28");

                entity.ToTable("style");

                entity.Property(e => e.StyleId).HasColumnName("styleID");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");
                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_at");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Slug)
                    .HasMaxLength(255)
                    .HasColumnName("slug");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

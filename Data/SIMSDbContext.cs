using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MockPrj.Models;

namespace MockPrj.Data
{
    public class SIMSDbContext : DbContext
    {
        public SIMSDbContext(DbContextOptions<SIMSDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        //add more table - dbset
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<DeliveryNote> DeliveryNotes { get; set; }
        public DbSet<ReceiptNote> ReceiptNotes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<BillDetails> BillDetailses { get; set; }
        public DbSet<DeliveryNoteDetails> DeliveryNoteDetailses { get; set; }
        public DbSet<ReceiptNoteDetails> ReceiptNoteDetailses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
            .HasKey(k => k.Id);

            builder.Entity<Role>()
            .HasKey(k => k.Id);

            builder.Entity<Category>()
            .HasKey(k => k.Id);

            builder.Entity<Product>()
            .HasKey(k => k.Id);

            builder.Entity<Bill>()
           .HasKey(k => k.Id);

            builder.Entity<DeliveryNote>()
            .HasKey(k => k.Id);

            builder.Entity<ReceiptNote>()
            .HasKey(k => k.Id);

            builder.Entity<Report>()
            .HasKey(k => k.Id);

            builder.Entity<BillDetails>()
           .HasKey(k => new { k.BillId, k.ProductId });

            builder.Entity<ReceiptNoteDetails>()
          .HasKey(k => new { k.ReceiptNoteId, k.ProductId });

            builder.Entity<DeliveryNoteDetails>()
            .HasKey(k => new { k.DeliveryNoteId, k.ProductId });

            builder.Entity<DeliveryNoteDetails>()
            .HasOne(p => p.DeliveryNote)
            .WithMany(b => b.DeliveryNoteDetailses)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ReceiptNoteDetails>()
           .HasOne(p => p.ReceiptNote)
           .WithMany(b => b.ReceiptNoteDetailses)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BillDetails>()
            .HasOne(p => p.Bill)
            .WithMany(b => b.BillDetailses)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(b => b.Products)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Report>()
            .HasOne(p => p.Account)
            .WithMany(b => b.Reports)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DeliveryNote>()
            .HasOne(p => p.Account)
            .WithMany(b => b.DeliveryNotes)
            .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ReceiptNote>()
            .HasOne(p => p.Account)
            .WithMany(b => b.ReceiptNotes)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DeliveryNoteDetails>()
            .HasOne(p => p.Product)
            .WithMany(b => b.DeliveryNoteDetailses)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ReceiptNoteDetails>()
            .HasOne(p => p.Product)
            .WithMany(b => b.ReceiptNoteDetailses)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

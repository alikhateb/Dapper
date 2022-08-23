namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(c =>
            {
                c.HasKey(x => x.Id);
                c.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                c.Property(x => x.Address).HasMaxLength(150).IsRequired(true);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                e.Property(x => x.Title).HasMaxLength(50).IsRequired(false);
                e.HasOne(e => e.Company).WithMany(c => c.Employees).HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Student>(s =>
            {
                s.HasKey(x => x.Id);
                s.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

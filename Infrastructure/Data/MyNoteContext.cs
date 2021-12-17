namespace Infrastructure.Data
{
    public class MyNoteContext : DbContext
    {
        public MyNoteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Note

            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Note>().HasKey(e => e.Id);
            modelBuilder.Entity<Note>()
                .Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Note>()
                .Property(e => e.Content)
                .HasMaxLength(2000);
            modelBuilder.Entity<Note>()
                .HasOne(x => x.Detail)
                .WithOne(x => x.Note)
                .HasForeignKey<NoteDetail>(nd => nd.NoteId);
            modelBuilder.Entity<Note>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Notes)
                .HasForeignKey(c => c.CategoryId);

            #endregion

            #region Category

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region NoteDetail

            modelBuilder.Entity<NoteDetail>().ToTable("NoteDetails");
            modelBuilder.Entity<NoteDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<NoteDetail>()
                .Property(e => e.Created)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();
            modelBuilder.Entity<NoteDetail>()
                 .Property(e => e.LastModified)
                 .HasColumnType("datetime2").HasPrecision(0)
                 .IsRequired();
            #endregion

        }
    }
}

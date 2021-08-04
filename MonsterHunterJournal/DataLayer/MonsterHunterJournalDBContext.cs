using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataLayer
{
    public partial class MonsterHunterJournalDBContext : DbContext
    {
        public MonsterHunterJournalDBContext()
        {
        }

        public MonsterHunterJournalDBContext(DbContextOptions<MonsterHunterJournalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ailment> Ailments { get; set; }
        public virtual DbSet<CounterTactic> CounterTactics { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<Monster> Monsters { get; set; }
        public virtual DbSet<MonstersHabit> MonstersHabits { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponType> WeaponTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MonsterHunterJournalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ailment>(entity =>
            {
                entity.Property(e => e.AilmentId).HasColumnName("AilmentID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CounterTactic>(entity =>
            {
                entity.HasKey(e => new { e.WeaponTypeId, e.HabitId })
                    .HasName("PK__CounterT__19D4B1583508EDBF");

                entity.Property(e => e.WeaponTypeId).HasColumnName("WeaponTypeID");

                entity.Property(e => e.HabitId).HasColumnName("HabitID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Habit)
                    .WithMany(p => p.CounterTactics)
                    .HasForeignKey(d => d.HabitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CounterTa__Habit__5DCAEF64");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.CounterTactics)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CounterTa__Weapo__5CD6CB2B");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habit>(entity =>
            {
                entity.Property(e => e.HabitId).HasColumnName("HabitID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HabitName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.MonsterImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryAilmentId).HasColumnName("PrimaryAilmentID");

                entity.Property(e => e.PrimaryElementId).HasColumnName("PrimaryElementID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PrimaryAilment)
                    .WithMany(p => p.Monsters)
                    .HasForeignKey(d => d.PrimaryAilmentId)
                    .HasConstraintName("FK__Monsters__Primar__73BA3083");

                entity.HasOne(d => d.PrimaryElement)
                    .WithMany(p => p.Monsters)
                    .HasForeignKey(d => d.PrimaryElementId)
                    .HasConstraintName("FK__Monsters__Primar__72C60C4A");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Monsters)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__Monsters__SizeID__71D1E811");
            });

            modelBuilder.Entity<MonstersHabit>(entity =>
            {
                entity.HasKey(e => new { e.MonsterId, e.HabitId })
                    .HasName("PK__Monsters__F04D3A367108AAFA");

                entity.ToTable("Monsters_Habits");

                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");

                entity.Property(e => e.HabitId).HasColumnName("HabitID");

                entity.HasOne(d => d.Habit)
                    .WithMany(p => p.MonstersHabits)
                    .HasForeignKey(d => d.HabitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Monsters___Habit__6C190EBB");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.MonstersHabits)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Monsters___Monst__70DDC3D8");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.HunterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MonsterId).HasColumnName("MonsterID");

                entity.Property(e => e.RecordedMonsterSize).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TimeTaken).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.MonsterId)
                    .HasConstraintName("FK__Records__Monster__6FE99F9F");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK__Records__WeaponI__68487DD7");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeCeiling).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SizeFloor).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.Property(e => e.AilmentId).HasColumnName("AilmentID");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeaponTypeId).HasColumnName("WeaponTypeID");

                entity.HasOne(d => d.Ailment)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.AilmentId)
                    .HasConstraintName("FK__Weapons__Ailment__52593CB8");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK__Weapons__Element__5165187F");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .HasConstraintName("FK__Weapons__WeaponT__5070F446");
            });

            modelBuilder.Entity<WeaponType>(entity =>
            {
                entity.Property(e => e.WeaponTypeId).HasColumnName("WeaponTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

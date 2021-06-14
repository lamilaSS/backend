using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using mcq_backend.Model;
using mcq_backend.Model.DefaultModel;
using mcq_backend.Model.Keyless;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Helper.Context
{
    public class DBContext : DbContext
    {
        private readonly int _userId;

        public DBContext(DbContextOptions options, ClaimProvider provider) : base(options)
        {
            _userId = provider.UserId;
        }

        public DbSet<Idoru> Idoru { get; set; }
        
        public DbSet<IdoruKeyless> IdoruKeylesses { get; set; }
        
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameQuestion> GameQuestions { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Lifeline> Lifelines { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<ScoreDetail> ScoreDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId)
                    .ValueGeneratedNever()
                    .HasColumnName("answerID");

                entity.Property(e => e.AnswerContent)
                    .HasMaxLength(200)
                    .HasColumnName("answerContent");

                entity.Property(e => e.IsCorrect)
                    .HasColumnType("bit(1)")
                    .HasColumnName("isCorrect");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("Answer_questionID_fkey");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId)
                    .ValueGeneratedNever()
                    .HasColumnName("gameID");

                entity.Property(e => e.GameDescription)
                    .HasMaxLength(100)
                    .HasColumnName("gameDescription");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Time)
                    .HasMaxLength(50)
                    .HasColumnName("time");
            });

            modelBuilder.Entity<GameQuestion>(entity =>
            {
                entity.ToTable("GameQuestion");

                entity.Property(e => e.GameQuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("gameQuestionID");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameQuestions)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("GameQuestion_gameID_fkey");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.GameQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("GameQuestion_questionID_fkey");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("historyID");

                entity.Property(e => e.Date)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("date");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.NumOfCorrect).HasColumnName("numOfCorrect");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.ScoreDetailId).HasColumnName("scoreDetailID");

                entity.Property(e => e.Session)
                    .HasMaxLength(100)
                    .HasColumnName("session")
                    .IsFixedLength(true);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TimeFinished)
                    .HasMaxLength(50)
                    .HasColumnName("timeFinished");

                entity.Property(e => e.TotalQuestion).HasColumnName("totalQuestion");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("userID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("History_gameID_fkey");

                entity.HasOne(d => d.ScoreDetail)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.ScoreDetailId)
                    .HasConstraintName("History_scoreDetailID_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("History_userID_fkey");
            });

            modelBuilder.Entity<Lifeline>(entity =>
            {
                entity.ToTable("Lifeline");

                entity.Property(e => e.LifelineId)
                    .ValueGeneratedNever()
                    .HasColumnName("lifelineID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Lifelines)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("Lifeline_gameID_fkey");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("questionID");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .HasColumnName("creator");

                entity.Property(e => e.Difficulty).HasColumnName("difficulty");

                entity.Property(e => e.QuestionContent)
                    .HasMaxLength(200)
                    .HasColumnName("questionContent");
            });

            modelBuilder.Entity<ScoreDetail>(entity =>
            {
                entity.ToTable("ScoreDetail");

                entity.Property(e => e.ScoreDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("scoreDetailID");

                entity.Property(e => e.IsCorrect)
                    .HasColumnType("bit(1)")
                    .HasColumnName("isCorrect");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.ScoreDetails)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("ScoreDetail_questionID_fkey1");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.ScoreDetails)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("ScoreDetail_questionID_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("userID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("createDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(500)
                    .HasColumnName("feedback");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .HasColumnName("image");

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.UserStatus).HasColumnName("userStatus");
            });
        }

        /**
         * This method use for adding time at creation
         * or update time of an entity if created
         */
        private void UpdateOrCreatedTime()
        {
            // set create or update date time
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DefaultEntity && (
                    e.State is EntityState.Added or EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((DefaultEntity) entityEntry.Entity).LastUpdated = DateTime.UtcNow;
                if (entityEntry.State == EntityState.Added)
                {
                    ((DefaultEntity) entityEntry.Entity).Created = DateTime.UtcNow;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateOrCreatedTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateOrCreatedTime();
            return base.SaveChanges();
        }
    }
}
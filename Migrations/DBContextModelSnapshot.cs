﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using mcq_backend.Helper.Context;

namespace mcq_backend.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "en_US.utf8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("mcq_backend.Model.Answer", b =>
                {
                    b.Property<Guid>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("answerID");

                    b.Property<string>("AnswerContent")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("answerContent");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean")
                        .HasColumnName("isCorrect");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("questionID");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("mcq_backend.Model.Game", b =>
                {
                    b.Property<Guid>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("gameID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<string>("GameDescription")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("gameDescription");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Time")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("time");

                    b.HasKey("GameId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("mcq_backend.Model.GameQuestion", b =>
                {
                    b.Property<Guid>("GameQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("gameQuestionID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("gameID");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("questionID");

                    b.HasKey("GameQuestionId");

                    b.HasIndex("GameId");

                    b.HasIndex("QuestionId");

                    b.ToTable("GameQuestion");
                });

            modelBuilder.Entity("mcq_backend.Model.History", b =>
                {
                    b.Property<Guid>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("historyID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("gameID");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<int?>("NumOfCorrect")
                        .HasColumnType("integer")
                        .HasColumnName("numOfCorrect");

                    b.Property<int?>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.Property<Guid?>("ScoreDetailId")
                        .HasColumnType("uuid")
                        .HasColumnName("scoreDetailID");

                    b.Property<string>("Session")
                        .HasMaxLength(100)
                        .HasColumnType("character(100)")
                        .HasColumnName("session")
                        .IsFixedLength(true);

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("TimeFinished")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("timeFinished");

                    b.Property<int?>("TotalQuestion")
                        .HasColumnType("integer")
                        .HasColumnName("totalQuestion");

                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("userID");

                    b.HasKey("HistoryId");

                    b.HasIndex("GameId");

                    b.HasIndex("ScoreDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("mcq_backend.Model.Idoru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Addr")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("addr");

                    b.Property<short>("Age")
                        .HasColumnType("smallint")
                        .HasColumnName("age");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean")
                        .HasColumnName("gender");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("idoru");
                });

            modelBuilder.Entity("mcq_backend.Model.Keyless.IdoruKeyless", b =>
                {
                    b.Property<string>("Addr")
                        .HasColumnType("text");

                    b.Property<short>("Age")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.ToTable("IdoruKeylesses");
                });

            modelBuilder.Entity("mcq_backend.Model.Keyless.QuestionKeyless", b =>
                {
                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<string>("creator")
                        .HasColumnType("text");

                    b.Property<int?>("difficulty")
                        .HasColumnType("integer");

                    b.Property<string>("questionContent")
                        .HasColumnType("text");

                    b.Property<Guid>("questionID")
                        .HasColumnType("uuid");

                    b.ToTable("QuestionKeylesses");
                });

            modelBuilder.Entity("mcq_backend.Model.Lifeline", b =>
                {
                    b.Property<Guid>("LifelineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("lifelineID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uuid")
                        .HasColumnName("gameID");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<int?>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("LifelineId");

                    b.HasIndex("GameId");

                    b.ToTable("Lifeline");
                });

            modelBuilder.Entity("mcq_backend.Model.Question", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("questionID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<string>("Creator")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("creator");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("integer")
                        .HasColumnName("difficulty");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<string>("QuestionContent")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("questionContent");

                    b.HasKey("QuestionId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("mcq_backend.Model.ScoreDetail", b =>
                {
                    b.Property<Guid>("ScoreDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("scoreDetailID");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean")
                        .HasColumnName("isCorrect");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("questionID");

                    b.HasKey("ScoreDetailId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ScoreDetail");
                });

            modelBuilder.Entity("mcq_backend.Model.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("userID");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createDate");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Feedback")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("feedback");

                    b.Property<string>("Fullname")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("fullname");

                    b.Property<string>("Image")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("image");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("lastupdated");

                    b.Property<string>("Password")
                        .HasMaxLength(60)
                        .HasColumnType("character(60)")
                        .HasColumnName("password")
                        .IsFixedLength(true);

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("character(10)")
                        .HasColumnName("phone")
                        .IsFixedLength(true);

                    b.Property<int?>("UserStatus")
                        .HasColumnType("integer")
                        .HasColumnName("userStatus");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("mcq_backend.Model.Answer", b =>
                {
                    b.HasOne("mcq_backend.Model.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("Answer_questionID_fkey");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("mcq_backend.Model.GameQuestion", b =>
                {
                    b.HasOne("mcq_backend.Model.Game", "Game")
                        .WithMany("GameQuestions")
                        .HasForeignKey("GameId")
                        .HasConstraintName("GameQuestion_gameID_fkey");

                    b.HasOne("mcq_backend.Model.Question", "Question")
                        .WithMany("GameQuestions")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("GameQuestion_questionID_fkey");

                    b.Navigation("Game");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("mcq_backend.Model.History", b =>
                {
                    b.HasOne("mcq_backend.Model.Game", "Game")
                        .WithMany("Histories")
                        .HasForeignKey("GameId")
                        .HasConstraintName("History_gameID_fkey");

                    b.HasOne("mcq_backend.Model.ScoreDetail", "ScoreDetail")
                        .WithMany("Histories")
                        .HasForeignKey("ScoreDetailId")
                        .HasConstraintName("History_scoreDetailID_fkey");

                    b.HasOne("mcq_backend.Model.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .HasConstraintName("History_userID_fkey");

                    b.Navigation("Game");

                    b.Navigation("ScoreDetail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("mcq_backend.Model.Lifeline", b =>
                {
                    b.HasOne("mcq_backend.Model.Game", "Game")
                        .WithMany("Lifelines")
                        .HasForeignKey("GameId")
                        .HasConstraintName("Lifeline_gameID_fkey");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("mcq_backend.Model.ScoreDetail", b =>
                {
                    b.HasOne("mcq_backend.Model.Game", "Question")
                        .WithMany("ScoreDetails")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("ScoreDetail_questionID_fkey1");

                    b.HasOne("mcq_backend.Model.Question", "QuestionNavigation")
                        .WithMany("ScoreDetails")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("ScoreDetail_questionID_fkey");

                    b.Navigation("Question");

                    b.Navigation("QuestionNavigation");
                });

            modelBuilder.Entity("mcq_backend.Model.Game", b =>
                {
                    b.Navigation("GameQuestions");

                    b.Navigation("Histories");

                    b.Navigation("Lifelines");

                    b.Navigation("ScoreDetails");
                });

            modelBuilder.Entity("mcq_backend.Model.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("GameQuestions");

                    b.Navigation("ScoreDetails");
                });

            modelBuilder.Entity("mcq_backend.Model.ScoreDetail", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("mcq_backend.Model.User", b =>
                {
                    b.Navigation("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}

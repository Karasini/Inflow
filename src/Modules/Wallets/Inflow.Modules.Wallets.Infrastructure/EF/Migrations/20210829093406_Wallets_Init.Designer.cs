﻿// <auto-generated />
using System;
using Inflow.Modules.Wallets.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Inflow.Modules.Wallets.Infrastructure.EF.Migrations
{
    [DbContext(typeof(WalletsDbContext))]
    [Migration("20210829093406_Wallets_Init")]
    partial class Wallets_Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("wallets")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Owners.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasDiscriminator<string>("Type").HasValue("Owner");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Metadata")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Transfers");

                    b.HasDiscriminator<string>("Type").HasValue("Transfer");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.Wallet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId", "Currency")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Inflow.Shared.Infrastructure.Messaging.Outbox.InboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Inbox");
                });

            modelBuilder.Entity("Inflow.Shared.Infrastructure.Messaging.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("SentAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TraceId")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Outbox");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Owners.Entities.CorporateOwner", b =>
                {
                    b.HasBaseType("Inflow.Modules.Wallets.Core.Owners.Entities.Owner");

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("CorporateOwner");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Owners.Entities.IndividualOwner", b =>
                {
                    b.HasBaseType("Inflow.Modules.Wallets.Core.Owners.Entities.Owner");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("IndividualOwner");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.IncomingTransfer", b =>
                {
                    b.HasBaseType("Inflow.Modules.Wallets.Core.Wallets.Entities.Transfer");

                    b.HasDiscriminator().HasValue("IncomingTransfer");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.OutgoingTransfer", b =>
                {
                    b.HasBaseType("Inflow.Modules.Wallets.Core.Wallets.Entities.Transfer");

                    b.HasDiscriminator().HasValue("OutgoingTransfer");
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.Transfer", b =>
                {
                    b.HasOne("Inflow.Modules.Wallets.Core.Wallets.Entities.Wallet", null)
                        .WithMany("Transfers")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.Wallet", b =>
                {
                    b.HasOne("Inflow.Modules.Wallets.Core.Owners.Entities.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inflow.Modules.Wallets.Core.Wallets.Entities.Wallet", b =>
                {
                    b.Navigation("Transfers");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KaraokeApi.Models;

namespace KaraokeApi.Migrations
{
    [DbContext(typeof(KaraokeContext))]
    [Migration("20170806160009_ReAddStageName")]
    partial class ReAddStageName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("KaraokeApi.Models.KaraokeSession", b =>
                {
                    b.Property<int>("KaraokeSessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<string>("SessionName");

                    b.HasKey("KaraokeSessionId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("KaraokeApi.Models.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsComplete");

                    b.Property<int>("SessionId");

                    b.Property<string>("StageName");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });
        }
    }
}

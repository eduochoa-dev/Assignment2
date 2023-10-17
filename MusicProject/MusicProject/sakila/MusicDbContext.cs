using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicProject.sakila;

public partial class MusicDbContext : DbContext
{
    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Playlistsong> Playlistsongs { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;database=music_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.IdArtist).HasName("PRIMARY");

            entity.ToTable("artists");

            entity.Property(e => e.IdArtist)
                .HasColumnType("int(8)")
                .HasColumnName("id_artist");
            entity.Property(e => e.ArtistName)
                .HasMaxLength(25)
                .HasColumnName("artist_name");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.IdPlaylist).HasName("PRIMARY");

            entity.ToTable("playlists");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.IdPlaylist)
                .HasColumnType("int(8)")
                .HasColumnName("id_playlist");
            entity.Property(e => e.PlaylistName)
                .HasMaxLength(50)
                .HasColumnName("playlist_name");
            entity.Property(e => e.UserId)
                .HasColumnType("int(8)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("playlists_ibfk_1");
        });

        modelBuilder.Entity<Playlistsong>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("playlistsong");

            entity.HasIndex(e => e.PlaylistId, "playlist_id");

            entity.HasIndex(e => e.SongId, "song_id");

            entity.Property(e => e.PlaylistId)
                .HasColumnType("int(8)")
                .HasColumnName("playlist_id");
            entity.Property(e => e.SongId)
                .HasColumnType("int(8)")
                .HasColumnName("song_id");

            entity.HasOne(d => d.Playlist).WithMany()
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playlistsong_ibfk_1");

            entity.HasOne(d => d.Song).WithMany()
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playlistsong_ibfk_2");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.IdSong).HasName("PRIMARY");

            entity.ToTable("songs");

            entity.HasIndex(e => e.ArtistId, "artist_id");

            entity.Property(e => e.IdSong)
                .HasColumnType("int(8)")
                .HasColumnName("id_song");
            entity.Property(e => e.ArtistId)
                .HasColumnType("int(8)")
                .HasColumnName("artist_id");
            entity.Property(e => e.SongName)
                .HasMaxLength(50)
                .HasColumnName("song_name");
            entity.Property(e => e.SongYear)
                .HasColumnType("int(11)")
                .HasColumnName("song_year");

            entity.HasOne(d => d.Artist).WithMany(p => p.Songs)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("songs_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.IdUser)
                .HasColumnType("int(8)")
                .HasColumnName("id_user");
            entity.Property(e => e.Username)
                .HasMaxLength(25)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

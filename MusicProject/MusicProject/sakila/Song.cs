using System;
using System.Collections.Generic;

namespace MusicProject.sakila;

public partial class Song
{
    public int IdSong { get; set; }

    public string SongName { get; set; } = null!;

    public int SongYear { get; set; }

    public int? ArtistId { get; set; }

    public virtual Artist? Artist { get; set; }
}

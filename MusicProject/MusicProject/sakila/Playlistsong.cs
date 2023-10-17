using System;
using System.Collections.Generic;

namespace MusicProject.sakila;

public partial class Playlistsong
{
    public int PlaylistId { get; set; }

    public int SongId { get; set; }

    public virtual Playlist Playlist { get; set; } = null!;

    public virtual Song Song { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace MusicProject.sakila;

public partial class Playlist
{
    public int IdPlaylist { get; set; }

    public string PlaylistName { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}

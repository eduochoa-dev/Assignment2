using System;
using System.Collections.Generic;

namespace MusicProject.sakila;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}

using System;
using System.Collections.Generic;

namespace MusicProject.sakila;

public partial class Artist
{
    public int IdArtist { get; set; }

    public string ArtistName { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}

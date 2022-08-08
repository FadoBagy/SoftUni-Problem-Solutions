﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [ForeignKey(Song)]
        public int SongId { get; set; }
        public Song Song { get; set; }

        [ForeignKey(Song)]
        public int PerformerId { get; set; }
        public Performer Performer { get; set; }
    }
}

using MusicHub.Data.Models.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            SongPerformers = new List<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        // TODO: Define Relations
        [ForeignKey(Album)]
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        [ForeignKey(Writer)]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }
    }
}

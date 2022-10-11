namespace ForumApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Post;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength,
            MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}

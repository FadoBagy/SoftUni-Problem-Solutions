namespace ForumApp.Models.Posts
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Post; 

    public class PostFormModel
    {
        [Required]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = "{0} length should be between {2} and {1}")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength,
            MinimumLength = ContentMinLength,
            ErrorMessage = "{0} length should be between {2} and {1}")]
        public string Content { get; set; } = null!;
    }
}

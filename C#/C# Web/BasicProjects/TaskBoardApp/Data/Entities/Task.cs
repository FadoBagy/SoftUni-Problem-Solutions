namespace TaskBoardApp.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.Task;
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTaskTitle,
            MinimumLength = MinTaskTitle,
            ErrorMessage = errorString)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MaxTaskDescription,
            MinimumLength = MinTaskDescription,
            ErrorMessage = errorString)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board Board { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        public User Owner { get; set; } = null!;
    }
}

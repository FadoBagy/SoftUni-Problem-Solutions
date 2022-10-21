namespace TaskBoardApp.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    using static DataConstants.Board;

    public class Board
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxBoardName,
            MinimumLength = MinBoardName,
            ErrorMessage = errorString)]
        public string Name { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; }
            = new List<Task>();
    }
}

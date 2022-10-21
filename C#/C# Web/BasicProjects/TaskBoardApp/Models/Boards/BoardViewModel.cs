namespace TaskBoardApp.Models.Boards
{
    using TaskBoardApp.Models.Task;

    public class BoardViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<TaskViewModel> Tasks { get; set; }
            = new List<TaskViewModel>();
    }
}

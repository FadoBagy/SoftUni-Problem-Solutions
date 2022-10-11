namespace ForumApp.Data
{
    using ForumApp.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }

        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<Post> Posts { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedPosts();
            builder
                .Entity<Post>()
                .HasData(this.FirstPost,
                    this.SecondPost,
                    this.ThirdPost);

            base.OnModelCreating(builder);
        }

        private void SeedPosts()
        {
            this.FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post is so fun!"
            };

            this.SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post, CRUD operations are the best!"
            };

            this.ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Hello there, I am getting better at this!"
            };
        }
    }
}

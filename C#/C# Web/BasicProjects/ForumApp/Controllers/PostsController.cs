namespace ForumApp.Controllers
{
    using ForumApp.Data;
    using ForumApp.Data.Models;
    using ForumApp.Models.Posts;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly ForumAppDbContext data;
        public PostsController(ForumAppDbContext data)
        {
            this.data = data;
        }

        public IActionResult All()
        {
            var posts = data.Posts
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToList();

            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PostFormModel post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var newPost = new Post()
            {
                Title = post.Title,
                Content = post.Content
            };

            data.Posts.Add(newPost);
            data.SaveChanges();

            return RedirectToAction("All", "Posts");
        }

        public IActionResult Edit(int id)
        {
            var post = this.data.Posts.Find(id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, PostFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = this.data.Posts.Find(id);
            post.Title = model.Title;
            post.Content = model.Content;

            this.data.SaveChanges();

            return RedirectToAction("All", "Posts");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var post = this.data.Posts.Find(id);
            this.data.Posts.Remove(post);
            this.data.SaveChanges();

            return RedirectToAction("All", "Posts");
        }
    }
}

using SocialMediaApi.Data;
using SocialMediaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApiServices
{
    public class PostService
    {
        private readonly Guid _userId;
        //_user id = user id

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
             {
                 Text = model.Texts,
                 Title = model.Title

             };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            var query = ctx
                .Posts
                .Select(e =>
                new PostListItem
                {
                    Title = e.Title,
                    Text = e.Text
                    )
        }
    }
}

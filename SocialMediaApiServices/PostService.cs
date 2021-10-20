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
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
             {
                AuthorId = _authorId,
                Text = model.Texts,
                 Comments = model.Comments,
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
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                    .Posts
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                    new PostListItem
                    {
                        Id = e.Id,
                        Title = e.Title,
                        Text = e.Text,
                        Comments = e.Comments
                    }
                    );
                return query.ToArray();
            }
        }

        public PostDetails GetPostByAuthorId(Guid authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.AuthorId == authorId);
                return
                    new PostDetails
                    {

                        Title = entity.Title,
                        Text = entity. Text,


                    };
            }
        }
        //UpdateNote that returns a bool based on if noteid is in database
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Title == model.Title);

                entity.Title = model.Title;
                entity.Comments = model.Comments;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == id);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
            
    }

}

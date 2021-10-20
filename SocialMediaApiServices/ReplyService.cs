using SocialMediaApi.Data;
using SocialMediaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApiServices
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            CommentId = e.Id,
                            Text = e.Text,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();

            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.Id == id && e.AuthorId == _userId);
                return
                    new ReplyDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModiefiedUtc
                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.Id == model.CommentId && e.AuthorId == _userId);

                entity.Text = model.Text;
                entity.ModiefiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReply(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.Id == Id && e.AuthorId == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

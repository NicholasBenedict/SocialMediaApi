using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApi.Data
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Comment Comment { get; set; }
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModiefiedUtc { get; set; }
}
}

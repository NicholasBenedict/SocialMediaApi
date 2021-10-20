using SocialMediaApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApi.Models
{
    public class CommentDetails
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<Reply> Replies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApi.Models
{
    public class ReplyCreate
    {
        [Required]
        public string Text { get; set; }
        public string CommentId { get; set; }
    }
}

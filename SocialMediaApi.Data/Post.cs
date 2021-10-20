using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApi.Data
{
    public class Post
    {   
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        //Virtual list of comments
        public virtual List<Comment> Comments { get; set; }
        //Virtual list of likes - if applicable 
      /*    public virtual Like Likes { get; set; }*/
        public Guid AuthorId { get; set; }

    }
}

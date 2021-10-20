using SocialMediaApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApi.Models
{
   public class PostListItem
   {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Comment Comments { get; set; }
   }
}

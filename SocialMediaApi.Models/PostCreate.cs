﻿using SocialMediaApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApi.Models
{
   public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters.")]
        public string Title { get; set; }
        public virtual Comment Comments { get; set; }
        [MaxLength(8000)]
        public string Texts { get; set; }
        public Guid AuthorId { get; set; }
    }
}

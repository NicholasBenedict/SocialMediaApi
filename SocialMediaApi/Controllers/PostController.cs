using SocialMediaApi.Models;
using SocialMediaApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace SocialMediaApi.Controllers
{
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var authorId=Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(authorId);
            return postService;
        }
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var post = postService.GetPosts();
            return Ok(post);
        }
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        //Get Method by Id
        public IHttpActionResult Get(Guid authorId)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostByAuthorId(authorId);
            return Ok(post);
        }

        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}

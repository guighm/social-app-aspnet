using dotnet_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController(IPostService postService, ICommentService commentService, ILikeService likeService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        var posts = await postService.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{id:long}/comments")]
    public async Task<IActionResult> GetAllComments(long id)
    {
        var comments = await commentService.GetAllComments(id);
        return Ok(comments);
    }
    
    [HttpGet("{id:long}/likes/count")]
    public async Task<IActionResult> GetLikesCount(long id)
    {
        var number = await likeService.GetLikesCount(id);
        return Ok(number);
    }
}
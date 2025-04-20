using dotnet_backend.Dtos;
using dotnet_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController(ICommentService commentService, IPostService postService, IUserService userService): ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var comment = await commentService.GetById(id);
        return comment == null ? NotFound() : Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto dto)
    {
        var user = await userService.GetOne(dto.Username);
        if (user == null) return NotFound();
        
        var post = await postService.GetOne(dto.PostId);
        if (post == null) return NotFound();

        var comment = await commentService.CreateComment(dto, user, post);

        return CreatedAtAction(nameof(GetById), new {id = comment.Id}, comment);
    }
    
}
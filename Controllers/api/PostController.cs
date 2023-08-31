namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var posts = _postService.GetAll();
        return Ok(posts);
    }
}
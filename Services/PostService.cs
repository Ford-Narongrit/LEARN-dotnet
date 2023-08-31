namespace WebApi.Services;

using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;

public interface IPostService
{
    IEnumerable<Post> GetAll();
    Post GetById(int id);
    void Create(Post model);
    void Update(int id, Post model);
    void Delete(int id);
}

public class PostService : IPostService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Post> GetAll()
    {
        return _context.Posts;
    }

    public Post GetById(int id)
    {
        return getPost(id);
    }

    public void Create(Post model)
    {
        // save post
        _context.Posts.Add(model);
        _context.SaveChanges();
    }

    public void Update(int id, Post model)
    {
        var post = getPost(id);

        // copy model to post and save
        _mapper.Map(model, post);
        _context.Posts.Update(post);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var post = getPost(id);
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }

    // helper methods

    private Post getPost(int id)
    {
        var post = _context.Posts.Find(id) ?? throw new KeyNotFoundException("Post not found");
        return post;
    }
}
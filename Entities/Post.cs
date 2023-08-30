namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Descirption { get; set; }
}
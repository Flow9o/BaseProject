namespace BaseProject.Domain.Model;

public class Bookmark
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required string Link { get; set; }
	public required DateTime CreatedAt { get; set; }
	public required string CreatedBy { get; set; }
	public DateTime? ModifiedAt { get; set; }
	public string? ModifiedBy { get; set; }
	public IList<User> Users { get; set; } = [];
}

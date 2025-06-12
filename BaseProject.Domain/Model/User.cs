namespace BaseProject.Domain.Model;

public class User
{
	public int Id { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string EMail { get; set; }
	public required string Password { get; set; } //ACHTUNG PASSWOERTER NIE IM KLARTEXT ABSPEICHERN ODER VERSCHICKEN. NUR FUER TESTZWECKE
	public IList<Bookmark> Bookmarks { get; set; } = [];
}
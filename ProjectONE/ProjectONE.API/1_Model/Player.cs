namespace ProjectONE.API.Model;

public class Player
{
    public int Id { get; set;}
  //  public required string Username { get; set; }
    //public string Password { get; set; }
   // public int EquippedItem { get; set; }
    public List<int> Items { get; set; } = [];
    public int Room { get; set; }
    public int Health { get; set; }
}
namespace Project1._1_Model;

public class Player
{
    public int Id { get; set;}
    public required string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public string EquippedWeapon { get; set; }

    public List<Item> Inventory { get; set; } = [];
    
    public int Room { get; set; }
    public int Health { get; set; }
}
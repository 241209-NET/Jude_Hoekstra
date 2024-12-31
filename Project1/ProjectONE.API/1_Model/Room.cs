namespace ProjectONE.API.Model;

public class Room
{
    public int Id { get; set;}

    public List<Item> Inventory { get; set; } = [];
    public List<Enemy> Enemies { get; set; } = [];
}
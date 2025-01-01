namespace ProjectONE.API.Model;

public class Enemy
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public string Description { get; set;}
    public required int Health { get; set; }
    public int Damage { get; set; }
    public int Room { get; set; }
}
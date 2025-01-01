namespace ProjectONE.API.Model;

public class Item
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public int? damage { get; set; } 
    public string? description { get; set; }
    public required int Room {get;set;}
}
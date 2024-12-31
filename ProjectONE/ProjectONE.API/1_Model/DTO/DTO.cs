using System.ComponentModel.DataAnnotations;
using ProjectONE.API.Model;


namespace ProjectONE.API.DTO;

public class PlayerInDTO
{
    public required string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public int EquippedItem { get; set; }

    public List<Item> Items { get; set; } = [];
    
    public int Room { get; set; }
    public int Health { get; set; }
}

public class PlayerOutDTO
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public int EquippedItem { get; set; }

    public List<Item> Items { get; set; } = [];
    
    public int Room { get; set; }
    public int Health { get; set; }
}

public class ItemInDTO
{
    public string Name { get; set;}
    public int damage { get; set; }
    public string description { get; set; }
}

public class ItemOutDTO
{
    public int Id { get; set; }
    public string Name { get; set;}
    public int damage { get; set; }
    public string description { get; set; }
}

public class RoomInDTO
{
    public List<Item> Items { get; set; } = [];
    public List<Enemy> Enemies { get; set; } = [];
}

public class RoomOutDTO
{
    public int Id { get; set; }
    public List<Item> Items { get; set; } = [];
    public List<Enemy> Enemies { get; set; } = [];
}

public class EnemyInDTO
{
    public int health { get; set; }
    public int damage { get; set; }
}


public class EnemyOutDTO
{
    public int Id { get; set; }
    public int health { get; set; }
    public int damage { get; set; }
}

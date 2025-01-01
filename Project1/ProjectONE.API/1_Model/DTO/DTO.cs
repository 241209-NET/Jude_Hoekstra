using System.ComponentModel.DataAnnotations;
using ProjectONE.API.Model;


namespace ProjectONE.API.DTO;

public class PlayerInDTO
{
   // public required string Username { get; set; }
  //  public string Password { get; set; }
   // public string Email { get; set; }

  //  public int EquippedItem { get; set; }

    public List<int> Items { get; set; } = [];
    
    public int? Room { get; set; }
    public int? Health { get; set; }
}

public class PlayerOutDTO
{
    public int Id { get; set; }
   // public required string Username { get; set; }
 //   public string Password { get; set; }
  //  public string Email { get; set; }

   // public int EquippedItem { get; set; }

    public List<int> Items { get; set; } = [];
    
    public int? Room { get; set; }
    public int? Health { get; set; }
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


public class EnemyInDTO
{
    public required string Name { get; set;}
    public string Description { get; set;}
    public required int Health { get; set; }
    public int Damage { get; set; }
    public int Room { get; set; }
}


public class EnemyOutDTO
{
    public int Id { get; set; } public required string Name { get; set;}
    public string Description { get; set;}
    public required int Health { get; set; }
    public int Damage { get; set; }
    public int Room { get; set; }
}

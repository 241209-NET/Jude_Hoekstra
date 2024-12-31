using Microsoft.EntityFrameworkCore;
using ProjectONE.API.Model;

namespace ProjectONE.API.Data;

public partial class DataContext : DbContext
{
    public DataContext(){}
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Enemy> Enemies { get; set; }
    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }

}
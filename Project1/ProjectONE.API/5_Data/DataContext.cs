using Microsoft.EntityFrameworkCore;
using ProjectONE._1_Model;

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
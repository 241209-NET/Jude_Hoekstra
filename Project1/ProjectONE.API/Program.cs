var builder = WebApplication.CreateBuilder(args);
//Add dbcontext and connect it to connection string
builder.Services.AddDbContext<ProjectONEContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectONEdb")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Inject the proper services
builder.Services.AddScoped<IPetService, PlayerService>();
builder.Services.AddScoped<IOwnerService, ItemService>();

//Dependency Inject the proper repositories
builder.Services.AddScoped<IPetRepository, PlayerRepository>();
builder.Services.AddScoped<IOwnerRepository, ItemRepository>();

//Add automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Add our controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
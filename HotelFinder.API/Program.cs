using HotelFinder.Business.Concrete;
using HotelFinder.Business.Interface;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.DataAccess.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService,HotelManager>();
builder.Services.AddSingleton<IHotelRepository,HotelRepository>();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "All Hotels Api";
        doc.Info.Version = "1.0.0";
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();

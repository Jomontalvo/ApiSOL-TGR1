using TgrManagement.Api.Endpoints;
using TgrManagement.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// ====== Services =====
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();

builder.Services.AddHttpClient<ITgrCentralService, TgrCentralService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["TgrApi:BaseAddress"]!); 
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.Timeout = TimeSpan.FromSeconds(90); 
});


var app = builder.Build();

//====== Middleware =====
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../openapi/v1.json", "TGR-1 SOL Api");
    c.RoutePrefix = "swagger";
});
}
app.UseHttpsRedirection();
app.UseCors();

#region Endpoints Configuration
app.MapGroup("/api/listas").MapLists();
app.MapGroup("/api/recibos").MapReceipts();
#endregion Endpoints Configuration

app.Run();
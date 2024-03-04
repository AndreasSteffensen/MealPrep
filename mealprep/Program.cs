using MealPrep.Components;
using MealPrep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

//TODO: make it so it only runs on very first run. otherwise it will override data. which we dont want...
//DatabaseHelper.initializeDatabase();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

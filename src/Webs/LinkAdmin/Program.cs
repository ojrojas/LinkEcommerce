
using LinkEcommerce.Webs.LinkAdmin.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.AddServiceApplications(configuration);
builder.Services.AddDIOpenIddictApplication(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

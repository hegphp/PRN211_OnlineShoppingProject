var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(60));
var app = builder.Build();

app.MapGet("/", context => {
    context.Response.Redirect("/home");
    return Task.CompletedTask;
});

app.MapControllerRoute(
    name: "Homepage",
    pattern: "/home/{action=index}",
    defaults: new { controller = "Home" }
    );

app.MapControllerRoute(
    name: "Login",
    pattern: "/login/{action=index}",
    defaults: new { controller = "Login" }
    );

app.MapControllerRoute(
        name: "default",
        pattern: "/{controller}/{action}"
    );

app.MapControllerRoute(
        name: "default",
        pattern: "/{controller}/{action}/{var}"
    );

app.Run();

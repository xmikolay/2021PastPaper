using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCWebApp2021.Data;
using ClassLibrary2021;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();  // ← ADD THIS LINE TO AVOID ERRORS WITH RAZOR PAGES, IDK

// Configure your DbContext
builder.Services.AddDbContext<HireContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity DbContext (SEPARATE DATABASE!)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityConnection")));

// Add Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Seed users and roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // Create roles
    string[] roles = { "Admin", "Manager", "Employee" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // User 1: Margaret Sutton (Admin)
    var adminEmail = "admin@carhire.ie";
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var admin = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(admin, "Admin$1");
        await userManager.AddToRolesAsync(admin, new[] { "Admin", "Manager", "Employee" });
    }

    // User 2: Bill Bloggs (Manager)
    var managerEmail = "bloggsb@carhire.ie";
    if (await userManager.FindByEmailAsync(managerEmail) == null)
    {
        var manager = new IdentityUser
        {
            UserName = managerEmail,
            Email = managerEmail,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(manager, "Manager$1");  // ← Different password
        await userManager.AddToRolesAsync(manager, new[] { "Employee", "Manager" });
    }

    // User 3: Paul Savage (Employee)
    var employee1Email = "savagep@carhire.ie";
    if (await userManager.FindByEmailAsync(employee1Email) == null)
    {
        var employee1 = new IdentityUser
        {
            UserName = employee1Email,
            Email = employee1Email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(employee1, "Employee$1");  // ← Different password
        await userManager.AddToRoleAsync(employee1, "Employee");
    }

    // User 4: Martha Rotter (Employee)
    var employee2Email = "rotterp@carhire.ie";
    if (await userManager.FindByEmailAsync(employee2Email) == null)
    {
        var employee2 = new IdentityUser
        {
            UserName = employee2Email,
            Email = employee2Email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(employee2, "Employee$2");  // ← Different password!
        await userManager.AddToRoleAsync(employee2, "Employee");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); //authentication always goes first
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    /*
     * การกำหนดแบบนี้มีวัตถุประสงค์เพื่อแยก layout หรือ view ให้แยกจากกัน
     * โดยหากต้องการแก้ไขในส่วนใด ให้เข้าไปยังส่วนนั้นที่ต้อง
     */

    options.AreaViewLocationFormats.Add("/LIFF/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/LIFF/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/LIFF/Views/Shared/{0}.cshtml");

    options.AreaViewLocationFormats.Add("/Web/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Web/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Web/Views/Shared/{0}.cshtml");
});
builder.Services.AddMediatR(new[]
{
    Core.Line.Liff.AssemblyHelper.RegisterAllLiffWebService(),
    Core.Web.AssemblyHelper.RegisterWebService()
});
builder.Services.AddLineBot(builder.Configuration);
builder.Services.AddLineUserDB(builder.Configuration);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
// กำหนด default route ของ liff website
app.MapControllerRoute(
    name: "liff",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
// กำหนด default route ของ web backend ทั่วไป
app.MapControllerRoute(
    name: "web",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
app.Run();

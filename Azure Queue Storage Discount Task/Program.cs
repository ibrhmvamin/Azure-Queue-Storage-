using Azure_Queue_Storage_Discount_Task.Services.Abstracts;
using Azure_Queue_Storage_Discount_Task.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetSection("AzureStorage:ConnectionString").Value;
builder.Services.AddSingleton<IQueueService>(sp => new QueueService(connectionString, "count"));

builder.Services.AddSingleton<IDiscountQueueService>(sp => new DiscountQueueService(connectionString, "discount"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Queue}/{action=Index}/{id?}");

app.Run();

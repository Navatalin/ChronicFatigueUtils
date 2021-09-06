using ChronicFatigueUtils.Data;
using ChronicFatigueUtils.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.Configure<TaskDatabaseSettings>(builder.Configuration.GetSection(nameof(TaskDatabaseSettings)));
builder.Services.AddSingleton<ITaskDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TaskDatabaseSettings>>().Value);
builder.Services.AddSingleton<TaskService>();
builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization("en-AU");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

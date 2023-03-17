using ItAgency_bdCRUD.Models;
using ItAgency_bdCRUD.Service;
using ItAgency_bdCRUD.Service.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItAgency_bdCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ItAgencyContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IClientServiceable, ClientService>();
            //bilder.Services.AddTransient - двже если два раза к нему обратитьс€ в одном методе, он создаст новый сервис каждый раз
            //bilder.Services.AddScopped - в рамках одного запроса всегда будут одни и те же данные даже если мы обращаемс€ к нему
            //дважды в рамках одного метода, но уже со следующим зарпосом в базу эти данные будут отличатьс€,
            //он посмотрит есть ли уже такой экземпл€р и покажет, новый без необходимости создавать не будет
            //bilder.Services.AddSingleton - врем€ жизни этого сервиса равно времени жизни нашего приложени€ - пока оно работает он тоже жив,
            //то есть состо€ние объекта не помен€етс€ до тех пор пока жив апп

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
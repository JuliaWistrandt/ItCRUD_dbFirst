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
            //bilder.Services.AddTransient - ���� ���� ��� ���� � ���� ���������� � ����� ������, �� ������� ����� ������ ������ ���
            //bilder.Services.AddScopped - � ������ ������ ������� ������ ����� ���� � �� �� ������ ���� ���� �� ���������� � ����
            //������ � ������ ������ ������, �� ��� �� ��������� �������� � ���� ��� ������ ����� ����������,
            //�� ��������� ���� �� ��� ����� ��������� � �������, ����� ��� ������������� ��������� �� �����
            //bilder.Services.AddSingleton - ����� ����� ����� ������� ����� ������� ����� ������ ���������� - ���� ��� �������� �� ���� ���,
            //�� ���� ��������� ������� �� ���������� �� ��� ��� ���� ��� ���

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
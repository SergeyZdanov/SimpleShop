using Database;
using Database.Interface;
using Database.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API.Controllers;
using API.Mappers;
using API.Services;
using Services.Intefraces;
using Services.Services;
using System.Text.Json.Serialization;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IItemServices, ItemServices>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();

            builder.Services.AddScoped<IOrderItemService, OrderItemService>();
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            builder.Services.AddScoped<IAuthServices, AuthServices>();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<UserController>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(CustomerMapper)));
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(OrderMapper)));
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(ItemMapper)));
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(OrderItemMapper)));
            builder.Services.AddAutoMapper(x => x.AddProfile(typeof(AuthMapper)));
            builder.Services.AddControllers().AddJsonOptions(options =>
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
.AddEntityFrameworkStores<DatabaseContext>()
.AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                RoleInitializer.SeedRolesAsync(services).GetAwaiter().GetResult();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

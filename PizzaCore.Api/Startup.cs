using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PizzaCore.Business.Auth;
using PizzaCore.Business.CategoryService;
using PizzaCore.Business.CrustService;
using PizzaCore.Business.CustomerService;
using PizzaCore.Business.ExceptionHandler;
using PizzaCore.Business.ItemService;
using PizzaCore.Business.OrderService;
using PizzaCore.Business.PizzaService;
using PizzaCore.Business.SizesService;
using PizzaCore.Business.ToppingService;
using PizzaPos.DataAccess.AuthRepository;
using PizzaPos.DataAccess.CategoryRepository;
using PizzaPos.DataAccess.CrustPricesRepository;
using PizzaPos.DataAccess.CrustRepository;
using PizzaPos.DataAccess.CustomerRepository;
using PizzaPos.DataAccess.DeliveryMethodRepository;
using PizzaPos.DataAccess.EmployeeRepository;
using PizzaPos.DataAccess.ItemRepository;
using PizzaPos.DataAccess.MemberShipRepository;
using PizzaPos.DataAccess.OrderDetailsRepository;
using PizzaPos.DataAccess.OrderRepository;
using PizzaPos.DataAccess.PizzaIngredientsRepository;
using PizzaPos.DataAccess.PizzaOrderDetailsRepository;
using PizzaPos.DataAccess.PizzaPrices;
using PizzaPos.DataAccess.PizzaRepository;
using PizzaPos.DataAccess.SizesRepository;
using PizzaPos.DataAccess.SubCategoryRepository;
using PizzaPos.DataAccess.ToppingDetailsRepository;
using PizzaPos.DataAccess.ToppingPricesRepository;
using PizzaPos.DataAccess.ToppingsRepository;
using PizzaPos.DataAccess.TypeRepository;

namespace PizzaCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("Default"), b=>b.MigrationsAssembly("PizzaCore.Api")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISizesService, SizesService>();
            services.AddScoped<IToppingService, ToppingService>();
            services.AddScoped<ICrustService, CrustService>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
            services.AddTransient<ISizesRepository, SizesRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            services.AddTransient<IToppingsRepository, ToppingsRepository>();
            services.AddTransient<IToppingPricesRepository, ToppingPricesRepository>();
            services.AddTransient<ICrustRepository, CrustRepository>();
            services.AddTransient<ICrustPricesRepository, CrustPricesRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IPizzaPricesRepository, PizzaPricesRepository>();
            services.AddTransient<IPizzaIngredientsRepository, PizzaIngredientsRepository>();
            services.AddTransient<IMemberShipRepository, MemberShipRepositoryImpl>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDeliveryOptionRepository, DeliveryOptionRepository>();
            services.AddTransient<IToppingDetailsRepository, ToppingDetailsRepository>();
            services.AddTransient<IPizzaOrderDetailsRepository, PizzaOrderDetailsRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
                    };
                });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PizzaCore.Api", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaCore.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
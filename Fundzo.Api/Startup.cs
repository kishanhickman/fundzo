using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Fundzo.Core;
using Fundzo.Core.Services;
using Fundzo.Data;
using Fundzo.Services;
using Fundzo.Services.Donation;
using Fundzo.Services.Fundraiser;
using Fundzo.Services.Payments;
using Fundzo.Services.StaticMedia;
using Fundzo.Services.Admin.Address;
using Fundzo.Services.Admin.Category;
using Fundzo.Services.Admin.Country;
using Fundzo.Services.Admin.Currency;
using Fundzo.Services.Admin.Industry;
using Fundzo.Services.Admin.Organisation;
using Serilog;

using Fundzo.Api.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Fundzo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            // For Entity Framework.
            services.AddDbContext<FundzoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Fundzo.Data")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Admin transient.
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IIndustryService, IndustryService>();
            services.AddTransient<IOrganisationService, OrganisationService>();
            // Donation transient.
            services.AddTransient<IDonationService, DonationService>();
            services.AddTransient<IDonationStatusService, DonationStatusService>();
            // Fundraiser transient.
            services.AddTransient<IFundraiserService, FundraiserService>();
            services.AddTransient<IFundraiserMediaService, FundraiserMediaService>();
            services.AddTransient<IFundraiserTypeService, FundraiserTypeService>();
            services.AddTransient<IFundraiserStatusService, FundraiserStatusService>();
            // Payment transient.
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentMethodService, PaymentMethodService>();
            services.AddTransient<IPaymentStatusService, PaymentStatusService>();
            // Static Media transient.
            services.AddTransient<IStaticMediaService, StaticMediaService>();

             
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()  
                .AddEntityFrameworkStores<ApplicationDbContext>()  
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Fundzo", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundzo V1");
            });
        }
    }
}
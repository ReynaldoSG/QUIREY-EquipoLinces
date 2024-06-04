using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marcatel_api.Extensions;
using marcatel_api.Models;
using marcatel_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace marcatel_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var key = "BusinessCaseMarcatelApiV2Tibs!*";

            // requires using Microsoft.Extensions.Options
            services.Configure<MarcatelDatabaseSetting>(
            Configuration.GetSection(nameof(MarcatelDatabaseSetting)));

            //services.Configure<EmailstoreSettings>(
            //Configuration.GetSection(nameof(EmailstoreSettings)));

            // Get KudotibsDatabaseSettings
            services.AddSingleton<IMarcatelDatabaseSetting>(sp =>
            sp.GetRequiredService<IOptions<MarcatelDatabaseSetting>>().Value);

            // Get EmailstoreSettings
            //services.AddSingleton<IEmailstoreSettings>(sp =>
            //    sp.GetRequiredService<IOptions<EmailstoreSettings>>().Value);

            // Get Services LB
            services.AddSingleton<LoginService>();
            services.AddSingleton<MapeosService>();
            services.AddSingleton<AlmacenesService>();
            services.AddSingleton<TicketsService>();
            services.AddSingleton<ArticulosService>();
            services.AddSingleton<DetalleTicketService>();
            services.AddSingleton<DetalleMovimientoService>();
            services.AddSingleton<MovInventarioService>();
            services.AddSingleton<SucursalesService>();
            services.AddSingleton<VendedoresService>();
            services.AddSingleton<PersonasService>();
            services.AddSingleton<UsuariosService>();
            services.AddSingleton<EstadosService>();
            services.AddSingleton<TiposMovService>();
            services.AddSingleton<ClientesService>();
            services.AddSingleton<ExistenciasService>();
            services.AddSingleton<UMService>();
            services.AddSingleton<RutasService>();
            services.AddSingleton<ModuloService>();
            services.AddSingleton<CatModuloService>();
            services.AddSingleton<EmpleadosService>();
            services.AddSingleton<PuestosService>();
            services.AddSingleton<ModUsuarioService>();
            services.AddSingleton<DetallePerfilService>();
            services.AddSingleton<LoginQuireyService>();
            services.AddSingleton<RolesService>();
            services.AddSingleton<AutorizarMovService>();

            services.AddCors();


            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing())
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.WriteIndented = true;
                });


            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidIssuer = "https://marcatelapi.herokuapp.com/",
                        ValidAudience = "https://marcatelapi.herokuapp.com/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });

            services.AddAuthorization();
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Context DB
            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

            // Register the Swagger generator, defening 1 or more Swgager documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Quirey API",
                    Description = "ASP.NET Core Web API for Quirey API.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = " DEV",
                        Email = string.Empty,
                        Url = new Uri("https://www.utl.edu.mx/"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "License type",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable middleware to serve generated swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mapeos API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //  app.ConfigureExceptionHandler(logger);
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();

            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

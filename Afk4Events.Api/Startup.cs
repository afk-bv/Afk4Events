using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Afk4Events.Data;
using Afk4Events.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

/*
　　　　　　　　　　　　　　　 ／ : : / : : : : ／: : : : : : : : : : : : : : :|　|　＼l＼　 |: :}:ﾄ､
　　　　　　　　　　　　　　 /:/ : : /: : : ://: : : : :/: : |　: : : : : | : :＼＼.　 Ⅵ /|彡爪＼
　　　　　　 　 　 　 　 　 /:/ : : /: : : ://: : : : :/: :川 : : : : : !:|: : :│＼二ﾑl/〈　/ |:ﾊ : ヽ
　 　 　 　 　 　 　 　 　 〈:/| : :/: : : ://: : : : :/ : /:/|　: : : : l |: : :│: |: : :|: l/∧{:{ |}:::}: : : ',
　　　　　　　　　　　　　　　＼| : : : :|＼ : : :/| :/:/:│ : : : : l |: : :│: |: : :|/Ⅳ| 〉l:ﾘ|:::| : : : '.
　　　　　　　　　　　　　　　 /:＼:_.｣从=ミ　|:乂/| : |: : : : : :l |: : :│: |: : /∧////l:|:l:| : : : :|
　　　　　　　　　　　　 　 　 |_:_/|: i〃つi心`ー　LﾉＬ-─ 从|─'│: | :〈〈〈//{{/ 八|::｝ : : :|
　　　　　　　　　　　　　　／/八| {{. ﾄ{:::|　　　　　 ァ示心､＿ﾘ: /: |::∨/:∧: l:小ｲ : : : |
　　　　　　　　　　 　 　 //////: ﾘ　V//ン　　　　　ん:::::::::小 　`7L人// /　じl::| |:| : : :│
　　 　 　 　 　 　 　 　 ////／ ノ{　: : : :　　 ,　　　　V{///i | ﾘ　/: /(　}／　　 | :| |｣ : : :│
　　　　　　　　　　　　/／|/＞ >人　　　　　　　　　　ゝ ..::ン　　.: :/）　厶-=ミ. |/| : : : : :│
　　　　　　　　　 　 ノ |／|く＜ ///＼　　　　　　 　 　 : : : : 　（: :（__／/////∨|:ｉ : : : : :│
　 　 　 　 　 　 　 ∧/| _人_,＞^⌒¨¨)丶、 ＾^ ～　　　　 　 イ）: :）////////∧ | i : : : :│
　　　　 　 　 　 ／　|／　 {/　　 ー‐'く⌒}＼ ＿.....　 ＿＜／（_⊂//////////∧:.| : : : : |
　　　　　　　　〈　　　　　　|　　　ｰ‐…し'⌒トく/＾)＜ 　 ＼∠/）∧///／＼///人| i : : : |
　　　　 　 　 　 ＼　　　　 l　　　ｰ‐…}///｛/（_人_　｀¨ 　 ∨│ ∧／＼／ ∨ ＼| i : : : |
　　　　　　　　　　 ＼_{__{八　　　　_,,,ﾉ７アﾍ /＼　｀　　　　厂「｀／＼／＼／＼/∨: : : :|
　　　　　　　　　　 ∠≪￣{{`　　　　｝ ∨＿八、　　　　　 /＼／　　　＼／　 　 |　|: : : : |
　　　　　　　　　　 ｀¨７／》ﾍ　　　イ}}_〈_〈_〈_/　　　　　イ　　　　　　　　　　　　 /　|: : : : |
　　　　　　　　　　　 /　 └==ミ==彳∧ // 人＿＿_//　＼　　　　／／　　　 / 　 |: : : : |
 */
namespace Afk4Events.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            CurrentEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Setup asp.net stuff
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });
            services.AddHealthChecks().AddDbContextCheck<Afk4EventsContext>();

            string databaseConnectionString = Configuration["db"];
            services.AddDbContext<Afk4EventsContext>(options =>
            {
                options.UseNpgsql(databaseConnectionString);
            });

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.Cookie.Name = "x";
                    options.ExpireTimeSpan = TimeSpan.FromHours(12);
                    options.SlidingExpiration = true;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Events.OnRedirectToAccessDenied = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                    options.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });

            services.AddDataProtection(options =>
            {
                options.ApplicationDiscriminator = "UserApi";
            }).PersistKeysToDbContext<Afk4EventsContext>();

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // Add services
            services.AddTransient<IUserService, UserService>();


            // Create database for the lazy developer
            if (CurrentEnvironment.IsDevelopment())
            {
                var db = services.BuildServiceProvider().GetService<Afk4EventsContext>();
                db.Database.EnsureCreated();
                if (db.Database.GetPendingMigrations().Any())
                {
                    db.Database.Migrate();
                }
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
        
            }

            app.UseRouting();
            app.UseHealthChecks("/api/health");
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

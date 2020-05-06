using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;//
using Microsoft.AspNetCore.Http;//
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置跨域处理，允许所有来源
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,

            //        builder => builder.AllowAnyOrigin()

            //        .WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")

            //        );

            //});
            services.AddCors(
                options => options.AddPolicy
                ("first", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
                );
            //#region 跨域配置ycx（报错的话删除不用问本人）

            //services.AddCors(options =>
            //{
            //    services.AddCors(options => {

            //        options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowCredentials().Build());
            //    });
            //    services.AddControllers();


            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});

            //#endregion




            services.AddControllers();
        }

        //public class CorsMiddleware
        //{
        //    private readonly RequestDelegate next;

        //    public CorsMiddleware(RequestDelegate next)
        //    {
        //        this.next = next;
        //    }
        //    public async Task Invoke(HttpContext context)
        //    {
        //        if (context.Request.Headers.ContainsKey(CorsConstants.Origin))
        //        {
        //            context.Response.Headers.Add("Access-Control-Allow-Origin", context.Request.Headers["Origin"]);
        //            context.Response.Headers.Add("Access-Control-Allow-Methods", "PUT,POST,GET,DELETE,OPTIONS,HEAD,PATCH");
        //            context.Response.Headers.Add("Access-Control-Allow-Headers", context.Request.Headers["Access-Control-Request-Headers"]);
        //            context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

        //            if (context.Request.Method.Equals("OPTIONS"))
        //            {
        //                context.Response.StatusCode = StatusCodes.Status200OK;
        //                return;
        //            }
        //        }
        //        await next(context);
        //    }
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);

            app.UseCors("first");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
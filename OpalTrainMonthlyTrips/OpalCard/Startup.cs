﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
namespace OpalCard {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo { 
                            Title = "Opal Train Tap On/Tap Off Monthly Figures",
                            Description = "This dataset contains Official Train Utilisation figures. Opal tap-on/tap-off data (representing an individual entering & exiting a station), is allocated to a line and aggregated to a monthly figure for the estimated number of trips." ,
                            Version = "v1" ,
                            Contact = new OpenApiContact
                            {
                                Name = "Stephen Corral",
                                Email = string.Empty,
                                Url = new Uri("https://localhost:5001/swagger/v1/swagger.json"),
                            }
                        }
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger ();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection ();
            app.UseMvc ();

        }
    }
}
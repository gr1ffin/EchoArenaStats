using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace EchoStatsWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            



            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    const string path = "C:\\Users\\Public\\Documents\\EchoStatsLogger\\savedData.json";
                    var data2 = File.ReadAllText(path);
                    dynamic data = JsonConvert.DeserializeObject(data2);

                    var oldPoints = JsonConvert.SerializeObject(data?["points"]);
                    var oldAssists = JsonConvert.SerializeObject(data?["saves"]);
                    var oldSaves = JsonConvert.SerializeObject(data?["stuns"]);
                    var oldStuns = JsonConvert.SerializeObject(data?["assists"]);
                    // Separate 
                    var oldTotal = JsonConvert.SerializeObject(data?["total"]);
                    var oldWinrate = JsonConvert.SerializeObject(data?["winrate"]);
                    var oldLosses = JsonConvert.SerializeObject(data?["losses"]);
                    var oldWins = JsonConvert.SerializeObject(data?["wins"]);

                    string toWrite = "Points: " + oldPoints + "@Assists: " + oldAssists + "@Saves: " + oldSaves + "@Stuns:" + oldStuns + "@" + "@Total Games: "  + oldTotal + "@Wins: " + oldWins + "@Losses: " + oldLosses + "@Win Rate: " + oldWinrate;


                    // await context.Response.WriteAsync(toWrite.Replace("@", Environment.NewLine));

                    var toWriteOther = Convert.ToString(File.ReadAllText(path));
                    await context.Response.WriteAsync(toWriteOther);
                    


                });
            });
            app.UseStaticFiles()
            
        }

    }
}

namespace WebApplicationFSharp.Net

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting


type Startup () =

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    member this.ConfigureServices(services: IServiceCollection) =
        ()

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore
        else
            app.UseExceptionHandler("/Home/Error") |> ignore
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseStaticFiles() |> ignore
        app.UseSession() |> ignore

        app.UseMvc(fun routes ->
            routes.MapRoute(
                name = "areaRoute",
                template = "{area:exists}/{controller=Customer}/{action=Index}/{id?}") |> ignore
            routes.MapRoute(
                name = "default",
                template = "{controller=Home}/{action=Index}/{id?}") |> ignore
            ) |> ignore

using Blazored.LocalStorage;
using Blazored.SessionStorage;
using EstiloLibreFront;
using EstiloLibreFront.Objetos;
using EstiloLibreFront.Servicios;
using EstiloLibreFront.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<Configuracion>(builder.Configuration);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<AutenticacionInterceptor>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services
    .AddHttpClient("API", client => {
        client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BackendUrlApi"));
    })
    .AddHttpMessageHandler<AutenticacionInterceptor>();
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "";
});
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddMudServices();
builder.Services.AddScoped<ServicioMensajeInfo>();
builder.Services.AddScoped<ServicioLogIn>();
builder.Services.AddScoped<ServicioAutentificacion>();
builder.Services.AddScoped<ServicioUsuarios>();
builder.Services.AddSingleton<ServicioDatosContexto>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ServicioAutentificacion>());
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthorizationCore(config =>
{
    foreach (var permiso in UtilsPermisos.ObtenerTodosLosPermisos())
    {
        config.AddPolicy(permiso, UtilsPermisos.CrearPolitica(permiso));
    }
});
builder.Services.AddScoped<ServicioNavegacion>();
builder.Services.Configure<Configuracion>(builder.Configuration);

var host = builder.Build();
await host.InicializarContexto();
await host.RunAsync();

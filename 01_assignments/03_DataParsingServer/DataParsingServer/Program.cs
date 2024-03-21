using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services =>
                {
                    services.AddControllers();
                    services.AddHttpClient();
                });

                webBuilder.Configure(app =>
                {
                    var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();

                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }

                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
}

[ApiController]
[Route("[controller]")]
public class CommunicationController : ControllerBase
{
    private const string SERVER_A_URL = "http://127.0.0.1:8000";

    private readonly HttpClient _httpClient;

    public CommunicationController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet("/get_data_from_server_a_xml")]
    public async Task<IActionResult> GetDataFromServerAxml()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{SERVER_A_URL}/xml");
            response.EnsureSuccessStatusCode();

            return Ok(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException ex)
        {
            return BadRequest($"Error communicating with Server A: {ex.Message}");
        }
    }

    [HttpGet("/get_data_from_server_a_csv")]
    public async Task<IActionResult> GetDataFromServerAcsv()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{SERVER_A_URL}/csv");
            response.EnsureSuccessStatusCode();

            return Ok(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException ex)
        {
            return BadRequest($"Error communicating with Server A: {ex.Message}");
        }
    }

    [HttpGet("/get_data_from_server_a_json")]
    public async Task<IActionResult> GetDataFromServerAjson()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{SERVER_A_URL}/json");
            response.EnsureSuccessStatusCode();

            return Ok(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException ex)
        {
            return BadRequest($"Error communicating with Server A: {ex.Message}");
        }
    }

    [HttpGet("/get_data_from_server_a_yaml")]
    public async Task<IActionResult> GetDataFromServerAyaml()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{SERVER_A_URL}/yaml");
            response.EnsureSuccessStatusCode();

            return Ok(await response.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException ex)
        {
            return BadRequest($"Error communicating with Server A: {ex.Message}");
        }
    }




}

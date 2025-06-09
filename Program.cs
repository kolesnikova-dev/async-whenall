using System.Text.Json;

class Program
{
    private static readonly string[] fetchUrls = ["https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m&timezone=auto&forecast_days=1"];
    public static async Task Main(string[] args)
    {
        DataFetcher dataFetcher = new();
        Console.WriteLine("Welcome to the Data Fetcher.");
        var data = await dataFetcher.Fetch(fetchUrls);
        foreach (var piece in data)
        {
            Console.WriteLine(piece);
        }
    }
}

public class DataFetcher
{
    public async Task<List<string>> Fetch(string[] fetchUrls)
    {
        using HttpClient client = new();
       var returnData = new List<string>();
        foreach (var url in fetchUrls)
        {
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var dataJson = await response.Content.ReadAsStringAsync();
                var doc = JsonDocument.Parse(dataJson);
                 var prettified = JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions { WriteIndented = true });
                returnData.Add(prettified);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Something went wrong with " + url + ". " + ex.Message);
                throw;
            }
        }

        return returnData;
    }
}
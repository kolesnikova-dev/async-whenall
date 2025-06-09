using System.Text.Json;

class Program
{
    private static readonly string[] fetchUrls = ["https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m&timezone=America%2FNew_York&forecast_days=1", "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=rain&timezone=America%2FNew_York&forecast_days=1"];
    public static async Task Main(string[] args)
    {
        DataFetcher dataFetcher0 = new();
        DataFetcher dataFetcher1 = new();

        Console.WriteLine("Welcome to the Data Fetcher.");

        var task0 = dataFetcher0.Fetch(fetchUrls[0]);
        var task1 = dataFetcher1.Fetch(fetchUrls[1]);
        await Task.WhenAll(task0, task1);

        var data0 = await task0;
        var data1 = await task1;


        PrintToConsole(data0);
        PrintToConsole(data1);

    }

    public static void PrintToConsole(List<string> args)
    {
        foreach (var piece in args)
        {
            Console.WriteLine(piece);
        }
    }
}

public class DataFetcher
{
    public async Task<List<string>> Fetch(string url)
    {
        using HttpClient client = new();
       var returnData = new List<string>();
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

        return returnData;
    }
}
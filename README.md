# C# Weather Data Fetcher

This is a simple C# console application that demonstrates how to:
- Fetch data from a public REST API using `HttpClient`
- Handle asynchronous code with `async`/`await`, `Task` and `Task.WhenAll`
- Parse and pretty-print JSON using `System.Text.Json`

The data source is the [Open-Meteo](https://open-meteo.com/) weather API, which returns temperature forecasts based on latitude and longitude.

---

## Features

- Fetches hourly temperature data for New York, USA.
- Formats the response JSON into a readable format
- Handles network errors gracefully
- Uses modern C# 10+ syntax (e.g., target-typed `new()` and `JsonSerializer`)

---

## Requirements

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/en-us/download)

---

## How to Run

1. Clone or download the project.
2. Open the project folder in your terminal or IDE.
3. Run the application:

   ```bash
   dotnet run


## What I Learnt from This
- Parallel async execution with Task.WhenAll()
- How to handle HTTP errors using try/catch
- JSON handling with JsonDocument and JsonSerializer
- Writing reusable and modular code (DataFetcher, PrintToConsole)
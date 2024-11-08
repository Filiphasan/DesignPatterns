using Carter;
using DisposableDp.Common.Models;
using DisposableDp.Helpers;

namespace DisposableDp.Endpoints;

public class CsvEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/csv")
            .WithTags("Csv");

        group.MapGet("/read", ReadCsv);
        group.MapGet("/read-async", ReadCsvAsync);
    }
    
    private static IResult ReadCsv(IWebHostEnvironment hostEnvironment)
    {
        using var csvReader = new CsvReaderHelper(Path.Combine(hostEnvironment.WebRootPath, "CsvFiles", "example.csv"));
        var lines = csvReader.ReadAll<CsvSampleModel>();
        return Results.Ok(lines);
    }
    
    private static async Task<IResult> ReadCsvAsync(IWebHostEnvironment hostEnvironment)
    {
        var csvReader = new CsvReaderHelper(Path.Combine(hostEnvironment.WebRootPath, "CsvFiles", "example.csv"));
        var lines = await csvReader.ReadAllAsync<CsvSampleModel>();
        csvReader.Dispose();
        return Results.Ok(lines);
    }
}
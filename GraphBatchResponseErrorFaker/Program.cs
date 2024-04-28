// See https://aka.ms/new-console-template for more information
using GraphBatchResponseErrorFaker;
using System.Net;
using System.Text.Json;

Console.WriteLine("Input graph batch request body file path:");

string? filePath = Console.ReadLine();

if (string.IsNullOrEmpty(filePath))
{
    throw new ArgumentNullException(nameof(filePath));
}

Console.WriteLine("Input combination of status codes delimited by ;");

string? statusCodes = Console.ReadLine();

if (string.IsNullOrEmpty(statusCodes))
{
    throw new ArgumentNullException(nameof(statusCodes));
}

var statusCodesArray = statusCodes.Split(';', StringSplitOptions.RemoveEmptyEntries);

List<HttpStatusCode> httpStatusCodes = statusCodesArray.Select(stringCode => (HttpStatusCode)Convert.ToInt16(stringCode)).ToList();

using var fileStream = File.OpenRead(filePath);

JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull

};

BatchRequestBody body = JsonSerializer.Deserialize(fileStream, typeof(BatchRequestBody), options) as BatchRequestBody;

string outputFilePath = $"{filePath}-output.json";
if (File.Exists($"{filePath}-output.json"))
{
    File.Delete($"{filePath}-output.json");
}

using StreamWriter sw = new StreamWriter(outputFilePath, false);
BatchResponseBody batchResponseBody = new BatchResponseBody();
Random randomGen = new Random();
int codeCount = httpStatusCodes.Count();
foreach (var request in body.Requests)
{
    int statusIndex = randomGen.Next(0, codeCount - 1);
    batchResponseBody.Responses.Add(new Response
    {
        Id = request.Id,
        StatusCode = httpStatusCodes.ElementAt(statusIndex),
        //Body =
        //{
        //    // Could add some error detail here if required
        //}
    });
}

string responseBody = JsonSerializer.Serialize(batchResponseBody, typeof(BatchResponseBody), options);

sw.Write(responseBody);
sw.Flush();
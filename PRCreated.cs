using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Totvs.TFS
{
    public static class PRCreated
    {
        [FunctionName("PRCreated")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var message = data?.message?.markdown;

            string responseMessage = $"{{\"username\": \"TotvsTfsBot\",\"avatar_url\": \"https://i.imgur.com/4M34hi2.png\",\"content\": \"{message}\" }}";
            var content = new StringContent(responseMessage, Encoding.UTF8, "application/json");

            var urlWebhook = System.Environment.GetEnvironmentVariable("urlWebhook", EnvironmentVariableTarget.Process);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(urlWebhook, content);

            return new OkObjectResult(response);
        }
    }
}

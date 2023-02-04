using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace V4DepInjThreadsMem562
{
    public class http
    {
        private readonly ILogger _logger;
        private readonly ITestService _testService;

        public http(ILoggerFactory loggerFactory, ITestService testService)
        {
            _testService = testService;
            _logger = loggerFactory.CreateLogger<http>();
        }

        [Function("http")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            Task[] myTaskList = new Task[100];

            for (int i = 0; i < 100; i++)
            {
                myTaskList[i] = _testService.GetTestString();
            }

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}

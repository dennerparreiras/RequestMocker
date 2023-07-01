using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;

namespace RequestMocker.Classes
{
    /// <summary>
    /// Represents the mock server that handles HTTP requests.
    /// </summary>
    public class Server
    {
        private IWebHost webHost;
        private string token;
        private string responseBody;
        private string url;
        private int port;
        public bool IsRunning { get; private set; }
        private int successResponseCode;
        private int failureResponseCode;
        public string LastRequestDetails { get; private set; }

        /// <summary>
        /// Constructor for the Server class.
        /// Initializes the server with given parameters.
        /// </summary>
        /// <param name="url">The url to start the server on.</param>
        /// <param name="port">The port to start the server on.</param>
        /// <param name="initialToken">The initial authorization token.</param>
        /// <param name="initialResponseBody">The initial response body.</param>
        /// <param name="initialSuccessResponseCode">The initial success response code.</param>
        /// <param name="initialFailureResponseCode">The initial failure response code.</param>
        public Server(string url, int port, string initialToken, string initialResponseBody, int initialSuccessResponseCode, int initialFailureResponseCode)
        {
            this.url = url;
            this.port = port;
            string fullUrl = $"{url}:{port}";

            BuildWebHost(fullUrl, initialToken, initialResponseBody, initialSuccessResponseCode, initialFailureResponseCode);
        }

        /// <summary>
        /// Updates the URL of the server.
        /// You need to stop the server, change the URL and restart it.
        /// </summary>
        /// <param name="newUrl">The new URL to set.</param>
        public void UpdateUrl(string newUrl)
        {
            if (IsRunning)
            {
                Stop();
            }

            this.url = newUrl;
            string fullUrl = $"{url}:{port}";

            BuildWebHost(fullUrl, token, responseBody, successResponseCode, failureResponseCode);

            if (IsRunning)
            {
                Start();
            }
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public void Start()
        {
            webHost.Start();
            IsRunning = true;
            System.Console.WriteLine($"Server started successfully.\r\n\r\n");
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public void Stop()
        {
            webHost.StopAsync().Wait();
            IsRunning = false;
            System.Console.WriteLine("Server stopped successfully.\r\n\r\n");
        }

        /// <summary>
        /// Updates the authorization token of the server.
        /// </summary>
        /// <param name="newToken">The new token to set.</param>
        public void UpdateToken(string newToken)
        {
            token = newToken;
            System.Console.WriteLine($"Token updated successfully. New token: {token}\r\n\r\n");
        }

        /// <summary>
        /// Updates the success response code of the server.
        /// </summary>
        /// <param name="newSuccessResponseCode">The new success response code to set.</param>
        public void UpdateSuccessResponseCode(int newSuccessResponseCode)
        {
            successResponseCode = newSuccessResponseCode;
            System.Console.WriteLine($"Success response code updated successfully. New success response code: {successResponseCode}\r\n\r\n");
        }

        /// <summary>
        /// Updates the failure response code of the server.
        /// </summary>
        /// <param name="newFailureResponseCode">The new failure response code to set.</param>
        public void UpdateFailureResponseCode(int newFailureResponseCode)
        {
            failureResponseCode = newFailureResponseCode;
            System.Console.WriteLine($"Failure response code updated successfully. New failure response code: {failureResponseCode}\r\n\r\n");
        }

        /// <summary>
        /// Updates the response body of the server.
        /// </summary>
        /// <param name="newResponseBody">The new response body to set.</param>
        public void UpdateResponseBody(string newResponseBody)
        {
            responseBody = newResponseBody;
            System.Console.WriteLine($"Response body updated successfully. New response body: {responseBody}\r\n\r\n");
        }

        /// <summary>
        /// Builds the web host for the server.
        /// </summary>
        private void BuildWebHost(string fullUrl, string initialToken, string initialResponseBody, int initialSuccessResponseCode, int initialFailureResponseCode)
        {
            webHost = new Microsoft.AspNetCore.Hosting.WebHostBuilder()
                .UseKestrel()
                .UseUrls(fullUrl)
                .ConfigureServices(services =>
                {
                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowAll", builder =>
                            builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                    });
                })
                .Configure(app =>
                {
                    app.UseCors("AllowAll");
                    app.Run(async context =>
                    {
                        StringBuilder logBuilder = new StringBuilder();

                        logBuilder.AppendLine("---- GENERAL ----");
                        logBuilder.AppendLine($"Received request: {context.Request.Method} {context.Request.Path}");
                        logBuilder.AppendLine($"Timestamp: {DateTime.Now}");

                        logBuilder.AppendLine("\n---- HEADERS ----");
                        foreach (var header in context.Request.Headers)
                        {
                            logBuilder.AppendLine($"{header.Key}: {header.Value}");
                        }

                        logBuilder.AppendLine("\n---- BODY ----");
                        if (context.Request.HasFormContentType)
                        {
                            var form = await context.Request.ReadFormAsync();
                            foreach (var key in form.Keys)
                            {
                                logBuilder.AppendLine($"{key}: {form[key]}");
                            }
                        }

                        string authToken = context.Request.Headers["Authorization"];
                        if (authToken != token)
                        {
                            context.Response.StatusCode = failureResponseCode;
                            await context.Response.WriteAsync("Invalid token.");
                            logBuilder.AppendLine("\n---- RESPONSE SENT ----");
                            logBuilder.AppendLine($"Status Code: {failureResponseCode}\r\nResponse Body: Invalid token.\n");
                        }
                        else
                        {
                            context.Response.StatusCode = successResponseCode;
                            await context.Response.WriteAsync(responseBody);
                            logBuilder.AppendLine("\n---- RESPONSE SENT ----");
                            logBuilder.AppendLine($"Status Code: {successResponseCode}\r\nResponse Body: {responseBody}\n");
                        }

                        LastRequestDetails = logBuilder.ToString();
                        File.AppendAllText("requestsLog.txt", LastRequestDetails);
                        System.Console.WriteLine(LastRequestDetails);
                    });
                })
                .Build();
            IsRunning = false;
            token = initialToken;
            responseBody = initialResponseBody;
            successResponseCode = initialSuccessResponseCode;
            failureResponseCode = initialFailureResponseCode;
        }
    }
}

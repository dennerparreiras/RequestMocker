using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace RequestMocker.Classes
{
    public class Server
    {
        private IWebHost webHost;
        private string token;
        private string responseBody;
        public bool IsRunning { get; private set; }
        private int successResponseCode;
        private int failureResponseCode;
        public string LastRequestDetails { get; private set; }

        public Server(string url, int port, string initialToken, string initialResponseBody, int initialSuccessResponseCode, int initialFailureResponseCode)
        {
            string fullUrl = $"{url}:{port}";

            webHost = new WebHostBuilder()
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

        public void Start()
        {
            webHost.Start();
            IsRunning = true;
            System.Console.WriteLine($"Server started successfully.\r\n\r\n");
        }

        public void Stop()
        {
            webHost.StopAsync().Wait();
            IsRunning = false;
            System.Console.WriteLine("Server stopped successfully.\r\n\r\n");
        }

        public void UpdateToken(string newToken)
        {
            token = newToken;
            System.Console.WriteLine($"Token updated successfully. New token: {token}\r\n\r\n");
        }

        public void UpdateSuccessResponseCode(int newSuccessResponseCode)
        {
            successResponseCode = newSuccessResponseCode;
            System.Console.WriteLine($"Success response code updated successfully. New success response code: {successResponseCode}\r\n\r\n");
        }

        public void UpdateFailureResponseCode(int newFailureResponseCode)
        {
            failureResponseCode = newFailureResponseCode;
            System.Console.WriteLine($"Failure response code updated successfully. New failure response code: {failureResponseCode}\r\n\r\n");
        }

        public void UpdateResponseBody(string newResponseBody)
        {
            responseBody = newResponseBody;
            System.Console.WriteLine($"Response body updated successfully. New response body: {responseBody}\r\n\r\n");
        }
    }
}

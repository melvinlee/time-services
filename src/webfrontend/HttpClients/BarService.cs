﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebFrontend.HttpClients
{
    public class BarService : IBarService
    {
        private readonly HttpClient _httpClient; // not exposed publicly
        private readonly IConfiguration _configuration;

        public BarService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetResult()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var httpResponseMessage = await _httpClient.GetAsync("/api");
            var contents = await httpResponseMessage.Content.ReadAsStringAsync();
            stopwatch.Stop();

            var result = $"{Math.Round((decimal)stopwatch.ElapsedMilliseconds / 1000, 2)} secs {_configuration.GetValue<string>("BACKEND_URL_BAR")} -> {httpResponseMessage.StatusCode} [{contents}]";
            return result;
        }
    }
}
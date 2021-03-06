﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App.Metrics.Extensions.Middleware.Integration.Facts.Startup;
using FluentAssertions;
using Xunit;

namespace App.Metrics.Extensions.Middleware.Integration.Facts.Middleware.MetricsText
{
    public class MetricsTextEndpointFilteringMiddlewareTests : IClassFixture<MetricsHostTestFixture<FitleredMetricsEndpointStartup>>
    {
        public MetricsTextEndpointFilteringMiddlewareTests(MetricsHostTestFixture<FitleredMetricsEndpointStartup> fixture)
        {
            Client = fixture.Client;
        }

        private HttpClient Client { get; }

        [Fact]
        public async Task can_filter_metrics()
        {
            var response = await Client.GetAsync("/metrics-text");

            var result = await response.Content.ReadAsStringAsync();

            result.Should().Contain("test_counter");
            result.Should().NotContain("test_gauge");
            result.Should().NotContain("test_meter");
            result.Should().NotContain("test_timer");
            result.Should().NotContain("test_histogram");


            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
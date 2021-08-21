using BikeRent.Controllers;
using DataLibrary.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace BikeRent.Test
{
    public class RatesTest
    {
        [Fact]
        public async void GetReturnAllRates()
        {
            var client = new TestClientProvider().Client;

            // Arrange
            var expectedListOfRates = new List<Rates>();
            expectedListOfRates.Add(new Rates() { Id = 1, Price = 5, Term = "Hour" });
            expectedListOfRates.Add(new Rates() { Id = 2, Price = 20, Term = "Day" });
            expectedListOfRates.Add(new Rates() { Id = 3, Price = 60, Term = "Week" });

            // Act
            var response = await client.GetAsync("api/Rent");
            var actualListOfRates = JsonConvert.DeserializeObject<List<Rates>>(response.Content.ReadAsStringAsync().Result);

            // Asssert
            actualListOfRates.Should().BeEquivalentTo(expectedListOfRates);
        }
    }
}

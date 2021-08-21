using DataLibrary.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace BikeRent.Test
{
    public class RentTest
    {
        [Fact]
        public async void OnPostShouldGetRent()
        {

            var client = new TestClientProvider().Client;
            var filler = new Filler<Rent>();
            filler.Setup()
            .OnProperty(x => x.Discount).Use(0)
            .OnProperty(x => x.FinalCost).Use(0)
            .OnProperty(x => x.PartialCost).Use(0)
            .SetupFor<RentDetail>().ListItemCount(4)
            .OnProperty(x => x.IdRate).Use(new IntRange(1, 4))
            .OnProperty(x => x.IdRent).IgnoreIt()
            .OnProperty(x => x.totalRents).Use(new IntRange(1, 6))
            .OnProperty(x => x.amountTerm).Use(new IntRange(1, 6))
            .OnProperty(x => x.Rental).IgnoreIt();


            // Arrange
            var randomRent = filler.Create(1).FirstOrDefault();
            var listRatesResponse = await client.GetAsync("api/Rent");
            var listOfRates = JsonConvert.DeserializeObject<List<Rates>>(listRatesResponse.Content.ReadAsStringAsync().Result);

            decimal price = 0;
            decimal partialCost = 0;
            decimal discount = 0;
            decimal finalCost = 0;
            int totalRents = 0;
            foreach (var rent in randomRent.RentDetails)
            {
                price = listOfRates.Where(x => x.Id == rent.IdRate).FirstOrDefault().Price;
                partialCost += rent.amountTerm * price * rent.totalRents;
                totalRents += rent.totalRents;
            }

            if (totalRents >= 3 && totalRents <= 5)
            {
                discount = (partialCost * (decimal)0.3);
                finalCost = partialCost - discount;
            }
            else
            {
                finalCost = partialCost;
            }

            var expectedRent = new Rent()
            {
                ClientName = randomRent.ClientName,
                Discount = discount,
                FinalCost = finalCost,
                PartialCost = partialCost,
                RentDetails = randomRent.RentDetails
            };

            // Act
            var stringContent = new StringContent(JsonConvert.SerializeObject(randomRent), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/Rent", stringContent);
            var actualResponse = JsonConvert.DeserializeObject<Rent>(response.Content.ReadAsStringAsync().Result);

            // Asssert
            actualResponse.Should().BeEquivalentTo(expectedRent, op => op.Excluding(x => x.RentDetails).Excluding(x => x.Id));

            var i = 0;
            foreach (var actualRentDetail in actualResponse.RentDetails)
            {
                actualRentDetail.Should().BeEquivalentTo(expectedRent.RentDetails[i], op => op
                .Excluding(x => x.Id).Excluding(x => x.IdRate).Excluding(x => x.IdRent));
                i++;
            }
        }
    }
}

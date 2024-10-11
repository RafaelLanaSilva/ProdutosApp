using Azure;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Tests.Helpers;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using Xunit;

namespace ProjetoFinal1.Tests
{
    public class AppTests
    {
        Faker faker = new Faker("pt_BR");

        [Fact]
        public void CreateProductError()
        {
            var request = new ProductRequestDto
            {
                Name = faker.Commerce.ProductName(),
                Price = decimal.Parse(faker.Commerce.Price(1.00m, 1000.00m)),
                Quantity = faker.Random.Int(1, 1000),
                SupplierId = faker.Random.Guid(),
            };


            var response = TestHelper.CreateClient().PostAsync("/api/products/create", TestHelper.Serialize(request)).Result;

            //Checking if API return code HTTP 400 (BAD REQUEST)
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CreateSupplierWithSuccess()
        {
            var request = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(),
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(request)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            response.StatusCode.Should().Be(HttpStatusCode.Created);
           

        }

    }
}



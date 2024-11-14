using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Domain.Models.Entities;
using ProjetoFinal1.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Tests.Product
{
    public class ProductTest
    {
        Faker faker = new Faker("pt_BR");

        [Fact(DisplayName = "Create a Product Successfully")]
        public void CreateProductSuccessfully()
        {
            #region Creating a supplier

            var requestSupplier = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(),
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(requestSupplier)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            #region Getting the supplier Id

            var createdSupplier = JsonConvert.DeserializeObject<SupplierResponseDto>(
                response.Content.ReadAsStringAsync().Result);
                createdSupplier.Should().NotBeNull();

            var supplierId = createdSupplier.Id;

            var createdResponse = TestHelper.CreateClient().GetAsync($"/api/suppliers/{supplierId}").Result;
                createdResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

            #region Creating Product

            var request = new ProductRequestDto
            {
                Name = faker.Commerce.ProductName(),
                Price = decimal.Parse(faker.Commerce.Price(1.00m, 1000.00m)),
                Quantity = faker.Random.Int(1, 1000),
                SupplierId = supplierId
            };


            var productResponse = TestHelper.CreateClient().PostAsync("/api/products/create", TestHelper.Serialize(request)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            productResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

        }

        [Fact(DisplayName = "Delete a Product Successfully")]
        public void DeleteProductSeuccessfully()
        {
            #region Creating a product

            #region Creating a supplier

            var requestSupplier = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(),
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(requestSupplier)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            #region Getting the supplier Id

            var createdSupplier = JsonConvert.DeserializeObject<SupplierResponseDto>(
                response.Content.ReadAsStringAsync().Result);
            createdSupplier.Should().NotBeNull();

            var supplierId = createdSupplier.Id;

            var createdResponse = TestHelper.CreateClient().GetAsync($"/api/suppliers/{supplierId}").Result;
            createdResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

            #endregion

            var request = new ProductRequestDto
            {
                Name = faker.Commerce.ProductName(),
                Price = decimal.Parse(faker.Commerce.Price(1.00m, 1000.00m)),
                Quantity = faker.Random.Int(1, 1000),
                SupplierId = supplierId
            };


            var productResponse = TestHelper.CreateClient().PostAsync("/api/products/create", TestHelper.Serialize(request)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            productResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            var product = JsonConvert.DeserializeObject<ProductResponseDto>(productResponse.Content.ReadAsStringAsync().Result);
            product.Should().NotBeNull();

            var productId = product.Id;

            var deleteProduct = TestHelper.CreateClient().DeleteAsync($"/api/products/{productId}").Result;
            deleteProduct.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Get all Products Successfully")]
        public void GetAllProductsSuccessfully()
        {
            var response = TestHelper.CreateClient().GetAsync("/api/products").Result;

            var suppliers = JsonConvert.DeserializeObject<List<ProductResponseDto>>(
                response.Content.ReadAsStringAsync().Result);
                suppliers.Should().NotBeNull();
                suppliers.Should().NotBeEmpty();

        }

        [Fact(DisplayName = "Get Product by Id Successfully")]
        public void GetByIdProductsSuccessfully()
        {
            #region Creating a supplier

            var requestSupplier = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(),
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(requestSupplier)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            #region Getting the supplier Id

            var createdSupplier = JsonConvert.DeserializeObject<SupplierResponseDto>(
                response.Content.ReadAsStringAsync().Result);
            createdSupplier.Should().NotBeNull();

            var supplierId = createdSupplier.Id;

            var createdResponse = TestHelper.CreateClient().GetAsync($"/api/suppliers/{supplierId}").Result;
            createdResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

            #region Creating Product

            var request = new ProductRequestDto
            {
                Name = faker.Commerce.ProductName(),
                Price = decimal.Parse(faker.Commerce.Price(1.00m, 1000.00m)),
                Quantity = faker.Random.Int(1, 1000),
                SupplierId = supplierId
            };

            var productResponse = TestHelper.CreateClient().PostAsync("/api/products/create", TestHelper.Serialize(request)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            productResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            #region Getting the product by Id.

            var createdProduct = JsonConvert.DeserializeObject<ProductResponseDto>(
                productResponse.Content.ReadAsStringAsync().Result);
                createdProduct.Should().NotBeNull();

            var productId = createdProduct.Id;

            var createdResponsed = TestHelper.CreateClient().GetAsync($"/api/products/{productId}").Result;
                createdResponsed.StatusCode.Should().Be(HttpStatusCode.OK);

            var productChecked = JsonConvert.DeserializeObject<ProductResponseDto>(productResponse.Content.ReadAsStringAsync().Result);
            productChecked.Should().NotBeNull();
            productChecked.Id.Should().Be(productId);
            productChecked.Name.Should().Be(request.Name);
            productChecked.Quantity.Should().Be(request.Quantity);
            productChecked.SupplierId.Should().Be(supplierId);

            #endregion
        }   

    }
}

using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using ProjetoFinal1.Domain.Models.Dtos;
using ProjetoFinal1.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Tests.Supplier
{
    public class SupplierTest
    {
        Faker faker = new Faker("pt_BR");

        [Fact(DisplayName = "Create a Supplier Successfully")]
        public void CreateSupplierSuccessfully()
        {
            var request = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(), 
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(request)).Result;

            //Checking if API return code HTTP 201 (CREATED)
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }

        [Fact(DisplayName = "Delete a Supplier Successfully")]
        public void DeleteSupplierSuccessfully()
        {
            #region Creating a supplier

            var request = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(),
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(request)).Result;

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

            var supplier = createdSupplier.Id;

            var deleteSupplier = TestHelper.CreateClient().DeleteAsync($"/api/suppliers/{supplierId}").Result;
            deleteSupplier.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Get all Suppliers Successfully")]
        public void GetAllSuppliersSuccessfully()
        {
            var response = TestHelper.CreateClient().GetAsync("/api/suppliers").Result;

            var suppliers= JsonConvert.DeserializeObject<List<SupplierResponseDto>>(
                response.Content.ReadAsStringAsync().Result);
                suppliers.Should().NotBeNull();
                suppliers.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "Get Supplier by Id Successfully")]
        public void GetByIdSupplierSuccessfully()
        {
            #region Creating a supplier

            var request = new SupplierRequestDto
            {
                Name = faker.Company.CompanyName(),
            };

            var response = TestHelper.CreateClient().PostAsync("/api/suppliers/create", TestHelper.Serialize(request)).Result;

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

            #region Checking the supplier by Id.

            var supplierChecked = JsonConvert.DeserializeObject<SupplierResponseDto>(
                response.Content.ReadAsStringAsync().Result);
                supplierChecked.Should().NotBeNull();
                supplierChecked.Id.Should().Be(supplierId);
                supplierChecked.Name.Should().Be(request.Name);

            #endregion
        }
       
    }
}

﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProxiCall.Bot.Models;

namespace ProxiCall.Bot.Services.ProxiCallCRM
{
    public class CompanyService
    {
        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Environment.GetEnvironmentVariable("ApiHost"));  
        }

        public async Task<Company> GetCompanyByName(string token, string name)
        {
            var path = $"api/companies/byName?name={name}";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Company>();
            }
            return null;
        }

        public async Task<IEnumerable<OpportunityDetailed>> GetOpportunities(string token, string companyName, string ownerPhoneNumber)
        {
            IEnumerable<OpportunityDetailed> opportunities = new List<OpportunityDetailed>();
            var path = $"api/companies/opportunities?companyName={companyName}&ownerPhoneNumber={ownerPhoneNumber}";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                opportunities = await response.Content.ReadAsAsync<IEnumerable<OpportunityDetailed>>();
                return opportunities;
            }
            return null;
        }
    }
}

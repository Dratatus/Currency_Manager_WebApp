﻿using CurrencyManager.Logic.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.CurrencyProvider
{
    public class ApiCurrencyProviderService : ICurrencyProviderService
    {
        private readonly string _apiUrl = "https://api.apilayer.com";
        private readonly string _apiEndpoint = "exchangerates_data/symbols";
        private readonly string _developmentKey = "wtPTiykGgPLBEZPD3wZDxPlBZMYjbmIl";

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            string currenciesJson = await GetCurrenciesPropertiesAsync();

            var currencies = ConvertJsonStringToCurrencies(currenciesJson);

            return currencies.ToList();
        }

        private async Task<string> GetCurrenciesPropertiesAsync()
        {
            var restClientOptions = new RestClientOptions(_apiUrl)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };

            var restClient = new RestClient(restClientOptions);

            var restRequest = new RestRequest(_apiEndpoint, Method.Get);

            restRequest.AddHeader("apikey", _developmentKey);

            var restResponse = await restClient.GetAsync(restRequest);

            string jsonResponse = restResponse.Content;

            return jsonResponse;
        }

        private List<Currency> ConvertJsonStringToCurrencies(string currenciesJson)
        {
            JObject currenciesJObject = JObject.Parse(currenciesJson);

            var responseRootChildren = currenciesJObject.Children();

            // symbols
            var responseData = responseRootChildren.Skip(1).Single();

            // symbols->children
            var responseDataRows = responseData.Children().Values();

            List<Currency> currencies = new List<Currency>();

            foreach (var responseDataRow in responseDataRows)
            {
                string responseDataRowString = responseDataRow.ToString();

                var responseDataRowValues = responseDataRowString.Split(": ");

                string name = responseDataRowValues[0].Replace("\"", string.Empty);
                string value = responseDataRowValues[1].Replace("\"", string.Empty);

                Currency currency = new Currency
                {
                    Code = name,
                    Name = value
                };

                currencies.Add(currency);
                currencies.RemoveAll(
                    c => c.Code == "BTC" ||
                     c.Code == "BYN" ||
                     c.Code == "BYR" ||
                     c.Code == "CRC" ||
                     c.Code == "CUC" ||
                     c.Code == "FJD" ||
                     c.Code == "GGP" ||
                     c.Code == "IMP" ||
                     c.Code == "JEP" ||
                     c.Code == "LTL" ||
                     c.Code == "LVL" ||
                     c.Code == "MRO" ||
                     c.Code == "NIO" ||
                     c.Code == "SBD" ||
                     c.Code == "SLE" ||
                     c.Code == "STD" ||
                     c.Code == "SVC" ||
                     c.Code == "VEF" ||
                     c.Code == "VES" ||
                     c.Code == "XAG" ||
                     c.Code == "XAU" ||
                     c.Code == "ZMK" ||
                     c.Code == "ZWL"
                    );
            }

            return currencies;
        }
    }
}
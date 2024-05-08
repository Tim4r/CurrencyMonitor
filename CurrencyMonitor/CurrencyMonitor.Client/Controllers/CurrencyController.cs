using AutoMapper;
using CurrencyMonitor.Core.CurrencySerializeObject;
using CurrencyMonitor.Core.Interfaces;
using CurrencyMonitor.Core.IRepository;
using CurrencyMonitor.Core.Models;
using CurrencyMonitor.DB.Context;
using CurrencyMonitor.DB.Repositores;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CurrencyMonitor.Client.Controllers;

[ApiController]
[Route("[Controller]")]
public class CurrencyController : ControllerBase, ICurrencyRatesService
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly IMapper _mapper;

    public CurrencyController(ILogger<CurrencyController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAllInformation")]
    public async Task<CurrencyExchange> GetDollar()
    {
        var client = new HttpClient();
        string apiUrl = "http://api.exchangeratesapi.io/v1/latest" +
            "?access_key=5389859fdfa49fb263c9a84506777a2a" +
            "&symbols=USD, EUR";
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string jsonContent = await response.Content.ReadAsStringAsync();
            var a = JsonSerializer.Deserialize<CurrencyExchange>(jsonContent);
            return a;
        }
        else
        {
            return null;
        }
    }

    [HttpGet]
    [Route("GetRates")]
    public async Task<CurrencyRates> GetRates()
    {
        var client = new HttpClient();
        string apiUrl = "http://api.exchangeratesapi.io/v1/latest" +
            "?access_key=5389859fdfa49fb263c9a84506777a2a" +
            "&symbols=USD, EUR";
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string jsonContent = await response.Content.ReadAsStringAsync();
            var currencyExchangeObject = JsonSerializer.Deserialize<CurrencyExchange>(jsonContent);
            var currencyRates = _mapper.Map<CurrencyRates>(currencyExchangeObject);

            //await _currencyRepository.AddCurrency(currencyRates);

            return currencyRates;
        }
        else
        {
            return null;
        }
    }
}
using CurrencyMonitor.Core.Interfaces;
using Quartz;

namespace CurrencyMonitor.Client;

public class FetchCurrencyRatesJob : IJob
{
    private readonly ICurrencyRatesService _currencyRatesService;

    public FetchCurrencyRatesJob(ICurrencyRatesService currencyRatesService)
    {
        _currencyRatesService = currencyRatesService;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var rates = await _currencyRatesService.GetRates();
    }
}

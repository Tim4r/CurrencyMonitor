using CurrencyMonitor.Core.Models;

namespace CurrencyMonitor.Core.Interfaces;

public interface ICurrencyRatesService
{
    public Task<CurrencyRates> GetRates();
}

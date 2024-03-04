using CurrencyMonitor.Core.Models;

namespace CurrencyMonitor.Core.IRepository;

public interface ICurrencyRepository
{
    public Task AddCurrency(CurrencyRates currencyRates);
}

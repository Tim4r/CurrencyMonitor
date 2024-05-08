using CurrencyMonitor.Core.IRepository;
using CurrencyMonitor.Core.Models;
using CurrencyMonitor.DB.Context;

namespace CurrencyMonitor.DB.Repositores;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly ApplicationContext _context;

    public CurrencyRepository(ApplicationContext context) => _context = context;

    public async Task AddCurrency(CurrencyRates currencyRates)
    {
        await _context.CurrencyRates.AddAsync(currencyRates);
        await _context.SaveChangesAsync();
    }
}

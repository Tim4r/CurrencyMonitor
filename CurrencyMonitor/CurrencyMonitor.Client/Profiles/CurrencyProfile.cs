using AutoMapper;
using CurrencyMonitor.Core.CurrencySerializeObject;
using CurrencyMonitor.Core.Models;

namespace CurrencyMonitor.Client.Profiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<CurrencyExchange, CurrencyRates>()
            .ForMember(dest => dest.USD, src => src.MapFrom(x => x.Rates.USD))
            .ForMember(dest => dest.EUR, src => src.MapFrom(x => x.Rates.EUR));
    }
}

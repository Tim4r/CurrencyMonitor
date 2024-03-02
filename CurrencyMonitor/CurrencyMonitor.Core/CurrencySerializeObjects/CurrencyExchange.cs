using System.Text.Json.Serialization;
using CurrencyMonitor.Core.Models;

namespace CurrencyMonitor.Core.CurrencySerializeObject;

public class CurrencyExchange
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    [JsonPropertyName("historical")]
    public bool Historical { get; set; }
    [JsonPropertyName("date")]
    public string Date { get; set; }
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }
    [JsonPropertyName ("base")]
    public string Base { get; set; }
    [JsonPropertyName("rates")]
    public CurrencyRates Rates { get; set; }
}

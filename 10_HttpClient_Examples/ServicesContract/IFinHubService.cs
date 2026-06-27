namespace _10_HttpClient_Examples.IServicesContract
{
  
        public interface IFinnhubService
        {
            Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol);
        }
    
}

using YahooFinanceApi;
namespace StockInvestingGame.Pages
{
    public class StockData
    {
        public async Task<int> getStockData (string symbol, DateTime startDate, DateTime endDate )
        {
            try
            {
                var historic_data = await Yahoo.GetHistoricalAsync(symbol, startDate, endDate);
                var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
                var ticker = security[symbol];
                var companyName = ticker[Field.LongName];

                for (int i = 0; i < historic_data.Count; i++)
                {

                }
            }
            catch (Exception)
            {

                
            }
            return 1;

        }
    }
}

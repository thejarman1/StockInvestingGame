using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YahooFinanceApi;

namespace StockInvestingGame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public IActionResult OnPostGetStocks(string value)
        {
            return new JsonResult("Getting data for " + value);
        }

        public void OnGet()
        {

        }
    }
}
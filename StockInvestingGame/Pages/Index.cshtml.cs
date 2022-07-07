﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using ServiceStack;
using ServiceStack.Text;

namespace StockInvestingGame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Retrieves stock data in a clump and returns the data
        //TODO: conditionals, possibly chart creation (most likely a separate function), randomizing the date
        public IActionResult OnPostGetStocks(string value)
        {
            var symbol = value; //Setting the ticker symbol to what the user has entered
            var apiKey = "YQ12ME2NUXQ29XG8"; //I got this key by registering my email. You all might wanna do the same or use mine?
            var dailyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}&datatype=csv"
                .GetStringFromUrl().FromCsv<List<StockData>>();

            //This fills the object with values
            dailyPrices.PrintDump();

            var testDate = new DateTime(2022, 7, 6); //This is a random date I chose for testing
            var day = dailyPrices.Where(u => u.Timestamp.Year == testDate.Year && u.Timestamp.Month == testDate.Month && u.Timestamp.Day == testDate.Day); //This grabs the objects day
            var dayPrice = day.Max(u => u.Close);//This gets the price
            return new JsonResult("Getting data for " + value + "<br> Date: " + testDate + "<br> Closing price: $" + dayPrice);
        }

        public void OnGet()
        {

        }

        //********************CLASSES********************

        //Stores stock data
        public class StockData
        {
            public DateTime Timestamp { get; set; }
            public decimal Open { get; set; }

            public decimal High { get; set; }
            public decimal Low { get; set; }

            public decimal Close { get; set; }
            public decimal Volume { get; set; }
        }
    }
}
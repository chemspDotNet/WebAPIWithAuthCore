using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebAPIWithAuthCore.Data;

namespace WebAPIWithAuthCore.Services
{
    public class DataService
    {
        private static List<Quote> quotes = new List<Quote> { 
          new Quote{ID = 1, Contact = "Paul", Name= "Auto Insurance"},
          new Quote{ID = 2, Contact = "Bob", Name= "Flood Insurance"},
          new Quote{ID = 3, Contact = "Mary", Name= "Life Insurance"},
          new Quote{ID = 4, Contact = "Ryan", Name= "Home Insurance"},
          new Quote{ID = 5, Contact = "Sunny", Name= "Health Insurance"}
                  };
        public List<Quote> GetQuotes()
        {

            return quotes;
        }
        public bool AddQuotes(Quote quote)
        {
            var item = quotes.FirstOrDefault(x => x.ID == quote.ID);
            if (item != null)
            {
                return false;
            }
            else {
                quotes.Add(quote);
                return true;
            }
           

        }

        public bool DeleteQuotes(int quoteID)
        {
            var item = quotes.FirstOrDefault(x => x.ID == quoteID);
            if (item == null)
            {
                return false;
            }
            else
            {
                quotes.Remove(item);
                return true;
            }


        }
        public bool UpdateQuotes(int quoteID, Quote quote)
        {
            var item = quotes.FirstOrDefault(x => x.ID == quoteID);
            if (item == null)
            {
                return false;
            }
            else
            {
                item.Contact = quote.Contact;
                item.Name = quote.Name ;
                return true;
            }


        }
    }
}

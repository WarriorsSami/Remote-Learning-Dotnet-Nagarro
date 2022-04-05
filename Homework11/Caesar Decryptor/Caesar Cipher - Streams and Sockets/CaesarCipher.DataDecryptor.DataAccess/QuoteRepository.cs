using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CaesarCipher.DataDecryptor.Business.ClientLogic;

namespace ClassLibrary1CaesarCipher.DataDecryptor.DataAccess
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly List<string> quotes = new();
        private readonly Random random = new();

        public string GetOne()
        {
            int paragraphIndex = random.Next(quotes.Count);
            return quotes[paragraphIndex];
        }

        public void PutOne(string text)
        {
            quotes.Add(text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagarmeClient;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //static keys: get it on https://dashboard.pagar.me/#/myaccount/apikeys
            PagarMeService.DefaultApiKey = "ak_test_TSgC3nvXtdYnDoGKgNLIOfk3TFfkl9";
            PagarMeService.DefaultEncryptionKey = "ek_test_UT6AN4fDN3BCUgo6kxUiOq6S20dbKc";
            Console.WriteLine("Pagarme integration");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.Write("Save credit card" + (SaveCard() ? " - success":" - error"));
            Console.Read();
        }

        private static bool SaveCard()
        {
            try
            {
                var card = new Card
                {
                    HolderName = "Jose Lima",
                    Cvv = "123",
                    Number = "5433229077370451",
                    ExpirationDate = "0920"
                };
                card.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}

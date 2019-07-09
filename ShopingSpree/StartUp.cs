using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] personas = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < personas.Length; i++)
            {
                string[] currentPersonInfo = personas[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Person person = new Person(
                        currentPersonInfo[0]
                        , decimal.Parse(currentPersonInfo[1]));

                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            List<Product> products = new List<Product>();

            string[] productsInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] currentProduct = productsInfo[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Product product = new Product(
                        currentProduct[0],
                        decimal.Parse(currentProduct[1]));

                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] buyProduct = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string buyerName = buyProduct[0];
                string productToBuy = buyProduct[1];

                Person person = people.FirstOrDefault(p => p.Name.Equals(buyerName));

                Product product = products.FirstOrDefault(p => p.Name.Equals(productToBuy));

                if (person != null && product != null)
                {
                    person.Buy(product);
                }
            }

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class Shop
{
    public List<Product> Products { get; set; } = new List<Product>();
    public decimal TotalIncome { get; set; } = 0;

    public void AddProduct(Product product)
    {
        if (Products.Any(p => p.Name == product.Name && p.GetType() == product.GetType()))
        {
            Products.First(p => p.Name == product.Name && p.GetType() == product.GetType()).Count += product.Count;
        }
        else
        {
            Products.Add(product);
        }
    }

    public void SellProduct(string name, int count)
    {
        Product product = Products.FirstOrDefault(p => p.Name == name);

        if (product == null)
        {
            Console.WriteLine("Bu adda product tapilmadi.");
            return;
        }

        if (product.Count < count)
        {
            Console.WriteLine("Istifadecinin istediyi say qeder product yoxdur.");
            return;
        }

        product.Count -= count;
        TotalIncome += product.Price * count;
        Console.WriteLine($"{count} eded {name} satildi.");
    }

    public void ShowProducts()
    {
        Console.WriteLine("Qalan productlar:");
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name} - {product.Count} eded - {product.Price} AZN");

            if (product is Coffee coffee)
            {
                Console.WriteLine($"Roast Level: {coffee.RoastLevel}, Origin: {coffee.Origin}");
            }
            else if (product is Tea tea)
            {
                Console.WriteLine($"Type: {tea.Type}, Region: {tea.Region}");
            }
        }
    }
}

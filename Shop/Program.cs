using System;

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Product elave edin");
            Console.WriteLine("2. Product satin");
            Console.WriteLine("3. Gelire baxin");
            Console.WriteLine("4. Qalan producta baxin");
            Console.WriteLine("5. Cixish");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(shop);
                    break;
                case "2":
                    SellProduct(shop);
                    break;
                case "3":
                    Console.WriteLine($"Total Income: {shop.TotalIncome} AZN");
                    break;
                case "4":
                    shop.ShowProducts();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Yanlish secim! Yeniden cehd edin.");
                    break;
            }
        }
    }

    static void AddProduct(Shop shop)
    {
        Console.Write("Productun tipini daxil edin (c - Coffee, t - Tea): ");
        string type = Console.ReadLine().ToLower();

        if (type != "c" && type != "t")
        {
            Console.WriteLine("Yanlish product tipi daxil etdiniz.");
            return;
        }

        Product product;
        if (type == "c")
        {
            product = CreateCoffee();
        }
        else
        {
            product = CreateTea();
        }

        shop.AddProduct(product);
    }

    static void SellProduct(Shop shop)
    {
        Console.Write("Satilacaq productun adini daxil edin: ");
        string name = Console.ReadLine();

        Console.Write("Satilacaq productun sayini daxil edin: ");
        int count = Convert.ToInt32(Console.ReadLine());

        shop.SellProduct(name, count);
    }

    static Coffee CreateCoffee()
    {
        Console.Write("Coffee'nin adini daxil edin: ");
        string name = Console.ReadLine();

        Console.Write("Coffee'nin qiymetini daxil edin: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Coffee'nin sayini daxil edin: ");
        int count = Convert.ToInt32(Console.ReadLine());

        Console.Write("Coffee'nin kavurma seviyyesini daxil edin: ");
        string roastLevel = Console.ReadLine();

        Console.Write("Coffee'nin menşeyini daxil edin: ");
        string origin = Console.ReadLine();

        return new Coffee { Name = name, Price = price, Count = count, RoastLevel = roastLevel, Origin = origin };
    }

    static Tea CreateTea()
    {
        Console.Write("Tea'nın adini daxil edin: ");
        string name = Console.ReadLine();

        Console.Write("Tea'nın qiymetini daxil edin: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Tea'nın sayini daxil edin: ");
        int count = Convert.ToInt32(Console.ReadLine());

        Console.Write("Tea'nın növünü daxil edin: ");
        string type = Console.ReadLine();

        Console.Write("Tea'nın bölgəsini daxil edin: ");
        string region = Console.ReadLine();

        return new Tea { Name = name, Price = price, Count = count, Type = type, Region = region };
    }
}

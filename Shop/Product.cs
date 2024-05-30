public abstract class Product
{
    public string Name { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}

public class Coffee : Product
{
    public string RoastLevel { get; set; }
    public string Origin { get; set; }
}

public class Tea : Product
{
    public string Type { get; set; }
    public string Region { get; set; }
}

using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer cust1 = new Customer("Clarke David", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Xbox", 101, 1200, 1));
        order1.AddProduct(new Product("Stylus Pen", 102, 25, 2));

        // Second Order
        Address addr2 = new Address("45 Queen St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Peterson Smith", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Air Pods", 201, 300, 1));
        order2.AddProduct(new Product("Power Bank", 202, 75, 1));
        order2.AddProduct(new Product("Laptop", 203, 10, 3));

        // Display results
        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost()}\n");
    }
}

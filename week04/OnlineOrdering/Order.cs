using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += _customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder("Packing Label:\n");
        foreach (var product in _products)
        {
            label.AppendLine($"{product.GetName()} (ID: {product.GetId()})");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}

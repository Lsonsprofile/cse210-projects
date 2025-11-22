using System;
using System.Collections.Generic;

public class Order
{
    // Each order belongs to one customer
    private Customer _customer;

    // Each order can contain multiple products
    private List<Product> _products;

    // Constructor: when you create an Order, you must pass in a Customer
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>(); // start with an empty product list
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    /*
      Example:
      Product p1 = new Product("Laptop", "P001", 1000, 1);
      order1.AddProduct(p1); // adds Laptop to the order
    */

    // Compute total cost of products only (subtotal, without shipping)
    public double ComputeTotalPrice()
    {
        double totalCost = 0;
        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost(); // price × quantity
        }
        return totalCost;
    }
    /*
      Example:
      Laptop = 1000 × 1 = 1000
      Mouse = 50 × 2 = 100
      ComputeTotalPrice() = 1100
    */

    // Compute shipping cost based on customer location
    public double GetShippingCost()
    {
        if (_customer.LivesInUSA())
        {
            return 5;   // cheaper shipping if inside USA
        }
        else
        {
            return 35;  // more expensive shipping if outside USA
        }
    }
    /*
      Example:
      Customer in Nigeria → GetShippingCost() = 35
      Customer in USA → GetShippingCost() = 5
    */

    // Generate packing label (list of products)
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += product.GetPackingLabelInfo() + "\n";
        }
        return label;
    }
    /*
      Example output:
      Packing Label:
      Laptop (ID: P001)
      Mouse (ID: P002)
    */

    // Generate shipping label (customer name + address)
    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingAddress();
    }
    /*
      Example output:
      Shipping Label:
      Emmanuel
      123 Main St
      Lagos, Lagos State
      Nigeria
    */
}

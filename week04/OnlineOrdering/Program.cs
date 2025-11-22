using System;

class Program
{
    static void Main(string[] args)
    {
        // Header
        Console.WriteLine("ONLINE ORDERING SYSTEM!");
        Console.WriteLine();
        // First customer and address (Nigeria)
        Address address1 = new Address("123 Main St", "Lagos", "Lagos State", "Nigeria");
        Customer customer1 = new Customer("Emmanuel", address1);
        Order order1 = new Order(customer1);

        // Add products to first order
        Product product1 = new Product("Laptop", "P001", 1000, 1);
        Product product2 = new Product("Mouse", "P002", 50, 2);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Second customer and address (USA)
        Address address2 = new Address("456 Elm St", "Houston", "Texas", "USA");
        Customer customer2 = new Customer("Sarah", address2);
        Order order2 = new Order(customer2);

        // Add products to second order
        Product product3 = new Product("Phone", "P003", 800, 1);
        Product product4 = new Product("Charger", "P004", 25, 3);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display first order
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetPackingLabel());

        double productTotal1 = order1.ComputeTotalPrice();
        double shipping1 = order1.GetShippingCost();
        double finalTotal1 = productTotal1 + shipping1;

        Console.WriteLine("Product Total: $" + productTotal1);
        Console.WriteLine("Shipping Cost: $" + shipping1);
        Console.WriteLine("Final Total Price: $" + finalTotal1);
        Console.WriteLine();

        // Display second order 
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetPackingLabel());

        double productTotal2 = order2.ComputeTotalPrice();
        double shipping2 = order2.GetShippingCost();
        double finalTotal2 = productTotal2 + shipping2;

        Console.WriteLine("Product Total: $" + productTotal2);
        Console.WriteLine("Shipping Cost: $" + shipping2);
        Console.WriteLine("Final Total Price: $" + finalTotal2);
    }
}

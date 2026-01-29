using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Address address1 = new Address("123 Main st", "Melissa", "Texas", "USA");
        Customer customer1 = new Customer("James Wilson", address1);
        Product p1 = new Product("Notebook", 16465, 7.50, 2);
        Product p2 = new Product("Gel Pens", 66497, 5.99, 3);
        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Address address2 = new Address("456 Somewhere rd", "London", "England");
        Customer customer2 = new Customer("Frankie Jones", address2);
        Product p3 = new Product("Laptop", 16495, 399.99, 1);
        Product p4 = new Product("Bag", 56898, 49.99, 1);
        Product p5 = new Product("Wireless Mouse", 66981, 15.99, 1);
        Order order2 =  new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        orders.Add(order2);
        orders.Add(order1);

        foreach(Order order in orders) 
        {
            double total = order.CalculateTotal();
            string ship = order.ShippingLabel();
            string pack = order.PackingLabel();

            Console.WriteLine($"Shipping label:\n{ship}");
            Console.WriteLine($"Total price: ${total}\n");
            Console.WriteLine($"Packing label:\n{pack}");
            Console.WriteLine();
        }
        
    }
}
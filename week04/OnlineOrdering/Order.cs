public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double CalculateTotal()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.TotalCost();
        }

        bool country = _customer.checkUSA();
        if (country == true)
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string PackingLabel()
    {
        string label = "";

        foreach (Product product in _products)
        {
            label += product.PackingLabel();
            label += "\n";
        }

        return label;
    }

    public string ShippingLabel()
    {
        string label = _customer.ShippingLabel();
        return label;
    }
}
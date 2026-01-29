public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool checkUSA()
    {
       return _address.CheckUSA();
    }

    public string ShippingLabel()
    {
        string label = $"{_name}\n{_address.FormatAddress()}";
        return label;
    }
}
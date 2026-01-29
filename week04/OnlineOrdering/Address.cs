public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }
    public Address(string street, string city, string country)
    {
        _street = street;
        _city = city;
        _country = country;
    }

    public bool CheckUSA()
    {
        if (_country.Trim().ToLowerInvariant() == "usa")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string FormatAddress()
    {
        string formattedAddress = $"{_street}, {_city} {_state}\n{_country}";
        return formattedAddress;
    }
}
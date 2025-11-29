public class Address
{
    // Fields (private variables)
    private string _street;   // e.g., "123 Main St"
    private string _city;     // e.g., "Lagos"
    private string _state;    // e.g., "Lagos State"
    private string _country;  // e.g., "Nigeria" or "USA"

    // Constructor: when you create an Address, you must pass in all details
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }
    /*
      Example:
      Address addr1 = new Address("123 Main St", "Lagos", "Lagos State", "Nigeria");
      Address addr2 = new Address("456 Elm St", "Houston", "Texas", "USA");
    */

    // Check if the address is in the USA
    public bool IsInUSA()
    {
        return _country.ToUpper() == "USA";
    }
    /*
      Example:
      addr1.IsInUSA() → false
      addr2.IsInUSA() → true
    */

    // Return the full formatted address
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
    /*
      Example:
      addr1.GetFullAddress() →
      "123 Main St
       Lagos, Lagos State
       Nigeria"

      addr2.GetFullAddress() →
      "456 Elm St
       Houston, Texas
       USA"
    */
}

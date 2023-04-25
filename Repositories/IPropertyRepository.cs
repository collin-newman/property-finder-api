using PropertyFinderApi.Models;

public interface IPropertyRepository
{
    IEnumerable<Property> GetProperties();
    Property GetProperty(string id);
    Property CreateProperty(Property property);
    Property UpdateProperty(string id, Property updatedProperty);
    bool DeleteProperty(string id);
}

using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PropertyFinderApi.Models;
using Dapper;



public class PropertyRepository : IPropertyRepository
{
    private readonly string _connectionString;

    public PropertyRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection Connection => new NpgsqlConnection(_connectionString);

    public IEnumerable<Property> GetProperties()
    {
        using var db = Connection;
        return db.Query<Property>("SELECT * FROM properties");
    }

    public Property GetProperty(string id)
    {
        using var db = Connection;
        return db.Query<Property>("SELECT * FROM properties WHERE property_id = @Id", new { Id = id }).FirstOrDefault();
    }

    public Property CreateProperty(Property property)
    {
        using var db = Connection;
        var id = db.ExecuteScalar<int>("INSERT INTO properties (property_id, description, street, city, state, zip, price) VALUES (@PropertyId, @Description, @Street, @City, @State, @Zip, @Price) RETURNING id", property);
        property.Id = id;
        return property;
    }

    public Property UpdateProperty(string id, Property updatedProperty)
    {
        using var db = Connection;
        db.Execute("UPDATE properties SET property_id = @PropertyId, description = @Description, street = @Street, city = @City, state = @State, zip = @Zip, price = @Price WHERE property_id = @Id", new { Id = id, updatedProperty.PropertyId, updatedProperty.Description, updatedProperty.Street, updatedProperty.City, updatedProperty.State, updatedProperty.Zip, updatedProperty.Price });
        return updatedProperty;
    }

    public bool DeleteProperty(string id)
    {
        using var db = Connection;
        int affectedRows = db.Execute("DELETE FROM properties WHERE property_id = @Id", new { Id = id });
        return affectedRows > 0;
    }
}

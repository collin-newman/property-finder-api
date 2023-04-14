using System;

public class Photo
{
    public string Href { get; set; }
}

public class Flags
{
    public bool? IsNewConstruction { get; set; }
    public bool? IsSubdivision { get; set; }
    public bool? IsPlan { get; set; }
    public bool? IsPriceReduced { get; set; }
    public bool? IsPending { get; set; }
    public bool? IsForeclosure { get; set; }
    public bool IsNewListing { get; set; }
    public bool IsComingSoon { get; set; }
    public bool? IsContingent { get; set; }
}

public class Description
{
    public int YearBuilt { get; set; }
    public int? Baths3Qtr { get; set; }
    public DateTime SoldDate { get; set; }
    public int SoldPrice { get; set; }
    public int BathsFull { get; set; }
    public string Name { get; set; }
    public int? BathsHalf { get; set; }
    public int LotSqft { get; set; }
    public int Sqft { get; set; }
    public int Baths { get; set; }
    public string SubType { get; set; }
    public int? Baths1Qtr { get; set; }
    public int Garage { get; set; }
    public int Stories { get; set; }
    public int Beds { get; set; }
    public string Type { get; set; }
}

public class Coordinate
{
    public double Lon { get; set; }
    public double Lat { get; set; }
}

public class Address
{
    public string PostalCode { get; set; }
    public string State { get; set; }
    public Coordinate Coordinate { get; set; }
    public string City { get; set; }
    public string StateCode { get; set; }
    public string Line { get; set; }
}

public class County
{
    public string FipsCode { get; set; }
    public string Name { get; set; }
}

public class Location
{
    public Address Address { get; set; }
    public string StreetViewUrl { get; set; }
    public County County { get; set; }
}

public class Property
{
    public Photo PrimaryPhoto { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public List<string> Tags { get; set; }
    public DateTime ListDate { get; set; }
    public int ListPrice { get; set; }
    public string PropertyId { get; set; }
    public Flags Flags { get; set; }
    public Description Description { get; set; }
    public string ListingId { get; set; }
    public int? PriceReducedAmount { get; set; }
    public Location Location { get; set; }
}

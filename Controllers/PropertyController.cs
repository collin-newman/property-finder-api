using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PropertyController : ControllerBase
{
    private static List<Property> _properties = new List<Property>();

    // GET: api/Property
    [HttpGet]
    public ActionResult<IEnumerable<Property>> GetProperties()
    {
        return _properties;
    }

    // GET: api/Property/{id}
    [HttpGet("{id}")]
    public ActionResult<Property> GetProperty(string id)
    {
        var property = _properties.FirstOrDefault(p => p.PropertyId == id);
        if (property == null)
        {
            return NotFound();
        }

        return property;
    }

    // POST: api/Property
    [HttpPost]
    public ActionResult<Property> CreateProperty(Property property)
    {
        _properties.Add(property);
        return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
    }

    // PUT: api/Property/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateProperty(string id, Property updatedProperty)
    {
        var property = _properties.FirstOrDefault(p => p.PropertyId == id);
        if (property == null)
        {
            return NotFound();
        }

        property = updatedProperty;
        return NoContent();
    }

    // DELETE: api/Property/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteProperty(string id)
    {
        var property = _properties.FirstOrDefault(p => p.PropertyId == id);
        if (property == null)
        {
            return NotFound();
        }

        _properties.Remove(property);
        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using PropertyFinderApi.Models;

namespace PropertyFinderApi.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // GET: api/Property
        [HttpGet]
        public ActionResult<IEnumerable<Property>> GetProperties()
        {
            return Ok(_propertyRepository.GetProperties());
        }

        // GET: api/Property/{id}
        [HttpGet("{id}")]
        public ActionResult<Property> GetProperty(string id)
        {
            var property = _propertyRepository.GetProperty(id);
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
            _propertyRepository.CreateProperty(property);
            return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
        }

        // PUT: api/Property/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProperty(string id, Property updatedProperty)
        {
            var property = _propertyRepository.GetProperty(id);
            if (property == null)
            {
                return NotFound();
            }

            _propertyRepository.UpdateProperty(id, updatedProperty);
            return NoContent();
        }

        // DELETE: api/Property/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProperty(string id)
        {
            var property = _propertyRepository.GetProperty(id);
            if (property == null)
            {
                return NotFound();
            }

            _propertyRepository.DeleteProperty(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMetadataController : ControllerBase
    {
        [HttpGet("userModelInfo", Name = "GetUserModelInfo")]
        public IActionResult GetModel()
        {
            string targetNamespace = "LessonMonitor.API.Models";
            var classes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(x => x.Namespace == targetNamespace)
                                  .ToList();

            ClassMetadata metadataInfo = new ClassMetadata();
            foreach (var classType in classes)
            {
                var modelName = classType.Name;
                metadataInfo.ClassName = modelName;

                var modelPropetries = classType.GetProperties();

                foreach (var property in modelPropetries)
                {
                    metadataInfo.PropertyInfo.Add(new PropertyMetadata
                    {
                        PropertyName = property.Name,
                        PropertyDescription = property.GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty,
                        PropetryType = property.PropertyType.Name
                    });
                }
            }
            return Ok(metadataInfo);
        }
    }

    public record ClassMetadata
    {
        public string ClassName { get; set; }

        public List<PropertyMetadata> PropertyInfo { get; set; } = new List<PropertyMetadata>();
    }

    public record PropertyMetadata
    {
        public string PropertyName { get; set; }

        public string PropertyDescription { get; set; }

        public string PropetryType { get; set; }
    }
}

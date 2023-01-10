using Odev.Entities.Base;
using Odev.Entities.Base;

namespace Odev.Entities.Model
{
    [BsonCollection("categories")]
    public class Category : Document
    {
        public string Name { get; set; }
    }

}

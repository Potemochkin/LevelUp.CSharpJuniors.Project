using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Api.DAL.Entities
{
    public sealed record ProductEntity // это строка нашей таблицы подуктс, нашей бд.

        // Эта таблица состоит из 4х колонок и навигейшен проперти по внешнему ключу
    {
       
        public Guid Id { get; init; }
               
        public Guid CategoryId { get; init; }
               
        public string Name { get; init; } = string.Empty;
               
        public string? Description { get; init; }

       public bool IsActive { get; init; }

        public IEnumerable<PropertyValue> Properties { get; init;} = Enumerable.Empty<PropertyValue>();
                
    }
}

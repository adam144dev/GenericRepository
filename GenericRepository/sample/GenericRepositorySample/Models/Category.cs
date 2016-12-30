using GenericRepository;
using System.Collections.Generic;

namespace GenericRepositorySample.Models
{
    public class Category : IEntityId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

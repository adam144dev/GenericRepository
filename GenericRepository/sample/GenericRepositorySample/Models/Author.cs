using GenericRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRepositorySample.Models
{
    public class Author : IEntityId
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [NotMapped]
        public string FullName => FirstName + ' ' + LastName;

    }
}

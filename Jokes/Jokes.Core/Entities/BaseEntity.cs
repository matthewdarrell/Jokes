using System.ComponentModel.DataAnnotations;

namespace Jokes.Core.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; }
    }
}

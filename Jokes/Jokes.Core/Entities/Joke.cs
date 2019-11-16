using System.ComponentModel.DataAnnotations;

namespace Jokes.Core.Entities
{
    public class Joke : BaseEntity
    {
        [Required]
        public string Setup { get; set; }
        [Required]
        public string Punchline { get; set; }
    }
}

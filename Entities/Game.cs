using System.ComponentModel.DataAnnotations;

namespace GamesStore.API.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public required string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public required string Genre { get; set; }
        [Range(1, 100)]
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(100)]
        [Url]
        public string? ImageUrl { get; set; }
    }
}

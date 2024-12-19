using Tabu.Entities;

namespace Tabu.DTOs.BannedWords
{
    public class BannedWordGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public int WordId { get; set; }
        public Word Word { get; set; } = null!;
    }
}

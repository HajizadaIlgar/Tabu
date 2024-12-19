namespace Tabu.Entities
{
    public class Language
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public IEnumerable<Game>? Games { get; set; }
        public ICollection<Word>? Words { get; set; }
    }
}

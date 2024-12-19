namespace Tabu.DTOs.Words
{
    public class WordGetDto
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public IEnumerable<string> BannedWords { get; set; }
    }
}

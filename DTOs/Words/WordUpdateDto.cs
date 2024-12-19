namespace Tabu.DTOs.Words
{
    public class WordUpdateDto
    {
        public string Text { get; set; }
        public string Language { get; set; }
        public IEnumerable<string> BannedWords { get; set; }
    }
}

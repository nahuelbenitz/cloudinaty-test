namespace CloudinaryTest.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Body { get; set; }
        public string UrlImage { get; set; } = null!;
    }
}

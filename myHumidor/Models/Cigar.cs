namespace myHumidor.Models
{
    public class Cigar
    {
        public int CigarId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public int RingGauge { get; set; }
        public string Country { get; set; }
        public string Filler { get; set; }
        public string Wrapper { get; set; }
        public string Color { get; set; }
        public string Strength { get; set; }
        public List<Cigar> Cigars { get; set; }
        public static List<Cigar> Favorites { get; set; }
        public static List<Cigar> SearchList { get; set; } = new List<Cigar>();
        public bool Favorite { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
    }
}
